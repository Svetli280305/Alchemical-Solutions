using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey.Utils;

public class ItemWorld : MonoBehaviour
{



    private SpriteRenderer spriteRenderer;

    public static ItemWorld SpawnItemWorld(Vector3 position, Item item)
    {
        Transform itemToSpawn = Instantiate(ItemAssets.Instance.pfItemWorld, position, Quaternion.identity);

        ItemWorld itemWorld = itemToSpawn.GetComponent<ItemWorld>();
        itemWorld.SetItem(item);

        return itemWorld;
    }

    public static ItemWorld dropItem(Vector3 dropPos, Item item)
    {
        Vector3 randomDir = UtilsClass.GetRandomDir();
        ItemWorld itemWorld = SpawnItemWorld(dropPos + randomDir * 5f, item);
        itemWorld.GetComponent<Rigidbody>().AddForce(randomDir * 5f, ForceMode.Impulse);
        return itemWorld;
    }

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    
    private Item item;

    public void SetItem(Item item)
    {
        this.item = item;
        spriteRenderer.sprite = item.GetSprite();

    }

    public Item GetItem()
    {
        return item;
    }


    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
