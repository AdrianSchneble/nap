using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GenerationScript : MonoBehaviour
{

	public int roomSize;
	public int roomCount = -1;
	public GameObject groundTile;
	public GameObject wallTile;
	public GameObject doorTile;

	public GameObject waterTile;
	public GameObject lavaTile;
	public GameObject acceleratorTile;
	public GameObject sandTile;

	public GameObject barrel;

	private static System.Random random = new System.Random();

	public List<Room> GenerateFloor(int roomCount)
	{
		List<Room> floor = new List<Room>();
		List<Coordinate> possibleLocations = new List<Coordinate>();
		Room start = new Room(Room.START, new Coordinate(0, 0));

		floor.Add(start);

		//  generate a list of possible rooms adjacent to the currently existing room(s);
		//      i.e. a list of possible locations for the next room
		CalculateNewSurroundings(possibleLocations, floor, start, roomCount);

		for (int roomNum = 1; roomNum < roomCount; roomNum++)
		{
			//choose a viable location for a new room, depending on the entries in <possibleLocations> and <floor>
			Room room = FindNewRoomLocation(possibleLocations, floor, roomCount);
			//add the room to the floor, thereby eventually rendering the room
			floor.Add(room);
			//recalculate the frame of empty coordinates around the existing rooms in <floor>.
			//Accept <room> as an argument to improve performance by not recalculating everything.
			possibleLocations = CalculateNewSurroundings(possibleLocations, floor, room, roomCount);
		}
		//TODO change this! minimum distance to start tile required; choose room from e.g. the upper 30% of rooms if sorted by distance to start
		List<Room> sortedFloor = floor.OrderByDescending(r => r.GetTopLeftCoordinate().DistanceTo(new Coordinate(0, 0))).ToList();
		sortedFloor.RemoveAll(r => r.GetCoordinates().Count > 1); //only 1x1 rooms allowed
		if (sortedFloor.Count < 2)  //i.e. less than two 1x1 rooms were generated (one of which is the starting room) --> no 1x1 left for the end room!
		{
			throw new NoViableEndRoomLocationException();
		}
		List<Room> viableEndRoomLocations = sortedFloor.GetRange(0, (int)(0.5d * sortedFloor.Count));
		viableEndRoomLocations[random.Next(viableEndRoomLocations.Count)].type = Room.END;

		return floor;
	}

	private List<Coordinate> getSurroundingCoordinates(List<Coordinate> coordinates)
	{
		List<Coordinate> result = new List<Coordinate>();
		// iterate through all coordinates, get each coordinates' surroundings, remove duplicates and
		// surroundings that overlap with the original coordinates
		foreach (Coordinate coordinate in coordinates)
		{
			foreach (Coordinate c in coordinate.GetSurroundingCoordinates())
			{
				if (!coordinates.Contains(c) && !result.Contains(c))
				{
					result.Add(c);
				}
			}
		}
		return result;
	}

	//Take newRoom as an argument to improve performance by not recalculating everything, instead only calculate the possibleLocations that will have changed due to the addition of newRoom.
	/// <summary>
	/// 
	/// </summary>
	/// <param name="possibleLocations"></param>
	/// <param name="floor"></param>
	/// <param name="newRoom"></param>
	/// <returns></returns>
	public List<Coordinate> CalculateNewSurroundings(List<Coordinate> possibleLocations, List<Room> floor, Room newRoom, int maxRoomCount)
	{
		//TODO make sure it doesn't matter whether you call "floor.Add(...)" or this method first! I.e., whether <newRoom> is contained in <floor>

		List<Coordinate> newRoomToList = new List<Coordinate>(newRoom.GetCoordinates());
		List<Coordinate> coordinates = getSurroundingCoordinates(newRoomToList);
		/* calculate a max coordinate value, ensuring that the rooms are not generated in a straight line outwards from the starting tile (which would be ugly)
		Don't just take the plain "maxRoomCount / 2", but make sure to prevent situations where the limit in conjunction with an unlucky room placement
		leads to new rooms being unable to be placed.
		Therefore, assuming all rooms are randomly chosen to be 2x2 rooms (the max room size), an (generous) upper space consumption limit of
			consumption = 3² * x = 9 * x			with x = roomCount
		can be used. Calculating the intersection between this function and
			availableSpace = roundedDown(x/2) + 1 + roundedDown(x/2),
		simplified to
			minAvailableSpace = x²,
		leads to an intersection just below x = 9. After this point, the minAvailable space increases more rapidly than the max space consumption.
		Therefore, using a limit of
			|c| <= 5 <AND> |c| <= (roomCount/2)		with c = x- or y-value of the coordinate
		certainly prevents rooms from being generated in one straight line, while not causing exceptions at low roomCounts either.
		Note that lower values might also be sufficient, but using this calculation one can be sure that there won't be any missing space
		*/
		int maxValue = maxRoomCount <= 5 ? 5 : (maxRoomCount / 2);
		for (int i = coordinates.Count - 1; i >= 0; i--)
		{
			Coordinate c = coordinates[i];
			//remove any coordinates that are deemed too far away from the starting tile
			if (Math.Abs(c.x) > maxValue || Math.Abs(c.y) > maxValue)
			{
				coordinates.Remove(c);
				continue;
			}
			//remove any coordinates that are already contained in <possibleLocations>
			if (possibleLocations.Contains(c))
			{
				coordinates.Remove(c);
				continue;
			}
			foreach (Room room in floor)
			{
				if (room.HasCoordinate(c))
				{
					coordinates.Remove(c);
					continue;
				}
			}
		}

		//remove newRoom coordinates from possibleLocations!
		possibleLocations.RemoveAll(c => newRoom.HasCoordinate(c));

		//add the remaining coordinates (i.e. the valid ones) to <possibleLocations>
		possibleLocations.AddRange(coordinates);

		return possibleLocations;
	}

	private static void Log(String log)
	{
		Debug.Log(log);
	}

	private static void Log(System.Object log)
	{
		Log(log.ToString());
	}

	private static string AttachListToString<T>(List<T> possibleLocations, string original)
	{
		foreach (T coord in possibleLocations)
		{
			original += coord + "\n";
		}
		return original;
	}

	public Room FindNewRoomLocation(List<Coordinate> possibleLocations, List<Room> floor, int totalRoomCount)
	{
		//idea: increase probability for room generation, the farther away from the starting tile the location is
		//  --> create a hashmap of the rooms, sorted by their weight, which is the length of the vector to the starting tile
		//      (centered, not corner!)
		// also decrease probability for each adjacent room at the generation location

		Coordinate start = new Coordinate(0, 0);
		Dictionary<Room, double> weights = new Dictionary<Room, double>();
		double weightSum = 0;
		double sizeRnd = random.NextDouble();
		int size = -1;
		const int size1x1 = 0;
		const int size1x2 = 1;
		const int size2x2 = 2;
		const double probability1x1 = 0.6;
		const double probability1x2 = 0.25;
		const double probability2x2 = 0.15;

		if (sizeRnd <= probability2x2)
		{
			//TODO can lead to "null" being returned
			size = size2x2;
		}
		else if (sizeRnd <= probability1x2 + probability2x2)
		{
			size = size1x2;
		}
		else
		{
			size = size1x1;
		}

		List<Coordinate> possibleLocCopy = new List<Coordinate>(possibleLocations);
		List<Room> possibleRooms = new List<Room>();
		if (size == size1x1)
		{
			foreach (Coordinate c in possibleLocCopy)
			{
				possibleRooms.Add(new Room(c));
			}
		}
		else if (size == size1x2)
		{
			foreach (Coordinate coordinate in possibleLocCopy)
			{
				List<Coordinate> surrounding = coordinate.GetSurroundingCoordinates();
				foreach (Coordinate c in GetCoordinatesFromRooms(floor))
				{
					surrounding.Remove(c);
				}
				foreach (Coordinate c in surrounding)
				{
					possibleRooms.Add(new Room(coordinate, c));
				}
			}
		}
		else if (size == size2x2)
		{
			foreach (Coordinate coordinate in possibleLocCopy)
			{
				//choose vertical surroundings --> can both coordinates expand east/west?
				//choose horizontal surroundings --> can both coordinates expand north/south?

				List<Coordinate> vertical = new List<Coordinate>
				{
					new Coordinate(coordinate.x, coordinate.y + 1),
					new Coordinate(coordinate.x, coordinate.y - 1)
				};
				List<Coordinate> horizontal = new List<Coordinate>
				{
					new Coordinate(coordinate.x + 1, coordinate.y),
					new Coordinate(coordinate.x - 1, coordinate.y)
				};

				foreach (Coordinate c in GetCoordinatesFromRooms(floor))
				{
					vertical.Remove(c);
					horizontal.Remove(c);
				}
				foreach (Coordinate c in vertical)
				{
					//if coordinate.canExpandWest && c.canExpandWest --> possible 2x2
					//same for canExpandEast
					if (!coordinate.HasAdjacentCoordinate(Coordinate.WEST, floor) && !c.HasAdjacentCoordinate(Coordinate.WEST, floor))
					{
						Coordinate west1 = new Coordinate(c.x - 1, c.y);
						Coordinate west2 = new Coordinate(coordinate.x - 1, coordinate.y);
						possibleRooms.Add(new Room(coordinate, c, west1, west2));
					}
					if (!coordinate.HasAdjacentCoordinate(Coordinate.EAST, floor) && !c.HasAdjacentCoordinate(Coordinate.EAST, floor))
					{
						Coordinate east1 = new Coordinate(c.x + 1, c.y);
						Coordinate east2 = new Coordinate(coordinate.x + 1, coordinate.y);
						possibleRooms.Add(new Room(coordinate, c, east1, east2));
					}
				}
				foreach (Coordinate c in horizontal)
				{
					//if coordinate.canExpandWest && c.canExpandWest --> possible 2x2
					//same for canExpandEast
					if (!coordinate.HasAdjacentCoordinate(Coordinate.NORTH, floor) && !c.HasAdjacentCoordinate(Coordinate.NORTH, floor))
					{
						Coordinate north1 = new Coordinate(c.x, c.y + 1);
						Coordinate north2 = new Coordinate(coordinate.x, coordinate.y + 1);
						possibleRooms.Add(new Room(coordinate, c, north1, north2));
					}
					if (!coordinate.HasAdjacentCoordinate(Coordinate.SOUTH, floor) && !c.HasAdjacentCoordinate(Coordinate.SOUTH, floor))
					{
						Coordinate south1 = new Coordinate(c.x, c.y - 1);
						Coordinate south2 = new Coordinate(coordinate.x, coordinate.y - 1);
						possibleRooms.Add(new Room(coordinate, c, south1, south2));
					}
				}
			}
		}
		foreach (Room r in possibleRooms)
		{
			int maxCoordinateValue = totalRoomCount <= 5 ? 5 : (totalRoomCount / 2);
			int maxDistanceToStart = (int)(Math.Sqrt(2) * maxCoordinateValue);

			// the weight is at its maximum when in a corner (specifically, topleft/bottomright corners, since we're looking at the top-left coordinate),
			// while all weights closer to the starting tile are scaled accordingly.
			double w = 1 + (r.GetTopLeftCoordinate().DistanceTo(start) / maxDistanceToStart) * 2;

			//if possibleLocations.contains(adjacentCoordinate) then decrease weight (i.e. weight *= 1/numberOfAdjacentCoordinates)
			List<Coordinate> floorCoordinates = GetCoordinatesFromRooms(floor);
			HashSet<Coordinate> surroundings = new HashSet<Coordinate>();
			//calculate all coordinates surrounding the currently iterated room
			foreach (Coordinate coordinate in r.GetCoordinates())
			{
				List<Coordinate> surroundingSingle = coordinate.GetSurroundingCoordinates();
				for (int i = surroundingSingle.Count - 1; i >= 0; i--)
				{
					Coordinate c = surroundingSingle[i];
					if (r.HasCoordinate(c))
					{
						surroundingSingle.Remove(c);
					}
				}
				surroundings.UnionWith(surroundingSingle);
			}
			int adjacentCount = 0;
			foreach (Coordinate adjacent in surroundings)
			{
				foreach (Coordinate c in floorCoordinates)
				{
					if (c.Equals(adjacent))
					{
						adjacentCount++;
					}
				}
			}
			if (adjacentCount != 0)
			{
				w /= adjacentCount;
			}
			else
			{
				throw new ImpossibleException();
			}

			weights.Add(r, w);
			weightSum += w;
		}

		double chosenWeight = random.NextDouble() * weightSum;
		Room chosen = null;
		foreach (KeyValuePair<Room, double> kvPair in weights)
		{
			chosenWeight -= kvPair.Value;
			if (chosenWeight <= 0)
			{
				chosen = kvPair.Key;
				break;
			}
		}

		//TODO ERROR: chosen could be null! throw Exception!
		Room room = chosen;

		return room;
	}

	private List<Coordinate> GetCoordinatesFromRooms(List<Room> rooms)
	{
		List<Coordinate> coordinates = new List<Coordinate>();
		foreach (Room room in rooms)
		{
			foreach (Coordinate coordinate in room.GetCoordinates())
			{
				// multiple rooms containing the same coordinate should not be possible, so no handling required (at least not here)
				coordinates.Add(coordinate);
			}
		}
		return coordinates;
	}

	private void RenderRooms(List<Room> rooms)
	{
		HashSet<Tile> doorCandidates = new HashSet<Tile>();
		HashSet<Tile> doors = new HashSet<Tile>();
		HashSet<Tile> walls = new HashSet<Tile>();
		//calculate the center of the room so that the door can be placed
		int doorTileNum = (roomSize % 2 == 0) ? -1 : (roomSize - 1) / 2;
		int lastTileIndex = roomSize - 1;

		for (int roomNum = 0; roomNum < rooms.Count; roomNum++)
		{
			Room room = rooms[roomNum];

			foreach (Coordinate coordinate in room.GetCoordinates())
			{
				int xoffset = coordinate.x * (roomSize + 1);
				int yoffset = coordinate.y * (roomSize + 1);

				bool thisHasWestInRoom = coordinate.HasAdjacentCoordinate(Coordinate.WEST, room);
				bool thisHasEastInRoom = coordinate.HasAdjacentCoordinate(Coordinate.EAST, room);
				bool thisHasSouthInRoom = coordinate.HasAdjacentCoordinate(Coordinate.SOUTH, room);
				bool thisHasNorthInRoom = coordinate.HasAdjacentCoordinate(Coordinate.NORTH, room);

				for (int column = 0; column < roomSize; column++)
				{
					int x = xoffset + column;

					for (int row = 0; row < roomSize; row++)
					{
						int y = yoffset + row;


						room.tiles.Add(new Tile(x, y, groundTile));
						if (thisHasSouthInRoom)
						{
							if (thisHasEastInRoom)
							{
								room.tiles.Add(new Tile(x + 1, y - 1, groundTile));
							}
							if (thisHasWestInRoom)
							{
								room.tiles.Add(new Tile(x - 1, y - 1, groundTile));
							}
							room.tiles.Add(new Tile(x, y - 1, groundTile));
						}
						if (thisHasNorthInRoom)
						{
							if (thisHasEastInRoom)
							{
								room.tiles.Add(new Tile(x + 1, y + 1, groundTile));
							}
							if (thisHasWestInRoom)
							{
								room.tiles.Add(new Tile(x - 1, y + 1, groundTile));
							}
							room.tiles.Add(new Tile(x, y + 1, groundTile));
						}
						if (thisHasEastInRoom)
						{
							room.tiles.Add(new Tile(x + 1, y, groundTile));
						}
						if (thisHasWestInRoom)
						{
							room.tiles.Add(new Tile(x - 1, y, groundTile));
						}

						///////////
						// WALLS //
						///////////
						if (column == 0 && !thisHasWestInRoom)
						{
							//create bottom-left cornerpiece
							if (row == 0)
							{
								walls.Add(new Tile(x - 1, y - 1, wallTile));
							}
							//create top-left cornerpiece
							else if (row == lastTileIndex)
							{
								walls.Add(new Tile(x - 1, y + 1, wallTile));
							}

							//create west door
							if (row == doorTileNum)
							{
								AddDoor(new Tile(x - 1, y, doorTile), doors, doorCandidates);
							}
							//create west wall
							else
							{
								walls.Add(new Tile(x - 1, y, wallTile));
							}
						}
						else if (column == lastTileIndex && !thisHasEastInRoom)
						{
							//create bottom-right cornerpiece
							if (row == 0)
							{
								walls.Add(new Tile(x + 1, y - 1, wallTile));
							}
							//create top-right cornerpiece
							else if (row == lastTileIndex)
							{
								walls.Add(new Tile(x + 1, y + 1, wallTile));
							}

							//create east door
							if (row == doorTileNum)
							{
								AddDoor(new Tile(x + 1, y, doorTile), doors, doorCandidates);
							}
							//create east wall
							else
							{
								walls.Add(new Tile(x + 1, y, wallTile));
							}
						}

						if (row == 0 && !thisHasSouthInRoom)
						{
							//create bottom-left cornerpiece
							if (column == 0)
							{
								walls.Add(new Tile(x - 1, y - 1, wallTile));
							}
							//create bottom-right cornerpiece
							else if (column == lastTileIndex)
							{
								walls.Add(new Tile(x + 1, y - 1, wallTile));
							}

							//create south door
							if (column == doorTileNum)
							{
								AddDoor(new Tile(x, y - 1, doorTile), doors, doorCandidates);
							}
							//create south wall
							else
							{
								walls.Add(new Tile(x, y - 1, wallTile));
							}
						}
						else if (row == lastTileIndex && !thisHasNorthInRoom)
						{
							//create top-left cornerpiece
							if (column == 0)
							{
								walls.Add(new Tile(x - 1, y + 1, wallTile));
							}
							//create top-right cornerpiece
							else if (column == lastTileIndex)
							{
								walls.Add(new Tile(x + 1, y + 1, wallTile));
							}

							//create north door
							if (column == doorTileNum)
							{
								AddDoor(new Tile(x, y + 1, doorTile), doors, doorCandidates);
							}
							//create north wall
							else
							{
								walls.Add(new Tile(x, y + 1, wallTile));
							}
						}
					}
				}
			}
		}


		/////////////
		// TERRAIN //
		/////////////

		foreach (Room room in rooms)
		{
			/* TODO
			 *	the door tiles are *not* known - therefore, apply a pre-defined pattern to the tiles to decide which tiles will definitely be ground tiles
			 *		examples:
			 *			frame pattern -> the border tiles
			 *			cross pattern
			 *	
			 *	to do this, implement a method that takes a set of tiles, treating it as square-shaped (by using min/max coordinate values),
			 *	and return those tiles that match the pattern.
			 *	Should the tile set *not* be square-shaped in reality and any tile on the calculated pattern be non-existing, throw an expection.
			 * 
			*/
			List<Tile> pattern = GetFramePattern(room.tiles);
			Log(pattern.Count);
			foreach (Tile tile in room.tiles)
			{
				if (!pattern.Contains(tile))
				{
					if (random.NextDouble() > 0.97)
					{
						tile.setObject(acceleratorTile);
					}
					else if (random.NextDouble() > 0.93)
					{
						tile.setObject(sandTile);
					}
					else if (random.NextDouble() > 0.9)
					{
						tile.setObject(lavaTile);
					}
					else if (random.NextDouble() > 0.8)
					{
						room.obstacles.Add(new Tile(tile.getX(), tile.getY(), barrel));
					}
				}
			}
		}



		foreach (Tile wall in walls)
		{
			RenderTile(wall);
		}
		foreach (Tile notDoor in doorCandidates)
		{
			Vector3 vector = new Vector3(notDoor.getX(), notDoor.getY(), 1);
			GameObject renderObject = Instantiate(wallTile, vector, new Quaternion());
			renderObject.transform.parent = gameObject.transform;
		}
		foreach (Tile door in doors)
		{
			RenderTile(door);
		}
		foreach (Room room in rooms)
		{
			foreach (Tile tile in room.tiles)
			{
				RenderTile(tile);
			}
			foreach (Tile obstacle in room.obstacles)
			{
				RenderObstacle(obstacle);
			}
		}
	}

	private List<Tile> GetFramePattern(HashSet<Tile> tiles)
	{
		int maxX = int.MinValue;
		int minX = int.MaxValue;
		int maxY = int.MinValue;
		int minY = int.MaxValue;
		foreach (Tile tile in tiles)
		{
			if (tile.getX() > maxX) maxX = tile.getX();
			if (tile.getX() < minX) minX = tile.getX();
			if (tile.getY() > maxY) maxY = tile.getY();
			if (tile.getY() < minY) minY = tile.getY();
		}
		List<Tile> result = new List<Tile>();
		for (int x = minX; x <= maxX; x++)
		{
			for (int y = minY; y <= maxY; y++)
			{
				if (x == minX || x == maxX || y == minY || y == maxY)
				{
					result.Add(new Tile(x, y, null));
				}
			}
		}
		return result;
	}

	private void RenderTile(Tile t)
	{
		Vector3 vector = new Vector3(t.getX(), t.getY(), 1);
		GameObject renderObject = Instantiate(t.getObject(), vector, new Quaternion());
		renderObject.transform.parent = gameObject.transform;
	}

	private void RenderObstacle(Tile o)
	{
		Vector3 vector = new Vector3(o.getX(), o.getY(), -1);
		GameObject renderObject = Instantiate(o.getObject(), vector, new Quaternion());
		renderObject.transform.parent = gameObject.transform;
	}

	private void AddDoor(Tile door, HashSet<Tile> doors, HashSet<Tile> doorCandidates)
	{
		if (!doorCandidates.Add(door))
		{
			doors.Add(door);
			doorCandidates.Remove(door);
		}
	}

	void Start()
	{
		List<Room> rooms;
		if (roomCount == -1 || roomCount == 0)
		{
			//default setting
			rooms = GenerateFloor(10);
		}
		else
		{
			rooms = GenerateFloor(roomCount);
		}

		// this is temporary for rendering testing purposes
		//rooms = new List<Room> {
		//	new Room(new Coordinate(0, 0), new Coordinate(0, 1)),
		//	new Room(new Coordinate(1, 0), new Coordinate(2, 0)),
		//	new Room(new Coordinate(0, -1), new Coordinate(-1, -1), new Coordinate(0, -2), new Coordinate(-1, -2)),
		//	new Room(new Coordinate(-1, 1), new Coordinate(-1, 2), new Coordinate(-2, 1), new Coordinate(-2, 2)),
		//	new Room(new Coordinate(-1, 0), new Coordinate(-2, 0), new Coordinate(-2, -1))
		//};
		RenderRooms(rooms);
	}

}
