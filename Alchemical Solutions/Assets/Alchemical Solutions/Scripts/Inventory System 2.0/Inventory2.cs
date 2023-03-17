using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory2 : MonoBehaviour
{

    public List<InventoryItem> inventory = new List<InventoryItem>();
    private Dictionary<ItemData, InventoryItem> itemDicitionary = new Dictionary<ItemData, InventoryItem>();
    // Start is called before the first frame update
    public void Add(ItemData itemData)
    {
        if (itemDicitionary.TryGetValue(itemData, out InventoryItem item))
        {
            item.AddToStack();
        }
        else
        {
            InventoryItem newItem = new InventoryItem(itemData);
            inventory.Add(newItem);
            itemDicitionary.Add(itemData, newItem);
        }
    }


    public void Remove(ItemData itemData)
    {
        if(itemDicitionary.TryGetValue(itemData, out InventoryItem item))
        {
            item.RemoveFromStack();
            if(item.stackSize == 0)
            {
                inventory.Remove(item);
                itemDicitionary.Remove(itemData);
            }
        }
    }

    private void OnEnable()
    {
        Ingredient.OnGemCollected += Add;
    }

    private void OnDisable()
    {
        Ingredient.OnGemCollected -= Add;
    }
}
