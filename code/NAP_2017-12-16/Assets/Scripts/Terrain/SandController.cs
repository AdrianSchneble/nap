using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandController : TerrainController 
{
    private void Awake()
    {
        canHoldObstacle = true;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Unit" && !(other.gameObject.GetComponent<PlayerController>().slowedDown))
        {
            other.gameObject.GetComponent<PlayerController>().speed = other.gameObject.GetComponent<PlayerController>().speed / 2;
            other.gameObject.GetComponent<PlayerController>().slowedDown = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Unit" && other.gameObject.GetComponent<PlayerController>().slowedDown)
        {
            other.gameObject.GetComponent<PlayerController>().speed = (other.gameObject.GetComponent<PlayerController>().speed * 2);
            other.gameObject.GetComponent<PlayerController>().slowedDown = false;
        }
    }
}
