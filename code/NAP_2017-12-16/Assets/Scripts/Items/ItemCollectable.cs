using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectable : MonoBehaviour {



    private AbstractItems item;
    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        //Remove the following two lines after implementing Item generation
        AbstractItems newItem = gameObject.AddComponent<ItemKey>();
        setItem(newItem);
    }

    public AbstractItems GetItem()
    {
        return item;
    }

    public void setItem(AbstractItems item)
    {
        this.item = item;
        spriteRenderer.sprite = item.itemSprite;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        other.GetComponent<InventoryController>().AddItemToInventory(item);
        Destroy(gameObject);
    }
}
