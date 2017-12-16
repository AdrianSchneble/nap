using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySlotController : MonoBehaviour {

    public AbstractItems item;

    public void SetItem(AbstractItems item)
    {
        this.item = item;
    }
}
