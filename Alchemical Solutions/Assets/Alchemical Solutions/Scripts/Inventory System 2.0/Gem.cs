using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : MonoBehaviour, ICollectible
{
    public static event HandleGemCollected OnGemCollected;
    public delegate void HandleGemCollected(ItemData itemData);
    public ItemData ingredientData;
    // need to make dynamic
    public void Collect()
    {
        Destroy(gameObject);
        //OnGemCollected?.Invoke(gemData);
    }
}
