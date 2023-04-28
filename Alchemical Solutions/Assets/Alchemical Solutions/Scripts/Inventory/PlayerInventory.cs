using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniversalInventorySystem;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField]
    private Inventory playerInv;


    // Start is called before the first frame update
    private void Start()
    {
        playerInv.Initialize();
        playerInv.
        InventoryHandler invEvent = InventoryHandler.current;
        invEvent.OnAddItem += OnAddItem;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            playerInv.AddItem(InventoryHandler.current.GetItem(0, 1), 1);
        }
    }

    private void OnAddItem(object sender, InventoryHandler.AddItemEventArgs e)
    {
        if (e.inv == this.playerInv)
        {
            Debug.Log("Something was added to this.");
        }
    }
}
