using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

public class GenerateFloorTest
{
	
	[Test]
	public void ExpectReturnedListToContainExactlyOneStartingRoom()
	{
		FloorGenerator generator = new FloorGenerator(10);
		generator.GenerateFloorLayout();
		int startingRoomCount = 0;
		foreach (Room room in generator.GetFloor())
		{
			if (room.type == Room.START)
			{
				startingRoomCount++;
			}
		}
		Assert.AreEqual(1, startingRoomCount);
	}

	[Test]
	public void ExpectReturnedListToContainExactlyOneEndRoom()
	{
		FloorGenerator generator = new FloorGenerator(10);
		generator.GenerateFloorLayout();
		int endRoomCount = 0;
		foreach (Room room in generator.GetFloor())
		{
			if (room.type == Room.END)
			{
				endRoomCount++;
			}
		}
		Assert.AreEqual(1, endRoomCount);
	}

	[Test]
	public void ExpectCalculateNewSurroundingsToCalculateCorrectlyWhenGivenTheStartingRoom()
	{
		FloorGenerator generator = new FloorGenerator(10);
		Room newRoom = new Room(Room.START, new Coordinate(0, 0));

		generator.CalculateNewSurroundings(newRoom);
		List<Coordinate> possibleLocations = generator.GetPossibleLocations();

		Assert.Contains(new Coordinate(0, 1), possibleLocations);
		Assert.Contains(new Coordinate(0, -1), possibleLocations);
		Assert.Contains(new Coordinate(1, 0), possibleLocations);
		Assert.Contains(new Coordinate(-1, 0), possibleLocations);
	}

	[Test]
	public void ExpectCalculateNewSurroundingToCalculateCorrectlyWithOneExistingRoom()
	{
		FloorGenerator generator = new FloorGenerator(10);
		Room newRoom = new Room(Room.START, new Coordinate(0, 0));
		
		generator.CalculateNewSurroundings(newRoom);
		List<Coordinate> possibleLocations = generator.GetPossibleLocations();

		Assert.Contains(new Coordinate(0, 1), possibleLocations);
		Assert.Contains(new Coordinate(0, -1), possibleLocations);
		Assert.Contains(new Coordinate(1, 0), possibleLocations);
		Assert.Contains(new Coordinate(-1, 0), possibleLocations);
	}

	[Test]
	public void ExpectIsAdjacentToFunctionCorrectly()
	{
		Assert.IsTrue(new Coordinate(0, 1).IsAdjacent(new Coordinate(0, 0)));
	}

}
