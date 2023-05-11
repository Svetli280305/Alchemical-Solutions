using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;


public class RandomMinigamePicker : MonoBehaviour
{

    [SerializeField] private bool canActivate;
    [SerializeField] private PlayerInventoryHolder playerInv;
    [SerializeField] private Database db;
    [SerializeField] private GameObject craftingPanel;

    private void Awake()
    {
        craftingPanel.SetActive(false);
    }
    private void Update()
    {
      if(canActivate && Keyboard.current.fKey.wasPressedThisFrame)
      {
            Debug.Log("Fkey pressed");
            craftingPanel.SetActive(true);
      }

       if (Keyboard.current.escapeKey.wasPressedThisFrame) craftingPanel.SetActive(false);

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            canActivate = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            canActivate = false;
            craftingPanel.SetActive(false);
        }
    }

    public void CraftFrostPotion()
    {
        Debug.Log("Test");
        bool hasWater = false;
        bool hasSaphhire = false;
        if (playerInv.PrimaryInventorySystem.ContainsItem(db.GetItem("tWater"), out List<InventorySlot> slots)){
            int amount = 0;
            foreach(var slot in slots)
            {
                amount += slot.StackSize;
            }
            if (amount >= 1)
            {
                hasWater = true;
            }
        }

        if (playerInv.PrimaryInventorySystem.ContainsItem(db.GetItem("Sapphire"), out List<InventorySlot> slots2))
        {
            int amount = 0;
            foreach (var slot in slots)
            {
                amount += slot.StackSize;
            }
            if (amount >= 2)
            {
                hasSaphhire = true;
            }
        }

        if(hasWater && hasSaphhire)
        {
            playerInv.PrimaryInventorySystem.AddToInventory(db.GetItem("frostP"), 1);
            SaveGameManager.SaveData();
            int index = Random.Range(3, 5);
            SceneManager.LoadScene(index);
            Cursor.lockState = CursorLockMode.Confined;
        }

    }

    public void CraftHeatPotion()
    {
        bool hasWater = false;
        bool hasSaphhire = false;
        if (playerInv.PrimaryInventorySystem.ContainsItem(db.GetItem("cRancher"), out List<InventorySlot> slots))
        {
            int amount = 0;
            foreach (var slot in slots)
            {
                amount += slot.StackSize;
            }
            if (amount >= 1)
            {
                hasWater = true;
            }
        }

        if (playerInv.PrimaryInventorySystem.ContainsItem(db.GetItem("Ruby"), out List<InventorySlot> slots2))
        {
            int amount = 0;
            foreach (var slot in slots)
            {
                amount += slot.StackSize;
            }
            if (amount >= 2)
            {
                hasSaphhire = true;
            }
        }

        if (hasWater && hasSaphhire)
        {
            playerInv.PrimaryInventorySystem.AddToInventory(db.GetItem("heatP"), 1);
            SaveGameManager.SaveData();
            int index = Random.Range(3, 5);
            SceneManager.LoadScene(index);
            Cursor.lockState = CursorLockMode.Confined;
        }

    }

    public void CraftHealingPotion()
    {
        bool hasWater = false;
        bool hasSaphhire = false;
        if (playerInv.PrimaryInventorySystem.ContainsItem(db.GetItem("pDust"), out List<InventorySlot> slots))
        {
            int amount = 0;
            foreach (var slot in slots)
            {
                amount += slot.StackSize;
            }
            if (amount >= 3)
            {
                hasWater = true;
            }
        }

        if (playerInv.PrimaryInventorySystem.ContainsItem(db.GetItem("hRoot"), out List<InventorySlot> slots2))
        {
            int amount = 0;
            foreach (var slot in slots)
            {
                amount += slot.StackSize;
            }
            if (amount >= 2)
            {
                hasSaphhire = true;
            }
        }

        if (hasWater && hasSaphhire)
        {
            playerInv.PrimaryInventorySystem.AddToInventory(db.GetItem("healingP"), 1);
            SaveGameManager.SaveData();
            int index = Random.Range(3, 5);
            SceneManager.LoadScene(index);
            Cursor.lockState = CursorLockMode.Confined;
        }

    }

    public void CraftPoisonPotion()
    {
        bool hasWater = false;
        bool hasSaphhire = false;
        if (playerInv.PrimaryInventorySystem.ContainsItem(db.GetItem("wRoot"), out List<InventorySlot> slots))
        {
            int amount = 0;
            foreach (var slot in slots)
            {
                amount += slot.StackSize;
            }
            if (amount >= 1)
            {
                hasWater = true;
            }
        }

        if (playerInv.PrimaryInventorySystem.ContainsItem(db.GetItem("Amethyst"), out List<InventorySlot> slots2))
        {
            int amount = 0;
            foreach (var slot in slots)
            {
                amount += slot.StackSize;
            }
            if (amount >= 2)
            {
                hasSaphhire = true;
            }
        }

        if (hasWater && hasSaphhire)
        {
            playerInv.PrimaryInventorySystem.AddToInventory(db.GetItem("poisonP"), 1);
            SaveGameManager.SaveData();
            int index = Random.Range(3, 5);
            SceneManager.LoadScene(index);
            Cursor.lockState = CursorLockMode.Confined;
        }

    }
}
