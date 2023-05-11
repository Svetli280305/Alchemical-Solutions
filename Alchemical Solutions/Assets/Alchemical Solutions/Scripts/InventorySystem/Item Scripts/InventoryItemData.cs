using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Inventory System/Inventory Item")]
public class InventoryItemData : ScriptableObject
{
    public int ID = -1;
    public string displayName;
    public string dbReference;
    [TextArea(4, 4)]
    public string description;
    public Sprite icon;
    public int maxStackSize;
    public GameObject itemGO;
    public bool isDroppable;
    public int value;
}
