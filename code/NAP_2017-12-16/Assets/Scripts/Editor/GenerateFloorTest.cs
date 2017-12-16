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
		GenerationScript script = new GenerationScript();
		List<Room> rooms = script.GenerateFloor(10);
		int startingRoomCount = 0;
		foreach (Room room in rooms)
		{
			if (room.type == Room.START)
			{
				startingRoomCount++;
			}
		}
		Assert.That(startingRoomCount == 1);
	}

	[Test]
	public void ExpectReturnedListToContainExactlyOneEndRoom()
	{
		GenerationScript script = new GenerationScript();
		List<Room> rooms = script.GenerateFloor(10);
		int endRoomCount = 0;
		foreach (Room room in rooms)
		{
			if (room.type == Room.END)
			{
				endRoomCount++;
			}
		}
		Assert.That(endRoomCount == 1);
	}

	[Test]
	public void ExpectCalculateNewSurroundingsToCalculateCorrectlyWhenGivenTheStartingRoom()
	{
		GenerationScript script = new GenerationScript();
		List<Coordinate> possibleLocations = new List<Coordinate>();
		List<Room> floor = new List<Room>();
		Room newRoom = new Room(Room.START, new Coordinate(0, 0));

		int maxRoomCount = 10;
		script.CalculateNewSurroundings(possibleLocations, floor, newRoom, maxRoomCount);

		Assert.Contains(new Coordinate(0, 1), possibleLocations);
		Assert.Contains(new Coordinate(0, -1), possibleLocations);
		Assert.Contains(new Coordinate(1, 0), possibleLocations);
		Assert.Contains(new Coordinate(-1, 0), possibleLocations);
	}

	[Test]
	public void ExpectCalculateNewSurroundingToCalculateCorrectlyWithOneExistingRoom()
	{
		GenerationScript script = new GenerationScript();
		List<Coordinate> possibleLocations = new List<Coordinate>();
		List<Room> floor = new List<Room>();
		Room newRoom = new Room(Room.START, new Coordinate(0, 0));

		int maxRoomCount = 10;
		script.CalculateNewSurroundings(possibleLocations, floor, newRoom, maxRoomCount);

		Assert.Contains(new Coordinate(0, 1), possibleLocations);
		Assert.Contains(new Coordinate(0, -1), possibleLocations);
		Assert.Contains(new Coordinate(1, 0), possibleLocations);
		Assert.Contains(new Coordinate(-1, 0), possibleLocations);
	}

}
