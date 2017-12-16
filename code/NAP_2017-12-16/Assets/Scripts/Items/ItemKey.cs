using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemKey : AbstractItems
{
    void Awake()
    {
        name = "Key";
        description = "Generic key used to open doors";
        rarity = ItemRarity.COMMON;
    }

    public override void ItemAction(GameObject gameObject)
    {
        //No action, unlocking handled by door;
    }
}
