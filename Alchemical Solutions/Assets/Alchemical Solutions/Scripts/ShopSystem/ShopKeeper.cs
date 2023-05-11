using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(UniqueID))]
public class ShopKeeper : MonoBehaviour, IInteractable
{

    [SerializeField] private ShopItemLIst _shopItemsHeld;
    [SerializeField] private ShopSystem _shopSystem;

    private ShopSaveData _shopSaveData;

    private string id;

    public UnityAction<IInteractable> OnInteractionCompleted { get; set; }

    public static UnityAction<ShopSystem, PlayerInventoryHolder> OnShopWindowRequested;


    private void Awake()
    {
        _shopSystem = new ShopSystem(_shopItemsHeld.Items.Count, _shopItemsHeld.MaxAllowedGold,
            _shopItemsHeld.BuyMarkUp, _shopItemsHeld.SellMarkUp);

        foreach(var item in _shopItemsHeld.Items)
        {
            Debug.Log($"{item.ItemData.displayName}");
            _shopSystem.AddToShop(item.ItemData, item.Amount);
        }

        id = GetComponent<UniqueID>().ID;
        _shopSaveData = new ShopSaveData(_shopSystem);
    }

    private void Start()
    {
        if (!SaveGameManager.data._shopKeeperDictionary.ContainsKey(id)) SaveGameManager.data._shopKeeperDictionary.Add(id, _shopSaveData);
    }

    private void OnEnable()
    {
        SaveLoad.onLoadGame += LoadInventory;
    }

    private void LoadInventory(SaveData data)
    {
        if (!data._shopKeeperDictionary.TryGetValue(id, out ShopSaveData shopSaveData)) return;
        _shopSaveData = shopSaveData;
        _shopSystem = _shopSaveData.ShopSystem;
    }

    private void OnDisable()
    {
        SaveLoad.onLoadGame -= LoadInventory;
    }


    public void EndInteraction()
    {
        throw new System.NotImplementedException();
    }

    public void Interact(Interactor interactor, out bool interactSuccessful)
    {
        var playerInv = interactor.GetComponent<PlayerInventoryHolder>();


        if (playerInv != null)
        {
            OnShopWindowRequested?.Invoke(_shopSystem, playerInv);
            interactSuccessful = true;
        }
        else
        {
            interactSuccessful = false;
            Debug.LogError("Player Inventory not Found");
        }

    }
}

[System.Serializable]
public struct ShopSaveData
{
    public ShopSystem ShopSystem;

    public ShopSaveData(ShopSystem shotSystem)
    {
        ShopSystem = shotSystem;
    }
}