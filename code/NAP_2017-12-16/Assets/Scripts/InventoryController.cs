using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour {

    public List<InventoryEntry> inventoryContents = new List<InventoryEntry>();

    public void AddItemToInventory(AbstractItems item)
    {
        foreach(InventoryEntry entry in inventoryContents)
        {
            if(item.GetType() == entry.item.GetType())
            {
                entry.amount++;
                Debug.Log("Increased Amount");
                return;
            }
        }
        inventoryContents.Add(new InventoryEntry(1, item));
        Debug.Log("Added" + item.name + "to Inventory");
    }

    public void RemoveItemFromInventory(System.Type type)
    {
        foreach(InventoryEntry entry in inventoryContents)
        {
            if(type == entry.item.GetType())
            {
                if(entry.amount > 1)
                {
                    entry.amount--;
                    return;
                }
                if(entry.amount <= 1)
                {
                    inventoryContents.Remove(entry);
                    return;
                }
            }
        }
    }

    public bool hasItem(System.Type type)
    {
        foreach (InventoryEntry entry in inventoryContents)
        {
            if (type == entry.item.GetType())
            {
                return true;
            }
        }
        return false;
    }

    public List<InventoryEntry> GetInventoryContents()
    {
        return inventoryContents;
    }
}

public class InventoryEntry
{
    public InventoryEntry(int amount, AbstractItems item)
    {
        this.amount = amount;
        this.item = item;
    }
    public int amount;

    public AbstractItems item;

}
