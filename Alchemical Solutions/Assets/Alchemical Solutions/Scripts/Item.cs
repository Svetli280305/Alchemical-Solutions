using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public enum ItemType
    {
        HeatPotion,
        FrostPotion,
        PoisonPotion,
    }

    public ItemType itemType;
    public int amount;
}
