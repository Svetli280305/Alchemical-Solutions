using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Potion", menuName = "Potions/CraftedPotion")]
public class Potion : ScriptableObject
{
    public string type;
    public int level;
    public int pvalue;
    public string size;
    [System.Serializable]
    public class SoundEffects
    {
        public int test = 4;
    }

    public SoundEffects sound;
}

