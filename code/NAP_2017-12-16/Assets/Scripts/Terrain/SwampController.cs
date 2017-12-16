using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwampController : TerrainController {

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
                StartCoroutine("LavaTick");
                crRunning = true;
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

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Unit")
        {
            unitsOnField.Remove(other.gameObject);
            if (unitsOnField.Count == 0)
            {
                StopCoroutine("LavaTick");
                crRunning = false;
            }
            if (other.gameObject.GetComponent<PlayerController>().slowedDown)
            {
                other.gameObject.GetComponent<PlayerController>().speed = (other.gameObject.GetComponent<PlayerController>().speed * 2);
                other.gameObject.GetComponent<PlayerController>().slowedDown = false;
            }
        }
    }

    private IEnumerator LavaTick()
    {
        while (true)
        {
            foreach (GameObject gameObject in unitsOnField)
            {
                gameObject.GetComponent<StatusEffectController>().addStatusEffect(new StatusEffectCombination(new SEPoison(), 5));
            }
            yield return new WaitForSeconds(1);
        }
    }
}

