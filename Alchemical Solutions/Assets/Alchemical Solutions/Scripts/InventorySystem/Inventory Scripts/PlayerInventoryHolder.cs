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
        dialogueRunner.AddFunction("testong",
        delegate (string itemName)
        {
            Debug.Log("sewy");
            return checkForItem(itemName);
        }
    );
    }

    protected override void LoadInventory(SaveData data)
    {
        // check save data for this chests specific inventory and load it in
        if (data.playerInventory.invSystem != null)
        {
            Debug.Log("Data to load.");
            this.primaryInventorySystem = data.playerInventory.invSystem;
            OnPlayerInventoryChanged?.Invoke();
        }
    }

    private void OnDestroy()
    {

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
        Debug.Log("Ran.");
        Debug.Log(primaryInventorySystem.ContainsItem(itemmDB.GetItem(item)));
        var containsI = primaryInventorySystem.ContainsItem(itemmDB.GetItem(item));
        Debug.Log(containsI);
        return containsI;
    }

    
}
