using System;
using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;

public class TileTest
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
		GameObject g = new GameObject();
		Tile t1 = new Tile(-1, 3, g);
		Tile t2 = new Tile(-1, 3, g);
		Tile t3 = new Tile(-1, 3, g);

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
		Tile c1 = new Tile(7, -3, g);
		Tile c2 = new Tile(6, -4, g);
		Assert.AreNotEqual(c1, c2);
	}
}
