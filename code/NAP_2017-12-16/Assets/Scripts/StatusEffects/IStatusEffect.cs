using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStatusEffect 
    {
     void DoStatusEffectTick(GameObject gameObject);
     void statusEffectStart(GameObject gameObject);
     void statusEffectEnd(GameObject gameObject);
     bool IsDebuff();
	
    }
