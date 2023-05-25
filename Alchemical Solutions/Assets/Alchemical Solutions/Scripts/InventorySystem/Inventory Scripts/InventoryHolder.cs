using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Yarn.Unity;

[System.Serializable]
public abstract class InventoryHolder : MonoBehaviour
{
    [SerializeField] private int inventorySize;
    [SerializeField] protected InventorySystem primaryInventorySystem;
    [SerializeField] protected int offset = 10;
    [SerializeField] protected int _gold;
    [SerializeField] protected DialogueRunner dialogueRunner;
    [SerializeField] protected Database itemmDB;
    
    public int Offset => offset;

    public InventorySystem PrimaryInventorySystem => primaryInventorySystem;

    public DialogueRunner DialogueRunner => dialogueRunner;

    public Database ItemmDB => itemmDB;

    public static UnityAction<InventorySystem, int> OnDynamicInventoryDisplayRequested; // inv system to display, amount to offset dispaly by

    protected virtual void Awake()
    {
        SaveLoad.onLoadGame += LoadInventory;

        primaryInventorySystem = new InventorySystem(inventorySize, _gold);

        dialogueRunner.AddFunction("checkItem",
            delegate (string testingstring)
            {
                return primaryInventorySystem.ContainsItem(itemmDB.GetItem(testingstring));
            }
        );
        dialogueRunner.AddFunction("checkItems",
            delegate (string testingstring, int amountToCheck)
            {
                primaryInventorySystem.ContainsItem(itemmDB.GetItem(testingstring), out List<InventorySlot> slots);
                int amount = 0;
                foreach (var slot in slots)
                {
                    amount += slot.StackSize;
                }
                if (amount >= amountToCheck)
                {
                    return true;
                }
                else { return false; }
            }
        );
        //SaveGameManager.TryLoadData();
    }

    protected abstract void LoadInventory(SaveData saveData);

    private void OnDestroy()
    {
        //SaveGameManager.SaveData();
    }


    [YarnCommand("addGold")]
    public void addGold(int goldToAdd)
    {
        _gold += goldToAdd;
    }

    [YarnCommand("sellItem")]
    public void sellToNpc(string potion, string reason, bool didNegotiate)
    {
        switch (potion)
        {
            case "hpPotion":
                if (reason == "LowHP")
                {
                    if (didNegotiate)
                    {
                        primaryInventorySystem.RemoveItemsFromInventory(ItemmDB.GetItem(potion), 1);
                        primaryInventorySystem.GainGold(35);
                    }
                    else
                    {
                        primaryInventorySystem.RemoveItemsFromInventory(ItemmDB.GetItem(potion), 1);
                        primaryInventorySystem.GainGold(25);
                    }
                }
                else if (reason == "Prep")
                {
                    if (didNegotiate)
                    {
                        primaryInventorySystem.RemoveItemsFromInventory(ItemmDB.GetItem(potion), 1);
                        primaryInventorySystem.GainGold(50);
                    }
                    else
                    {
                        primaryInventorySystem.RemoveItemsFromInventory(ItemmDB.GetItem(potion), 1);
                        primaryInventorySystem.GainGold(35);
                    }
                }
                break;

            case "fPotion":
                if (reason == "Cooling")
                {
                    if (didNegotiate)
                    {
                        primaryInventorySystem.RemoveItemsFromInventory(ItemmDB.GetItem(potion), 1);
                        primaryInventorySystem.GainGold(35);
                    }
                    else
                    {
                        primaryInventorySystem.RemoveItemsFromInventory(ItemmDB.GetItem(potion), 1);
                        primaryInventorySystem.GainGold(25);
                    }
                }
                else if (reason == "Fever")
                {
                    if (didNegotiate)
                    {
                        primaryInventorySystem.RemoveItemsFromInventory(ItemmDB.GetItem(potion), 1);
                        primaryInventorySystem.GainGold(50);
                    }
                    else
                    {
                        primaryInventorySystem.RemoveItemsFromInventory(ItemmDB.GetItem(potion), 1);
                        primaryInventorySystem.GainGold(35);
                    }
                }
                break;

            case "hPotion":
                if (reason == "Firewood")
                {
                    if (didNegotiate)
                    {
                        primaryInventorySystem.RemoveItemsFromInventory(ItemmDB.GetItem(potion), 1);
                        primaryInventorySystem.GainGold(35);
                    }
                    else
                    {
                        primaryInventorySystem.RemoveItemsFromInventory(ItemmDB.GetItem(potion), 1);
                        primaryInventorySystem.GainGold(25);
                    }
                }
                else if (reason == "Cold")
                {
                    if (didNegotiate)
                    {
                        primaryInventorySystem.RemoveItemsFromInventory(ItemmDB.GetItem(potion), 1);
                        primaryInventorySystem.GainGold(50);
                    }
                    else
                    {
                        primaryInventorySystem.RemoveItemsFromInventory(ItemmDB.GetItem(potion), 1);
                        primaryInventorySystem.GainGold(40);
                    }
                }
                break;
        }
    }
}


[System.Serializable]
public struct InventorySaveData
{
    public InventorySystem invSystem;
    public Vector3 position;
    public Quaternion rotation;

    public InventorySaveData(InventorySystem _invSystem, Vector3 _position, Quaternion _rotation)
    {
        invSystem = _invSystem;
        position = _position;
        rotation = _rotation;
    }

    public InventorySaveData(InventorySystem _invSystem)
    {
        invSystem = _invSystem;
        position = Vector3.zero;
        rotation = Quaternion.identity;
    }
}

