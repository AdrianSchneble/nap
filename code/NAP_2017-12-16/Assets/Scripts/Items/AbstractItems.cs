using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractItems : MonoBehaviour  {

    public int rarity;

    public string description;

    public Sprite itemSprite;

    public abstract void ItemAction(GameObject gameObject);
}
