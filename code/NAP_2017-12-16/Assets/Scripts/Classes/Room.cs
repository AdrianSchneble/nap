using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Room
{
	public static String DEFAULT = "DEFAULT";
	public static String START = "START";
	public static String END = "END";
	public static String LOCKED = "LOCKED";
	public String type; //TODO enum!
						//these are the individual components of a room
	private HashSet<Coordinate> coordinates;
	//these are the smaller building blocks that make up every component. They are calculated in accordance with the coordinates.
	public HashSet<Tile> tiles = new HashSet<Tile>();

	public HashSet<Tile> obstacles = new HashSet<Tile>();

	/// <summary>
	/// Attention: multiple identical coordinates will be ignored, i.e. only inserted once - the array is converted to a HashSet!
	/// </summary>
	/// <param name="type">Specifies the room type, e.g. DEFAULT / START / END / LOCKED</param>
	/// <param name="coordinates">Will be converted to a HashSet! Represents as list of all coordinates that the room consists of.</param>
	public Room(String type, params Coordinate[] coordinates)
	{
		this.coordinates = new HashSet<Coordinate>(coordinates);
		this.type = type;
	}

	public Room(params Coordinate[] coordinates)
		: this(DEFAULT, coordinates)
	{

	}

	public Coordinate GetTopLeftCoordinate()
	{
		Coordinate result = new Coordinate(Int32.MaxValue, Int32.MinValue);
		foreach (Coordinate c in coordinates)
		{
			if (c.y > result.y)
			{
				result = c;
			}
			else if (c.y == result.y)
			{
				if (c.x < result.x)
				{
					result = c;
				}
				else if (c.x == result.x)
				{
					throw new ImpossibleException();
				}
			}
		}
		return result;
	}

	public HashSet<Coordinate> GetCoordinates()
	{
		return coordinates;
	}

	public bool HasCoordinate(Coordinate coordinate)
	{
		return new List<Coordinate>(coordinates).Contains(coordinate);
	}

	public override bool Equals(object obj)
	{
		if (obj != null && obj is Room)
		{
			Room room = (Room)obj;
			if (coordinates.Count != room.coordinates.Count)
			{
				return false;
			}
			foreach (Coordinate c in coordinates)
			{
				if (!room.HasCoordinate(c))
				{
					return false;
				}
			}
			if (type != room.type)
			{
				return false;
			}
			return true;
		}
		return false;
	}

	public override int GetHashCode()
	{
		// x.equals(y) => x.getHashCode() == y.getHashCode()
		// but not (necessarily) vice versa, i.e. equal hash codes don't imply equality.
		//int hashCode = 0;
		//for (int i = 0; i < this.type.Length; i++)
		//{
		//	hashCode += (int)type[i];
		//}
		//hashCode += this.coordinates.Count;
		//return hashCode;

		// the <Room, weight> dictionary requires every room to have a unique hashCode. Therefore, just implement the base method to get rid of the build warning.
		return base.GetHashCode();
	}

	public override string ToString()
	{
		String s = "";
		s += "Type=" + type + "//";
		foreach (Coordinate c in coordinates)
		{
			s += c;
		}
		return s;
	}

}