using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Potion", menuName = "Potions/CraftedPotion")]
public class Potion : MonoBehaviour
{
    public string type;
    public int level;
    public int pvalue;
    public string size;
}
