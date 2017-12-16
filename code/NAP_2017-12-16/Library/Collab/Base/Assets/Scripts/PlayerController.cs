using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed = 0.1f;
    public int roomSize = 20;
    public GameObject groundTile;
    public GameObject wallTile;
    public GameObject doorTile;

	// Use this for initialization
	void Start () {
        for (int multipleRooms = 0; multipleRooms < 2; multipleRooms++)
        {
            int offset = multipleRooms * (roomSize - 1);    //TODO: this is prototyping shit. Don't leave it like this!
		    for (int column = 0; column < roomSize; column++)
            {
                int lastTileIndex = roomSize - 1;
                for (int row = 0; row < roomSize; row++)
                {
                    int doorTileNum = (roomSize % 2 == 0) ? -1 : (roomSize - 1) / 2;
                    bool isDoor = row == doorTileNum || column == doorTileNum; //TODO
                    bool isWall = column == 0 || column == lastTileIndex || row == 0 || row == lastTileIndex;

                    if (isWall && isDoor)
                    {
                        Instantiate(doorTile, new Vector3(column - 5 + offset, row - 5, 1), new Quaternion());
                    }
                    else if (isWall)
                    {
                        Instantiate(wallTile, new Vector3(column - 5 + offset, row - 5, 1), new Quaternion());
                    }
                    else // is ground
                    {
                        Instantiate(groundTile, new Vector3(column - 5 + offset, row - 5, 1), new Quaternion());
                    }
                }
            }
        }

	}
	
	// Update is called once per frame
	void Update () {

        float x = Input.GetAxis("Horizontal") * speed;
        float y = Input.GetAxis("Vertical") * speed;

        transform.Translate(new Vector3(x, y));
	}
}
