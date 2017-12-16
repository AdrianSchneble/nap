using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class GenerationTest {

	[Test]
	public void GenerationTestSimplePasses() {
		// Use the Assert class to test conditions.
	}

    [Test]
    public void ExpectIsAdjacentToFunctionCorrectly()
    {
        Assert.IsTrue(new Coordinate(0, 1).IsAdjacent(new Coordinate(0, 0)) != Coordinate.NOT_ADJACENT);
    }

    [Test]
    public void ExpectNorthAdjacentCoordinatesToBeRecognizedCorrectly()
    {
        Assert.IsTrue(new Coordinate(0,0).IsAdjacent(new Coordinate(0, 1)) == Coordinate.NORTH);
    }

    [Test]
    public void ExpectSouthAdjacentCoordinatesToBeRecognizedCorrectly()
    {
        Assert.IsTrue(new Coordinate(0, 0).IsAdjacent(new Coordinate(0, -1)) == Coordinate.SOUTH);
    }

    [Test]
    public void ExpectEastAdjacentCoordinatesToBeRecognizedCorrectly()
    {
        Assert.IsTrue(new Coordinate(0, 0).IsAdjacent(new Coordinate(1,0)) == Coordinate.EAST);
    }

    [Test]
    public void ExpectWestAdjacentCoordinatesToBeRecognizedCorrectly()
    {
        Assert.IsTrue(new Coordinate(0, 0).IsAdjacent(new Coordinate(-1, 0)) == Coordinate.WEST);
    }

}
