using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using Yarn.Unity;

public class PlayerInventoryHolder : InventoryHolder
{

    public static UnityAction OnPlayerInventoryChanged;

    public static UnityAction<InventorySystem, int> OnPlayerInventoryDisplayRequested;

    private void Start()
    {
        SaveLoad.onLoadGame += LoadInventory;
        SaveGameManager.data.playerInventory = new InventorySaveData(primaryInventorySystem);
    }
    protected override void LoadInventory(SaveData data)
    {
        // check save data for this chests specific inventory and load it in
        if (data.playerInventory.invSystem != null)
        {
            this.primaryInventorySystem = data.playerInventory.invSystem;
            OnPlayerInventoryChanged?.Invoke();
        }
    }

    private void OnDestroy()
    {
        SaveGameManager.SaveData();
    }

    private void Update()
    {
        if (Keyboard.current.iKey.wasPressedThisFrame) OnPlayerInventoryDisplayRequested?.Invoke(primaryInventorySystem, offset);
    }

    public bool AddToInventory(InventoryItemData data, int amount)
    {
        if (primaryInventorySystem.AddToInventory(data, amount))
        {
            return true;
        }

        return false;
    }

    public bool checkForItem(string item)
    {
        var containsI = primaryInventorySystem.ContainsItem(GameManager.itemDB.GetItem(item));
        return containsI;
    }
}
