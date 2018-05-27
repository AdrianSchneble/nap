using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Generation
{
	public class TileFactory : MonoBehaviour
	{
		public static GameObject LoadGroundTile()
		{
			return GameObjectCache.Load("Dungeon/GroundTile");
		}

		public static GameObject LoadWallTile()
		{
			return GameObjectCache.Load("Dungeon/WallTile");
		}

		public static GameObject LoadDoorTile()
		{
			return GameObjectCache.Load("Dungeon/DoorTile");
		}

		public static GameObject LoadLockedDoorTile()
		{
			return GameObjectCache.Load("Dungeon/LockedDoorTile");
		}

		public static GameObject LoadGateTile()
		{
			return GameObjectCache.Load("Dungeon/GateTile");
		}

		public static GameObject LoadLavaTile()
		{
			return GameObjectCache.Load("Terrain/LavaTile");
		}

		public static GameObject LoadSandTile()
		{
			return GameObjectCache.Load("Terrain/SandTile");
		}

		public static GameObject LoadAcceleratorTile()
		{
			return GameObjectCache.Load("Terrain/AcceleratorTile");
		}

		public static GameObject LoadBarrel()
		{
			return GameObjectCache.Load("Obstacles/Barrel");
		}

		public static Tile CreateGroundTile(Coordinate coordinate, Column x, Row y, int coordinateTileCount)
		{
			return new Tile(coordinate, x, y, coordinateTileCount, LoadGroundTile(), new LockState(false));
		}

		public static Tile CreateWallTile(Coordinate coordinate, Column x, Row y, int coordinateTileCount)
		{
			return new Tile(coordinate, x, y, coordinateTileCount, LoadWallTile(), new LockState(false));
		}

		public static Tile CreateDoorTile(Coordinate coordinate, Column x, Row y, int coordinateTileCount,
			LockState lockState)
		{
			Tile doorTile = new Tile(coordinate, x, y, coordinateTileCount, LoadDoorTile(), lockState);
			return doorTile;
		}

		public static Tile CreateBarrel(Coordinate coordinate, Column x, Row y, int coordinateTileCount)
		{
			return new Tile(coordinate, x, y, coordinateTileCount, LoadBarrel(), new LockState(false));
		}
	}
}