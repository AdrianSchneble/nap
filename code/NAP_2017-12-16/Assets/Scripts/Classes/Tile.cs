using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Tile
{
	private int x;
	private int y;
	private GameObject gObject;

	public Tile(int x, int y, GameObject gObject)
	{
		this.x = x;
		this.y = y;
		this.gObject = gObject;
	}

	public int getX()
	{
		return x;
	}

	public int getY()
	{
		return y;
	}

	public GameObject getObject()
	{
		return gObject;
	}

	public override bool Equals(object obj)
	{
		if (obj != null && obj is Tile)
		{
			Tile other = (Tile) obj;
			if (other.x == x && other.y == y && (other.gObject == gObject || gObject == null || other.gObject == null))
			{
				return true;
			}
		}
		return false;
	}

	public override int GetHashCode()
	{
		return x + y;
	}

	public void setObject(GameObject o)
	{
		this.gObject = o;
	}
}
