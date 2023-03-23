using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventoryPage : MonoBehaviour
{
    [SerializeField]
    private UIInventoryItem itemPrefab;

    [SerializeField]
    private RectTransform contentPanel;

    [SerializeField]
    private UIInventoryDescription itemDescription;

    List<UIInventoryItem> listOfUiItems = new List<UIInventoryItem>();

    public void InitalizeInventoryUI(int inventorysize)
    {
        for(int i = 0; i < inventorysize; i++)
        {
            UIInventoryItem uiItem = Instantiate(itemPrefab, Vector3.zero, Quaternion.identity);
            uiItem.transform.SetParent(contentPanel);
            listOfUiItems.Add(uiItem);
            uiItem.OnItemClicked += HandleItemSelection;
            uiItem.OnItemBeginDrag += HandleBeginDrag;
            uiItem.OnItemDroppedOn += HandleSwap;
            uiItem.OnItemEndDrag += HandleEndDrag;
            uiItem.OnRightMouseBtnClick += HandleShowItemActions;
        }
    }
    private void Awake()
    {
        Hide();
    }
    private void HandleShowItemActions(UIInventoryItem obj)
    {
        throw new NotImplementedException();
    }

    private void HandleEndDrag(UIInventoryItem obj)
    {
        throw new NotImplementedException();
    }

    private void HandleSwap(UIInventoryItem obj)
    {
        throw new NotImplementedException();
    }

    private void HandleBeginDrag(UIInventoryItem obj)
    {
        throw new NotImplementedException();
    }

    private void HandleItemSelection(UIInventoryItem obj)
    {
        Debug.Log(obj.name);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
