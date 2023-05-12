using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ShopSlotUI : MonoBehaviour
{
    [SerializeField] private Image _itemSprite;
    [SerializeField] private TextMeshProUGUI _itemName;
    [SerializeField] private TextMeshProUGUI _itemCount;
    [SerializeField] private ShopSlot _assignedItemSlot;

    public ShopSlot AssignedItemSlot => _assignedItemSlot;

    [SerializeField] private Button _addItemToCartButton;
    [SerializeField] private Button _removeItemToCartButton;

    private int _tempAmount;

    public ShopKeeperDisplay ParentDisplay { get; private set; }

    public float MarkUp { get; private set; }
    private void Awake()
    {
        _itemSprite.sprite = null;
        _itemSprite.preserveAspect = true;
        _itemSprite.color = Color.clear;
        _itemName.text = "";
        _itemCount.text = "";

        _addItemToCartButton?.onClick.AddListener(AddItemToCart);
        _removeItemToCartButton?.onClick.AddListener(removeItemToCart);
        ParentDisplay = transform.parent.GetComponentInParent<ShopKeeperDisplay>();
    }


    public void Init(ShopSlot slot, float markUp)
    {
        _assignedItemSlot = slot;
        MarkUp = markUp;
        _tempAmount = slot.StackSize;
        UpdateUISlot();
    }

    private void UpdateUISlot()
    {
        if(_assignedItemSlot.ItemData != null)
        {
            _itemSprite.sprite = _assignedItemSlot.ItemData.icon;
            _itemSprite.color = Color.white;
            _itemCount.text = _assignedItemSlot.StackSize.ToString();
            var modifiedPrice = ShopKeeperDisplay.GetModifiedPrice(_assignedItemSlot.ItemData, 1, MarkUp);
            _itemName.text = $"{_assignedItemSlot.ItemData.displayName} - {modifiedPrice}G";
        }
        else
        {
            _itemSprite.sprite = null;
            _itemSprite.color = Color.white;
            _itemName.text = "";
            _itemCount.text = "";
        }
    }

    private void removeItemToCart()
    {
        if (_tempAmount == _assignedItemSlot.StackSize) return;

        _tempAmount++;
        ParentDisplay.RemoveItemFromCart(this);
        _itemCount.text = _tempAmount.ToString();
    }

    private void AddItemToCart()
    {
        if (_tempAmount <= 0) return;
        _tempAmount--;
        ParentDisplay.AddItemToCart(this);
        _itemCount.text = _tempAmount.ToString();

    }

    
    
        
    
}
