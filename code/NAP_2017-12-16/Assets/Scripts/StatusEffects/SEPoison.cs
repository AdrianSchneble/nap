using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEPoison : IStatusEffect
{
    public void DoStatusEffectTick(GameObject gameObject)
    {
            gameObject.GetComponent<PlayerController>().hp = gameObject.GetComponent<PlayerController>().hp - 1;
    }

    public bool IsDebuff()
    {
        return true;
    }

    public void statusEffectEnd(GameObject gameObject)
    {
        //Persistant Status Effect, does nothing on End
    }

    public void statusEffectStart(GameObject gameObject)
    {
        //Persistant Status Effect, does nothing on start
    }
}
