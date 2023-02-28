using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New BasicPotionRecipe", menuName = "Potions/BasicPotionRecipe")]
public class PotionRecipe : ScriptableObject
{
    public string rname;
    public string pelement;
    public int pelementreq;
    public string[] modifiers;
}
