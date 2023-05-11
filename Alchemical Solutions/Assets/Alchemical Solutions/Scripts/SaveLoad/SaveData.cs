using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData
{
    public List<string> collectedItems;
    public SerializableDictionary<string, InventorySaveData> chestDictionary;
    public SerializableDictionary<string, ItemPickupSaveData> activeItems;
    public SerializableDictionary<string, ShopSaveData> _shopKeeperDictionary;
    public InventorySaveData playerInventory;
    public SaveData()
    {
        collectedItems = new List<string>();
        activeItems = new SerializableDictionary<string, ItemPickupSaveData>();
        chestDictionary = new SerializableDictionary<string, InventorySaveData>();
        playerInventory = new InventorySaveData();
        _shopKeeperDictionary = new SerializableDictionary<string, ShopSaveData>();
    }
}
