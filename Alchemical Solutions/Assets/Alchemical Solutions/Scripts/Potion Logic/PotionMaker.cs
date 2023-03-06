using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionMaker : MonoBehaviour
{
    public string ptype;
    public int plevel;
    public int pvalue;
    public string psize;
    public List<string> modifiers = new List<string>();
    public string pelement;
    public int pcharge;
    public Potion pot;

    [System.Serializable]
    public class Potion
    {
        public string ptype;
        public int plevel;
        public string psize;
        public int pvalue;
        public int ID;
    }

    public void Update()
    {
        
    }

}
