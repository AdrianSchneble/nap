using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusEffectController : MonoBehaviour {

    public List<StatusEffectCombination> statusEffects = new List<StatusEffectCombination>();
    private bool crRunning = false;

    public void addStatusEffect(StatusEffectCombination statusEffect)
    {
        foreach (StatusEffectCombination existingEffect in statusEffects)
        {
            if(existingEffect.effect.GetType() == statusEffect.effect.GetType())
            {
                if(existingEffect.duration < statusEffect.duration)
                {
                    existingEffect.duration = statusEffect.duration;
                }
                
                return;
            }
        }
        statusEffects.Add(statusEffect);
        statusEffect.effect.statusEffectStart(this.gameObject);
        if(!crRunning)
        {
            StartCoroutine("EffectTick");
            crRunning = true;
        }
    }

    private IEnumerator EffectTick()
    {
        List<StatusEffectCombination> deleteList = new List<StatusEffectCombination>();
        while (true)
        {
            foreach (StatusEffectCombination statusEffect in statusEffects)
            {
                statusEffect.effect.DoStatusEffectTick(this.gameObject);
                statusEffect.duration--;
                if(statusEffect.duration <= 0)
                {
                    deleteList.Add(statusEffect);
                    statusEffect.effect.statusEffectEnd(this.gameObject);
                }
            }
            //This is ugly, but is neccesary to avoid invalidOperationExpeptions -_-
            foreach (StatusEffectCombination statusEffect in deleteList)
            {
                statusEffects.Remove(statusEffect);
                if (statusEffects.Count == 0)
                {
                    StopCoroutine("EffectTick");
                    crRunning = false;
                }
            }
            deleteList.Clear();
            yield return new WaitForSeconds(1);
        }
    }
}

public class StatusEffectCombination
{
    public IStatusEffect effect;
    public int duration;

    public StatusEffectCombination(IStatusEffect effect, int duration)
    {
        this.effect = effect;
        this.duration = duration;
    }
}
