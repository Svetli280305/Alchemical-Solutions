using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem : MonoBehaviour
{
    public ItemData itemData;
    public int stackSize;

    public InventoryItem(ItemData item)
    {
        itemData = item;
    }

    public void AddToStack()
    {
        stackSize++;
    }

    public void RemoveFromStack()
    {
        stackSize--;
    }
}
