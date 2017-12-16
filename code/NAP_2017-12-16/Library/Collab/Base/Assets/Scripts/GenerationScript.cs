using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerationScript : MonoBehaviour
{

	public int roomSize;
	public int roomCount = -1;
	public GameObject groundTile;
	public GameObject wallTile;
	public GameObject doorTile;

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
			Room room = FindNewRoomLocation(possibleLocations, floor);
			if (roomNum == roomCount - 1)
			{
				room.type = Room.END;
			}
			//add the room to the floor, thereby actually rendering the room
			floor.Add(room);
			//recalculate the frame of empty coordinates around the existing rooms in <floor>.
			//Accept <room> as an argument to improve performance by not recalculating everything.
			possibleLocations = CalculateNewSurroundings(possibleLocations, floor, room, roomCount);
		}

		//TODO: don't add a room, edit an existing one!
		//floor.Add(new Room(Room.END, new Coordinate(0, 1)));

		return floor;
	}

	//Take newRoom as an argument to improve performance by not recalculating everything, instead only the possibleLocations that will have changed thanks to the addition of newRoom.
	/// <summary>
	/// 
	/// </summary>
	/// <param name="possibleLocations"></param>
	/// <param name="floor"></param>
	/// <param name="newRoom"></param>
	/// <returns></returns>
	public List<Coordinate> CalculateNewSurroundings(List<Coordinate> possibleLocations, List<Room> floor, Room newRoom, int maxRoomCount)
	{
		//make sure it doesn't matter whether you call "floor.Add(...)" or this method first! I.e., whether <newRoom> is contained in <floor>
		//TODO (eventually) don't use [0] so that rooms bigger than 1x1 are also possible!
		Coordinate coordinate = newRoom.coordinates[0];
		int x = coordinate.x;
		int y = coordinate.y;
		Coordinate north = new Coordinate(x, y + 1);
		Coordinate south = new Coordinate(x, y - 1);
		Coordinate east = new Coordinate(x + 1, y);
		Coordinate west = new Coordinate(x - 1, y);
		List<Coordinate> coordinates = new List<Coordinate>
		{
			north,
			south,
			east,
			west
		};
		// calculate a max coordinate value, ensuring that the rooms are not generated in a straight line outwards from the starting tile (which would be ugly)
		// Don't just take the plain "maxRoomCount / 2", but make sure to prevent situations where the limit in conjunction with an unlucky room placement
		// leads to new rooms being unable to be placed.
		// Therefore, assuming all rooms are randomly chosen to be 2x2 rooms (the max room size), an (generous) upper space consumption limit of
		//		consumption = 3² * x = 9 * x			with x = roomCount
		// can be used. Calculating the intersection between this function and
		//		availableSpace = roundedDown(x/2) + 1 + roundedDown(x/2),
		// simplified to
		//		minAvailableSpace = x²,
		// one lands just below x = 9. After this point, the minAvailable space increases more rapidly than the max space consumption.
		// Therefore, using a limit of
		//		|c| <= 5 <AND> |c| <= (roomCount/2)		with c = x- or y-value of the coordinate
		// prevents rooms from being generated in one straight line, while not causing exceptions at low roomCounts either. 
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
				//Log("" + room + "\n" + coordinate);
				if (room.HasCoordinate(c))
				{
					coordinates.Remove(c);
					continue;
				}
			}
		}

		//remove newRoom coordinates from possibleLocations!
		possibleLocations.Remove(newRoom.coordinates[0]);

		//add the remaining coordinates (i.e. the valid ones) to <possibleLocations>
		possibleLocations.AddRange(coordinates);

		//String log = "";
		//log += "Existing rooms:\n";
		//foreach (Room room in floor)
		//{
		//	log += room + "\n";
		//}
		//log += "CalculateNewSurroundings:\n";
		//log = AttachListToString(possibleLocations, log);
		//Log(log);
		return possibleLocations;
	}

	private static void Log(String log)
	{
		Debug.Log(log);
	}

	private static string AttachListToString<T>(List<T> possibleLocations, string log)
	{
		foreach (T coord in possibleLocations)
		{
			log += coord + "\n";
		}
		return log;
	}

	public Room FindNewRoomLocation(List<Coordinate> possibleLocations, List<Room> floor)
	{
		System.Random random = new System.Random();
		//idea: increase probability for room generation, the farther away from the starting tile the location is
		//  --> create a hashmap of the rooms, sorted by their weight, which is the length of the vector to the starting tile
		//      (centered, not corner!)
		//TODO use [0]??? NO, search floor for START, then use coordinates[0] (since start will always be 1x1)

		Coordinate start = floor[0].coordinates[0];
		Dictionary<Coordinate, double> weights = new Dictionary<Coordinate, double>();
		double weightSum = 0;
		foreach (Coordinate coordinate in possibleLocations)
		{
			double distanceToStart = VectorLength(coordinate, start);
			double w = 1 + .3 * distanceToStart;
			weights.Add(coordinate, w);
			weightSum += w;
		}

		double chosenWeight = random.NextDouble() * weightSum;
		Coordinate chosen = null;
		foreach (KeyValuePair<Coordinate, double> kvPair in weights)
		{
			chosenWeight -= kvPair.Value;
			if (chosenWeight <= 0)
			{
				chosen = kvPair.Key;
				break;
			}
		}

		//ERROR: chosen could be null!
		//int roomToAttachTo = random.Next(0, possibleLocations.Count - 1);
		Room room = new Room(Room.DEFAULT, chosen);

		return room;
	}

	private double VectorLength(Coordinate a, Coordinate b)
	{
		double vx = b.x - a.x;
		double vy = b.y - a.y;
		return Math.Sqrt(vx * vx + vy * vy);
	}

	/*
	private void SortListByWeight(List<Coordinate> possibleLocations, Coordinate start)
	{
		possibleLocations.Sort(delegate (Coordinate a, Coordinate b)
		{
			if (VectorLength(a, start) < VectorLength(b, start))
			{

			}
			if (x.PartName == null && y.PartName == null) return 0;
			else if (x.PartName == null) return -1;
			else if (y.PartName == null) return 1;
			else return x.PartName.CompareTo(y.PartName);
		});
	)
	}*/

	// Use this for initialization
	void Start()
	{
		/*Room[] rooms = new Room[4];

		rooms[0] = new Room(new Coordinate[] {
			new Coordinate(0,0),
			   new Coordinate(0,1)
			});
		rooms[1] = new Room(new Coordinate[] {
			new Coordinate(1,0)
			});
		rooms[2] = new Room(new Coordinate[] {
			new Coordinate(2,0)
			});
		rooms[3] = new Room(new Coordinate[]
		{
			new Coordinate(1,1),
			new Coordinate(1,2),
			new Coordinate(2,1),
			new Coordinate(2,2)
		});*/

		List<Room> rooms;
		if (roomCount == -1 || roomCount == 0)
		{
			rooms = GenerateFloor(10);
		}
		else
		{
			rooms = GenerateFloor(roomCount);
		}
		//List<Room> rooms = GenerateFloor(10);

		for (int roomNum = 0; roomNum < rooms.Count; roomNum++)
		{
			Room room = rooms[roomNum];

			foreach (Coordinate coordinate in room.coordinates)
			{
				int xoffset = coordinate.x * (roomSize - 1);
				int yoffset = coordinate.y * (roomSize - 1);

				for (int column = 0; column < roomSize; column++)
				{
					if (column == 0 && coordinate.HasAdjacentCoordinate(Coordinate.WEST, room))
					{
						continue;
					}
					if (column == roomSize - 1 && coordinate.HasAdjacentCoordinate(Coordinate.EAST, room))
					{
						continue;
					}
					int lastTileIndex = roomSize - 1;
					for (int row = 0; row < roomSize; row++)
					{
						if (row == 0 && coordinate.HasAdjacentCoordinate(Coordinate.SOUTH, room))
						{
							continue;
						}
						if (row == roomSize - 1 && coordinate.HasAdjacentCoordinate(Coordinate.NORTH, room))
						{
							continue;
						}
						int doorTileNum = (roomSize % 2 == 0) ? -1 : (roomSize - 1) / 2;
						bool isDoor = (row == doorTileNum) || (column == doorTileNum);
						bool isWall = (column == 0 || column == lastTileIndex) || (row == 0 || row == lastTileIndex);

						//TODO don't generate walls & doors if the adjacent coordinates belong to the same room
						//TODO only generate a door in a wall if the adjacent coordinates belong to *a* room (not the same room)

						if (isWall && isDoor)
						{
							GameObject door = Instantiate(doorTile, new Vector3(column - 5 + xoffset, row - 5 + yoffset, 1), new Quaternion());
							door.transform.parent = gameObject.transform;
						}
						else if (isWall)
						{
							GameObject wall = Instantiate(wallTile, new Vector3(column - 5 + xoffset, row - 5 + yoffset, 1), new Quaternion());
							wall.transform.parent = gameObject.transform;
						}
						else // is ground
						{
							GameObject ground = Instantiate(groundTile, new Vector3(column - 5 + xoffset, row - 5 + yoffset, 1), new Quaternion());
							ground.transform.parent = gameObject.transform;
						}
					}
				}
			}
		}
	}

	// Update is called once per frame
	void Update()
	{

	}
}
