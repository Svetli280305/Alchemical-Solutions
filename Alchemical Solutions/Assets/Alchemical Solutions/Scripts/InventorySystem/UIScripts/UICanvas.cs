using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UICanvas : MonoBehaviour
{
    [SerializeField] private ShopKeeperDisplay _shopKeeperDisplay;
    [SerializeField] private GameObject remap;


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
        if(Keyboard.current.escapeKey.wasPressedThisFrame) { _shopKeeperDisplay.gameObject.SetActive(false); Cursor.lockState = CursorLockMode.Locked;  }
        if(Keyboard.current.zKey.wasPressedThisFrame && remap.activeInHierarchy) { remap.SetActive(false); Cursor.lockState = CursorLockMode.Locked; }
        if(Keyboard.current.zKey.wasPressedThisFrame && !remap.activeInHierarchy) { remap.SetActive(true); Cursor.lockState = CursorLockMode.None; }

        
    }
    private void DisplayShopWindow(ShopSystem shopSystem, PlayerInventoryHolder playerInventory)
    {
        _shopKeeperDisplay.gameObject.SetActive(true);
        _shopKeeperDisplay.DisplayShopWindow(shopSystem, playerInventory);
        Cursor.lockState = CursorLockMode.None;
    }
}
