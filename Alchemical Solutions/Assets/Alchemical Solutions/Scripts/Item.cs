using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class Item
{
    public enum ItemType
    {
        HeatPotion,
        FrostPotion,
        PoisonPotion,
        Trimmers,
    }

    public ItemType itemType;
    public int amount;

    public Sprite GetSprite()
    {
        switch (itemType)
        {
            default:
            case ItemType.FrostPotion: return ItemAssets.Instance.frostPotionSprite;
            case ItemType.HeatPotion: return ItemAssets.Instance.heatPotionSprite;
            case ItemType.PoisonPotion: return ItemAssets.Instance.poisonPotionSprite;
        }
    }

    public bool IsStackable()
    {
        switch (itemType)
        {
            default:
            case ItemType.HeatPotion:
            case ItemType.FrostPotion:
            case ItemType.PoisonPotion:
                return true;
        }
    }
}
