using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class MouseItemData : MonoBehaviour
{
    public Image ItemSprite;
    public TextMeshProUGUI itemCount;
    public InventorySlot assignedInventorySlot;

    [SerializeField] private int dropOffset;

    private Transform _playerTransform;


    private void Awake()
    {
        ItemSprite.color = Color.clear;
        ItemSprite.preserveAspect = true;
        itemCount.text = "";

        _playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        if (_playerTransform == null) Debug.Log("Player not found");
    }

    public void UpdateMouseSlot(InventorySlot invSlot)
    {
        assignedInventorySlot.AssignItem(invSlot);
        UpdateMouseSlot();
    }

    public void UpdateMouseSlot()
    {
        ItemSprite.sprite = assignedInventorySlot.ItemData.icon;
        itemCount.text = assignedInventorySlot.StackSize.ToString();
        ItemSprite.color = Color.white;
    }

    private void Update()
    {
        // Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0f, 0f, 0f);
        //Debug.Log(Mouse.current.position.ReadValue());
        /*
        if (assignedInventorySlot != null)
        {
            transform.position = Mouse.current.position.ReadValue();
            if (Mouse.current.leftButton.wasPressedThisFrame && !IsPointerOverUIObject() && assignedInventorySlot.ItemData.isDroppable)
            {
                if (assignedInventorySlot.ItemData.itemGO != null) Instantiate(assignedInventorySlot.ItemData.itemGO, _playerTransform.position + _playerTransform.forward * dropOffset, Quaternion.identity);
                if(assignedInventorySlot.StackSize > 1)
                {
                    assignedInventorySlot.AddToStack(-1);
                    UpdateMouseSlot();
                }
                else
                {
                    ClearSlot();
                }
                
            }
        }
        */
        
    }

    public void ClearSlot()
    {
        assignedInventorySlot.ClearSlot();
        itemCount.text = "";
        ItemSprite.color = Color.clear;
        ItemSprite.sprite = null;
    }

    public static bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = Mouse.current.position.ReadValue();
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        //Debug.Log(results.Count > 0);
        return results.Count > 0;
    }
}
