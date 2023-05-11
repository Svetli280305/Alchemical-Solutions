using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public abstract class InventoryDisplay : MonoBehaviour
{

    [SerializeField] MouseItemData mouseInventoryItem;


    protected InventorySystem inventorySystem;
    protected Dictionary<InventorySlot_UI, InventorySlot> slotDictionary;

    public InventorySystem InventorySystem => inventorySystem;

    public Dictionary<InventorySlot_UI, InventorySlot> SlotDictionary => slotDictionary;

    protected virtual void Start()
    {

    }



    public abstract void AssignSlot(InventorySystem invToDisplay, int offset);

    protected virtual void UpdateSlot(InventorySlot updatedSlot)
    {
        foreach(var slot in SlotDictionary)
        {
            if(slot.Value == updatedSlot) // Slot value - Under the hood inventory slot
            {
                slot.Key.UpdateUISlot(updatedSlot); // Slot key - UI Representation of the value.
            }
        }
    }

    public void SlotClicked(InventorySlot_UI clickedSlot)
    {
        /*
        Debug.Log("Running");
        Debug.Log(clickedSlot.AssignedInventorySlot.ItemData);
        Debug.Log(mouseInventoryItem.assignedInventorySlot.ItemData);
        */

        bool isShiftPressed = Keyboard.current.leftShiftKey.isPressed;
        // click slot has an item - mouse doesnt - pick up that ite
        if (clickedSlot.AssignedInventorySlot.ItemData != null && mouseInventoryItem.assignedInventorySlot.ItemData == null)
        {

            if(isShiftPressed && clickedSlot.AssignedInventorySlot.SplitStack(out InventorySlot halfStackSlot)) // split stack
            {
                mouseInventoryItem.UpdateMouseSlot(halfStackSlot);
                clickedSlot.UpdateUISlot();
                return;
            }
            else
            {
                Debug.Log("click slot has an item - mouse doesnt - pick up that ite");
                mouseInventoryItem.UpdateMouseSlot(clickedSlot.AssignedInventorySlot);
                clickedSlot.ClearSlot();
                return;
            }

            
        }

        // click slot doesnt have an item - mouse does - place the mouse into empty slot
        if(clickedSlot.AssignedInventorySlot.ItemData == null && mouseInventoryItem.assignedInventorySlot.ItemData != null)
        {
            Debug.Log("click slot doesnt have an item - mouse does - place the mouse into empty slot");
            clickedSlot.AssignedInventorySlot.AssignItem(mouseInventoryItem.assignedInventorySlot);
            clickedSlot.UpdateUISlot();
            mouseInventoryItem.ClearSlot();
        }

        // both slots have an item decide what to do
        if(clickedSlot.AssignedInventorySlot.ItemData != null && mouseInventoryItem.assignedInventorySlot.ItemData != null)
        {
            Debug.Log("// both slots have an item decide what to do");
            bool isSameItem = clickedSlot.AssignedInventorySlot.ItemData == mouseInventoryItem.assignedInventorySlot.ItemData;


            if(isSameItem && clickedSlot.AssignedInventorySlot.RoomLeftInStack(mouseInventoryItem.assignedInventorySlot.StackSize))
            {
                Debug.Log("Adding mouse to stack");
                clickedSlot.AssignedInventorySlot.AssignItem(mouseInventoryItem.assignedInventorySlot);
                clickedSlot.UpdateUISlot();

                mouseInventoryItem.ClearSlot();
                return;
            }
            else if (isSameItem && 
                !clickedSlot.AssignedInventorySlot.RoomLeftInStack(mouseInventoryItem.assignedInventorySlot.StackSize, out int leftInStack))
            {
                if (leftInStack < 1) { SwapSlots(clickedSlot); Debug.Log("Swapping"); }// stack is full so swap items
                else// stack is not at max, take whats left from mouse
                {
                    Debug.Log("Take as much as possible from mouse");
                    int remainingOnMouse = mouseInventoryItem.assignedInventorySlot.StackSize - leftInStack;
                    clickedSlot.AssignedInventorySlot.AddToStack(leftInStack);
                    clickedSlot.UpdateUISlot();

                    var newItem = new InventorySlot(mouseInventoryItem.assignedInventorySlot.ItemData, remainingOnMouse);
                    mouseInventoryItem.ClearSlot();
                    mouseInventoryItem.UpdateMouseSlot(newItem);
                    return;
                }
            }
            else if (!isSameItem)
            {
                Debug.Log("Swap since not same item");
                SwapSlots(clickedSlot);
                return;
            }
        }
            // are both items the same? if so combine them.
                // is the slot stack size + mouse stack size > the slot max stack size if so leave rem
    }

    private void SwapSlots(InventorySlot_UI clickedSlot)
    {
        var clonedSlot = new InventorySlot(mouseInventoryItem.assignedInventorySlot.ItemData, mouseInventoryItem.assignedInventorySlot.StackSize);
        mouseInventoryItem.ClearSlot();
        mouseInventoryItem.UpdateMouseSlot(clickedSlot.AssignedInventorySlot);

        clickedSlot.ClearSlot();
        clickedSlot.AssignedInventorySlot.AssignItem(clonedSlot);
        clickedSlot.UpdateUISlot();
    }
}
