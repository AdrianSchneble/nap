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
		GenerationScript script = new GenerationScript(10);
		script.GenerateFloor();
		int startingRoomCount = 0;
		foreach (Room room in script.GetFloor())
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
		GenerationScript script = new GenerationScript(10);
		script.GenerateFloor();
		int endRoomCount = 0;
		foreach (Room room in script.GetFloor())
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
		GenerationScript script = new GenerationScript(10);
		Room newRoom = new Room(Room.START, new Coordinate(0, 0));

		script.CalculateNewSurroundings(newRoom);
		List<Coordinate> possibleLocations = script.GetPossibleLocations();

		Assert.Contains(new Coordinate(0, 1), possibleLocations);
		Assert.Contains(new Coordinate(0, -1), possibleLocations);
		Assert.Contains(new Coordinate(1, 0), possibleLocations);
		Assert.Contains(new Coordinate(-1, 0), possibleLocations);
	}

	[Test]
	public void ExpectCalculateNewSurroundingToCalculateCorrectlyWithOneExistingRoom()
	{
		GenerationScript script = new GenerationScript(10);
		Room newRoom = new Room(Room.START, new Coordinate(0, 0));
		
		script.CalculateNewSurroundings(newRoom);
		List<Coordinate> possibleLocations = script.GetPossibleLocations();

		Assert.Contains(new Coordinate(0, 1), possibleLocations);
		Assert.Contains(new Coordinate(0, -1), possibleLocations);
		Assert.Contains(new Coordinate(1, 0), possibleLocations);
		Assert.Contains(new Coordinate(-1, 0), possibleLocations);
	}

}
