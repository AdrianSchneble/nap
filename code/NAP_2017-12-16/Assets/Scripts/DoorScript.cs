using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{

    public Sprite openSprite;
    public Sprite closedSprite;
    public BoxCollider2D doorCollider;
    public Room room;
    private SpriteRenderer spriteRenderer;
    private bool closed = true;
    private int trigger = 0;
    private InventoryController playerInventory;


    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            trigger++;
            playerInventory = collision.GetComponent<InventoryController>();
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            trigger--;
            if (trigger == 0)
            {
                playerInventory = null;
            }
        }
    }

    void Update()
    {
        if (Input.GetKeyDown("e") && trigger == 1)
        {
            if (closed)
            {
                if (room != null && room.type == Room.LOCKED)
                {
                    if (playerInventory.hasItem(typeof(ItemKey)))
                    {
                        playerInventory.RemoveItemFromInventory(typeof(ItemKey));
                        room.type = Room.DEFAULT;
                        openDoor();
                    }
                    else
                    {
                        //TODO: Implement Message (Door is locked). 
                    }
                }
                else
                {
                    openDoor();
                }
            }
            else
            {
                //Close door
                spriteRenderer.sprite = closedSprite;
                doorCollider.enabled = true;
                closed = true;
            }
        }
    }

    private void openDoor()
    {
        spriteRenderer.sprite = openSprite;
        doorCollider.enabled = false;
        closed = false;
    }
}



