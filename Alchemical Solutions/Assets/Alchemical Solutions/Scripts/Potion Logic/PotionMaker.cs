using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionMaker : MonoBehaviour
{
    string ptype;
    int plevel;
    int pvalue;
    string psize;
    private List<string> modifiers = new List<string>();
    string pelement;
    int pcharge;
    public Potion pot;

    [System.Serializable]
    public class Potion
    {
        public string ptype;
        public int plevel;
        public string psize;
        public int pvalue;
    }

    #region ButtonLogic
    public void Type(int val)
    {
        // 1 = Heat, 2 = Frost, 3 = Poison

        switch (val)
        {
            case 1:
                pot.ptype = "Heat";
                break;
            case 2:
                pot.ptype = "Frost";
                break;
            case 3:
                pot.ptype = "Poison";
                break;
        }
    }

    public void pEle(int val)
    {
        // 1 = Heat, 2 = Frost, 3 = Nature

        switch (val)
        {
            case 1:
                pelement = "Fire";
                break;
            case 2:
                pelement = "Ice";
                break;
            case 3:
                pelement = "Nature";
                break;
        }
    }

    public void Charge(int val)
    {
        // 1 = Heat, 2 = Frost, 3 = Nature

        switch (val)
        {
            case 1:
                pcharge = 1;
                break;
            case 2:
                pcharge = 3;
                break;
            case 3:
                pcharge = 5;
                break;
        }
    }

    public void Modifier(int val)
    {
        // 1 = Heat, 2 = Frost, 3 = Nature

        switch (val)
        {
            case 1:
                modifiers.Add("Thorns");
                break;
            case 2:
                //add
                break;
            case 3:
                //add
                break;
        }
    }

    public void Size(int val)
    {
        // 1 = Heat, 2 = Frost, 3 = Nature

        switch (val)
        {
            case 1:
                pot.psize = "Small";
                break;
            case 2:
                pot.psize = "Medium";
                break;
            case 3:
                pot.psize = "Large";
                break;
        }
    }

    public void Value(int val)
    {
        // 1 = Heat, 2 = Frost, 3 = Nature

        switch (val)
        {
            case 1:
                pot.pvalue = 10;
                break;
            case 2:
                pot.pvalue = 30;
                break;
            case 3:
                pot.pvalue = 50;
                break;
        }
    }


    public void Submit()
    {
        Debug.Log(pot);
        
    }
    #endregion
}
