using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcceleratorController : TerrainController {

    public Sprite disabledSprite;
    private bool active = true;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        canHoldObstacle = true;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Unit" && active)
        {
            active = false;
            spriteRenderer.sprite = disabledSprite;
            other.gameObject.GetComponent<StatusEffectController>().addStatusEffect(new StatusEffectCombination(new SEAccelerated(), 5));
        }
    }

}

