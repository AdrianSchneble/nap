using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;

public class CoordinateTest
{

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
        Coordinate c1 = new Coordinate(4, -2);
        Coordinate c2 = new Coordinate(4, -2);
        Coordinate c3 = new Coordinate(4, -2);

        Assert.IsTrue(c1.Equals(c1));
        Assert.That(c1.Equals(c2) == c2.Equals(c1));
        if (c1.Equals(c3) == true)
        {
            Assert.IsTrue(c1.Equals(c2) && c2.Equals(c3));
        }
        else
        {
            Assert.IsFalse(c1.Equals(c2) && c2.Equals(c3));
        }
        // successive invocations can't really be tested reliably!
        Assert.IsFalse(c1.Equals(null));
    }

    [Test]
    public void ExpectFalseWhenNotEqual()
    {
        Coordinate c1 = new Coordinate(4, -2);
        Coordinate c2 = new Coordinate(5, -2);
        Assert.AreNotEqual(c1, c2);
    }

	[Test]
	public void ExpectGetSurroundingCoordinatesToReturn4Values()
	{
		Coordinate c = new Coordinate(3, 7);
		List<Coordinate> list = c.GetSurroundingCoordinates();

		Assert.That(list.Count.Equals(4));
	}
}
