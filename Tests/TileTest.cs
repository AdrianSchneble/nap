using System;
using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;

public class TileTest
{
	private static int arbitraryCoordinateTileCount = 5;
	/* test whether Coordinate.Equals fulfills the official requirements as specified in:
    https://msdn.microsoft.com/en-gb/library/336aedhh(v=vs.100).aspx
    For better overview, here's a copy-and-pasted extract:

        x.Equals(x) returns true.
        x.Equals(y) returns the same value as y.Equals(x).
        (x.Equals(y) && y.Equals(z)) returns true if and only if x.Equals(z) returns true.
        Successive invocations of x.Equals(y) return the same value as long as the objects referenced by x and y are not modified.
        x.Equals(null) returns false.
    */
	[Test]
	public void ExpectEqualsToFulfillOfficialRequirements()
	{
		//TODO false cases haven't really been checked
		GameObject g = new GameObject();
		Coordinate coordinate = new Coordinate(0, 0);
		Tile t1 = new Tile(coordinate, new Column(-1), new Row(3), arbitraryCoordinateTileCount, g);
		Tile t2 = new Tile(coordinate, new Column(-1), new Row(3), arbitraryCoordinateTileCount, g);
		Tile t3 = new Tile(coordinate, new Column(-1), new Row(3), arbitraryCoordinateTileCount, g);

		Assert.IsTrue(t1.Equals(t1));
		Assert.That(t1.Equals(t2) == t2.Equals(t1));
		if (t1.Equals(t3) == true)
		{
			Assert.IsTrue(t1.Equals(t2) && t2.Equals(t3));
		}
		else
		{
			Assert.IsFalse(t1.Equals(t2) && t2.Equals(t3));
		}
		// successive invocations can't really be tested reliably!
		Assert.IsFalse(t1.Equals(null));
	}

	[Test]
	public void ExpectFalseWhenNotEqual()
	{
		GameObject g = new GameObject();
		Coordinate coordinate = new Coordinate(0, 0);
		Tile c1 = new Tile(coordinate, new Column(7), new Row(-3), arbitraryCoordinateTileCount, g);
		Tile c2 = new Tile(coordinate, new Column(6), new Row(-4), arbitraryCoordinateTileCount, g);
		Assert.AreNotEqual(c1, c2);
	}

	[Test]
	public void IsPossibleDoorLocationsCalculatesCorrectly()
	{
		Coordinate coordinate = new Coordinate(0, 0);
		/*for (int column = 0; column < arbitraryCoordinateTileCount; column++)
		{
			for (int row = 0; row < arbitraryCoordinateTileCount; row++)
			{
				Tile tile = new Tile(coordinate, new Column(column), new Row(row), null);
			}
		}*/
		var room1 = new Room(coordinate);
		var room2 = new Room(coordinate.West());
		List<Room> rooms = new List<Room>
		{
			room1,
			room2
		};
		room1.GenerateTiles(arbitraryCoordinateTileCount, rooms);
		room2.GenerateTiles(arbitraryCoordinateTileCount, rooms);
		var possibleDoorLocations = Room.GetPossibleDoorLocations(arbitraryCoordinateTileCount, rooms);
		
		Column column = new Column(Room.CalculateDoorTileNum(arbitraryCoordinateTileCount));
		Row row = new Row(-1);
		Tile tile = new Tile(coordinate, column, row, arbitraryCoordinateTileCount, null);
		
		Assert.True(tile.IsPossibleDoorLocation());

		Assert.True(possibleDoorLocations.Contains(tile));
	}

	[Test]
	public void TilesFromDifferentCoordinatesCanStillBeEqual()
	{
		var doorTileNum = Room.CalculateDoorTileNum(arbitraryCoordinateTileCount);
		var coordinate = new Coordinate(0, 0);
		Tile tileLeft = new Tile(coordinate, new Column(arbitraryCoordinateTileCount), new Row(doorTileNum), arbitraryCoordinateTileCount, null);
		Tile tileRight = new Tile(coordinate.East(), new Column(-1), new Row(doorTileNum), arbitraryCoordinateTileCount, null);
		Assert.AreEqual(tileLeft, tileRight);
		Assert.AreEqual(tileRight, tileLeft);

		Tile tileTop = new Tile(coordinate, new Column(doorTileNum), new Row(-1), arbitraryCoordinateTileCount, null);
		Tile tileBottom = new Tile(coordinate.South(), new Column(doorTileNum), new Row(arbitraryCoordinateTileCount), arbitraryCoordinateTileCount, null);
		Assert.AreEqual(tileTop, tileBottom);
		Assert.AreEqual(tileBottom, tileTop);
	}
}