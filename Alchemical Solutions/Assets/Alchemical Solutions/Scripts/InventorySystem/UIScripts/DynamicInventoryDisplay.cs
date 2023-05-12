using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DynamicInventoryDisplay : InventoryDisplay
{
    [SerializeField] protected InventorySlot_UI slotPrefab;



    protected override void Start()
    {


        base.Start();

    }

    public void RefreshDynamicInventory(InventorySystem invToDisplay, int offset)
    {
        ClearSlots();
        inventorySystem = invToDisplay;
        if(inventorySystem != null) InventorySystem.OnInventorySlotChanged += UpdateSlot;
        AssignSlot(invToDisplay, offset);
    }
    
public override void AssignSlot(InventorySystem invToDisplay, int offset)
    {
        

        slotDictionary = new Dictionary<InventorySlot_UI, InventorySlot>();

        if (invToDisplay == null) return;



        for(int i = offset; i < invToDisplay.InventorySize; i++)
        {
            var uiSlot = Instantiate(slotPrefab, transform);
            slotDictionary.Add(uiSlot, invToDisplay.InventorySlots[i]);
            uiSlot.Init(invToDisplay.InventorySlots[i]);
            uiSlot.UpdateUISlot();
        }
    }

    private void ClearSlots()
    {
        foreach(var item in transform.Cast<Transform>())
        {
            // object pooling
            
            Destroy(item.gameObject);
        }

        if (slotDictionary != null) slotDictionary.Clear();
    }

    private void OnDisable()
    {
        if(inventorySystem != null) inventorySystem.OnInventorySlotChanged -= UpdateSlot;
    }
}

