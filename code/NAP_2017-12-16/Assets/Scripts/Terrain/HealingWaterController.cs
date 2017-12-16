using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingWaterController : TerrainController
{

    private ArrayList unitsOnField = new ArrayList();
    private bool crRunning = false;

    private void Awake()
    {
        canHoldObstacle = false;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Unit")
        {
            unitsOnField.Add(other.gameObject);
            if (!crRunning)
            {
                StartCoroutine("HealTick");
                crRunning = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Unit")
        {
            unitsOnField.Remove(other.gameObject);
            if (unitsOnField.Count == 0)
            {
                StopCoroutine("HealTick");
                crRunning = false;
            }
            if (other.gameObject.GetComponent<PlayerController>().slowedDown)
            {
                other.gameObject.GetComponent<PlayerController>().speed = (other.gameObject.GetComponent<PlayerController>().speed * 2);
                other.gameObject.GetComponent<PlayerController>().slowedDown = false;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Unit" && !(other.gameObject.GetComponent<PlayerController>().slowedDown))
        {
            other.gameObject.GetComponent<PlayerController>().speed = other.gameObject.GetComponent<PlayerController>().speed / 2;
            other.gameObject.GetComponent<PlayerController>().slowedDown = true;
        }
    }

    private IEnumerator HealTick()
    {
        while (true)
        {
            foreach (GameObject gameObject in unitsOnField)
            {
                if (gameObject.GetComponent<PlayerController>().hp < gameObject.GetComponent<PlayerController>().maxHp)
                    gameObject.GetComponent<PlayerController>().hp = gameObject.GetComponent<PlayerController>().hp + 1;
            }
            yield return new WaitForSeconds(5);
        }
    }
}
