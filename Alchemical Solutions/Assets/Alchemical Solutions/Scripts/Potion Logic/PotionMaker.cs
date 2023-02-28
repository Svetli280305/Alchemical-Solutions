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


    #region ButtonLogic
    public void Type(int val)
    {
        // 1 = Heat, 2 = Frost, 3 = Poison

        switch (val)
        {
            case 1:
                ptype = "Heat";
                break;
            case 2:
                ptype = "Frost";
                break;
            case 3:
                ptype = "Poison";
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
                psize = "Small";
                break;
            case 2:
                psize = "Medium";
                break;
            case 3:
                psize = "Large";
                break;
        }
    }

    public void Value(int val)
    {
        // 1 = Heat, 2 = Frost, 3 = Nature

        switch (val)
        {
            case 1:
                pvalue = 10;
                break;
            case 2:
                pvalue = 30;
                break;
            case 3:
                pvalue = 50;
                break;
        }
    }

    public void Submit()
    {
        bool useLevel;
        bool useType;
        bool straightFromRecipe;
        if(plevel == 0){useLevel = false;}
        if(ptype == null){ useType = false; }
        if(psize == null && pvalue == 0) { straightFromRecipe = true; }

        
    }
    #endregion
}
