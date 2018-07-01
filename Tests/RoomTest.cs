using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class RoomTest
{

	[Test]
	public void ExpectHasCoordinateToReturnTrueAsIntendedWhenCallingOnA1X1Room()
	{
		//using random, not 0 or 1 values
		int x = 5;
		int y = 7;
		Room room = new Room(new Coordinate(x, y));

		Assert.That(room.HasCoordinate(new Coordinate(x, y)) == true);
	}

	[Test]
	public void ExpectHasCoordinateToReturnFalseAsIntendedWhenCallingOnA1X1Room()
	{
		//using random, not 0 or 1 values
		int x = 9;
		int y = -4;
		Room room = new Room(new Coordinate(x, y));

		Assert.That(room.HasCoordinate(new Coordinate(x + 1, y)) == false);
		Assert.That(room.HasCoordinate(new Coordinate(x, y + 1)) == false);
		Assert.That(room.HasCoordinate(new Coordinate(x - 1, y)) == false);
		Assert.That(room.HasCoordinate(new Coordinate(x, y - 1)) == false);
	}

	[Test]
	public void ExpectGetTopLeftCoordinateInSquareRoomToWorkAsIntended()
	{
		Room r = new Room(new Coordinate(0, 0), new Coordinate(1, 0), new Coordinate(0, -1), new Coordinate(1, -1));
		Coordinate topLeft = r.GetTopLeftCoordinate();

		Assert.That(topLeft.Equals(new Coordinate(0, 0)));
	}
}
