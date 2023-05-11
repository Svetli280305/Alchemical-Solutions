using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UICanvas : MonoBehaviour
{
    [SerializeField] private ShopKeeperDisplay _shopKeeperDisplay;


    private void Awake()
    {
        _shopKeeperDisplay.gameObject.SetActive(false);
    }






    private void OnEnable()
    {
        ShopKeeper.OnShopWindowRequested += DisplayShopWindow;
    }

    

    private void OnDisable()
    {
        ShopKeeper.OnShopWindowRequested -= DisplayShopWindow;
    }

    private void Update()
    {
        if(Keyboard.current.escapeKey.wasPressedThisFrame) _shopKeeperDisplay.gameObject.SetActive(false);
    }
    private void DisplayShopWindow(ShopSystem shopSystem, PlayerInventoryHolder playerInventory)
    {
        _shopKeeperDisplay.gameObject.SetActive(true);
        _shopKeeperDisplay.DisplayShopWindow(shopSystem, playerInventory);
    }
}
