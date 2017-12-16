using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Coordinate
{

	public int x;
	public int y;

	public static int NOT_ADJACENT = -1;
	public static int NORTH = 0;
	public static int SOUTH = 1;
	public static int WEST = 2;
	public static int EAST = 3;

	public Coordinate(int x, int y)
	{
		this.x = x;
		this.y = y;
	}

	// the returned value should be read as follows: "coordinate" is <DIRECTION> of <this>
	public int IsAdjacent(Coordinate coordinate)
	{
		if (x == coordinate.x)
		{
			if (y + 1 == coordinate.y)
			{
				return NORTH;
			}
			else if (y - 1 == coordinate.y)
			{
				return SOUTH;
			}
		}
		else if (y == coordinate.y)
		{
			if (x + 1 == coordinate.x)
			{
				return EAST;
			}
			else if (x - 1 == coordinate.x)
			{
				return WEST;
			}
		}
		//diagonal?
		return NOT_ADJACENT;
	}

	public Dictionary<int, Coordinate> GetAdjacentCoordinates(Room room)
	{
		return GetAdjacentCoordinates(new List<Coordinate>(room.GetCoordinates()));
	}

	public Dictionary<int, Coordinate> GetAdjacentCoordinates(List<Coordinate> coordinates)
	{
		//List<Coordinates> adjacentCoordinates = new List<Coordinates>();
		Dictionary<int, Coordinate> adjacentCoordinates = new Dictionary<int, Coordinate>();

		foreach (Coordinate coordinate in coordinates)
		{
			int direction = this.IsAdjacent(coordinate);

			if (direction != NOT_ADJACENT)
			{
				adjacentCoordinates.Add(direction, coordinate);
			}
		}

		return adjacentCoordinates;
	}

	public bool HasAdjacentCoordinate(int direction, Room room)
	{
		return this.GetAdjacentCoordinates(room).ContainsKey(direction);
	}

	public bool HasAdjacentCoordinate(int direction, List<Room> rooms)
	{
		foreach (Room room in rooms)
		{
			if (this.GetAdjacentCoordinates(room).ContainsKey(direction))
			{
				return true;
			}
		}
		return false;
	}

	public override bool Equals(System.Object obj)
	{
		if (obj != null && obj is Coordinate)
		{
			Coordinate c = (Coordinate)obj;
			if (this.x == c.x && this.y == c.y)
			{
				return true;
			}
		}
		return false;
	}
	public double DistanceTo(Coordinate other)
	{
		double vx = x - other.x;
		double vy = y - other.y;
		return Math.Sqrt(vx * vx + vy * vy);
	}

	public List<Coordinate> GetSurroundingCoordinates()
	{
		return GetSurroundingCoordinates(x, y);
	}

	public static List<Coordinate> GetSurroundingCoordinates(int x, int y)
	{
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
		return coordinates;
	}


	public override int GetHashCode()
	{
		return base.GetHashCode();
	}

	public override string ToString()
	{
		return "[" + x + "|" + y + "]";
	}

}