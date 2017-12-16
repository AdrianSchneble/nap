using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapController : TerrainController {

    public Sprite activatedSprite;
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
            other.gameObject.GetComponent<PlayerController>().hp = other.gameObject.GetComponent<PlayerController>().hp - 3;
            spriteRenderer.sprite = activatedSprite;
            active = false;
            canHoldObstacle = false;
        }
    }
}
