using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent (typeof(UniqueID))]
public class ItemPickUp : MonoBehaviour
{
    public float pickUpRadius = 1f;
    public InventoryItemData itemData;

    [SerializeField] private float rotationSpeed;

    private BoxCollider myCollider;

    [SerializeField] private ItemPickupSaveData itemSavedata;
    private string id;
    private void Awake()
    {
        id = GetComponent<UniqueID>().ID;
        SaveLoad.onLoadGame += LoadGame;
        itemSavedata = new ItemPickupSaveData(itemData, transform.position, transform.rotation);

        myCollider = GetComponent<BoxCollider>();
        myCollider.isTrigger = true;
    }


    private void Start()
    {
        SaveGameManager.data.activeItems.Add(id, itemSavedata);
    }

    private void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        var inventory = other.transform.GetComponent<PlayerInventoryHolder>();
        if (!inventory) return;
        if (inventory.AddToInventory(itemData, 1))
        {
            SaveGameManager.data.collectedItems.Add(id);
            Destroy(this.gameObject);
        }

    }

    private void LoadGame(SaveData data)
    {
        if (data.collectedItems.Contains(id)) Destroy(this.gameObject);
    }

    private void OnDestroy()
    {
        if (SaveGameManager.data.activeItems.ContainsKey(id)) SaveGameManager.data.activeItems.Remove(id);
        SaveLoad.onLoadGame -= LoadGame;
    }

    private void Rotate()
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
}

[System.Serializable]
public struct ItemPickupSaveData
{
    public InventoryItemData ItemData;
    public Vector3 position;
    public Quaternion rotation;

    public ItemPickupSaveData(InventoryItemData _data, Vector3 _position, Quaternion _rotation)
    {
        ItemData = _data;
        position = _position;
        rotation = _rotation;
    }

}
