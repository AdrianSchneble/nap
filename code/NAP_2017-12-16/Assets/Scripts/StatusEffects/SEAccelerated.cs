using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEAccelerated : IStatusEffect {

    float speed; 

    public void DoStatusEffectTick(GameObject gameObject)
    {
        //Does nothing on Tick
    }

    public bool IsDebuff()
    {
        return false;
    }

    public void statusEffectEnd(GameObject gameObject)
    {
        gameObject.GetComponent<PlayerController>().speed = speed;
    }

    public void statusEffectStart(GameObject gameObject)
    {
        speed = gameObject.GetComponent<PlayerController>().speed;
        gameObject.GetComponent<PlayerController>().speed = speed * 1.5f;
    }
}
