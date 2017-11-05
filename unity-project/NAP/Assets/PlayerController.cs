using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private static float speed = 0.5f;
    public GameObject groundTile;
    public GameObject wallTile;
    public GameObject doorTile;

	// Use this for initialization
	void Start () {

		for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                if (i == 0)
                {
                    Instantiate(wallTile, new Vector3(i * 0.25f - 5, j * 0.25f - 5, 1), new Quaternion());
                    continue;
                }

                if (i == 9)
                {
                    Instantiate(wallTile, new Vector3(i * 0.25f - 5, j * 0.25f - 5, 1), new Quaternion());
                    continue;
                }

                if (j == 0)
                {
                    Instantiate(wallTile, new Vector3(i * 0.25f - 5, j * 0.25f - 5, 1), new Quaternion());
                    continue;
                }

                if (j == 9)
                {
                    Instantiate(wallTile, new Vector3(i * 0.25f - 5, j * 0.25f - 5, 1), new Quaternion());
                    continue;
                }

                Instantiate(groundTile, new Vector3(i * 0.25f - 5, j*0.25f - 5, 1), new Quaternion());
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
