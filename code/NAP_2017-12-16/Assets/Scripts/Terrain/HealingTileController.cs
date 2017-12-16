using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingTileController : TerrainController {

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
            int maxHp = other.gameObject.GetComponent<PlayerController>().maxHp;
            if(other.gameObject.GetComponent<PlayerController>().hp < maxHp)
            {
            other.gameObject.GetComponent<PlayerController>().hp = maxHp;
            spriteRenderer.sprite = disabledSprite;
            active = false;
            }
        }
    }

}

