using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DebugManager : MonoBehaviour
{
    public TextMeshProUGUI typet;
    public TextMeshProUGUI levelt;
    public TextMeshProUGUI sizet;
    public TextMeshProUGUI valuet;
    private CanvasGroup menu3;
    private CanvasGroup menu2;
    private CanvasGroup menu1;
    public PotionMaker pm;


    private void Start()
    {
        menu1 = GameObject.Find("Selection menu").GetComponent<CanvasGroup>();
        menu2 = GameObject.Find("Spawning Menu").GetComponent<CanvasGroup>();
        menu3 = GameObject.Find("Result").GetComponent<CanvasGroup>();
    }
    #region Button Stuf
    public void Type(int val)
    {
        // 0 = Heat, 1 = Frost, 2 = Poison

        switch (val)
        {
            case 0:
                pm.pot.ptype = "Heat";
                break;
            case 1:
                pm.pot.ptype = "Frost";
                break;
            case 2:
                pm.pot.ptype = "Poison";
                break;
        }
    }

    public void pEle(int val)
    {
        // 0 = Heat, 1 = Frost, 2 = Nature

        switch (val)
        {
            case 0:
                pm.pelement = "Fire";
                break;
            case 1:
                pm.pelement = "Ice";
                break;
            case 2:
                pm.pelement = "Nature";
                break;
        }
    }

    public void Charge(int val)
    {
        // 0 = Heat, 1 = Frost, 2 = Nature

        switch (val)
        {
            case 0:
                pm.pcharge = 1;
                break;
            case 1:
                pm.pcharge = 3;
                break;
            case 2:
                pm.pcharge = 5;
                break;
        }
    }

    public void Modifier(int val)
    {
        // 0 = Heat, 1 = Frost, 2 = Nature

        switch (val)
        {
            case 0:
                pm.modifiers.Add("Thorns");
                break;
            case 1:
                //add
                break;
            case 2:
                //add
                break;
        }
    }

    public void Size(int val)
    {
        // 0 = Heat, 1 = Frost, 2 = Nature

        switch (val)
        {
            case 0:
                pm.pot.psize = "Small";
                break;
            case 1:
                pm.pot.psize = "Medium";
                break;
            case 2:
                pm.pot.psize = "Large";
                break;
        }
    }

    public void Value(int val)
    {
        // 0 = Heat, 1 = Frost, 2 = Nature

        switch (val)
        {
            case 0:
                pm.pot.pvalue = 10;
                break;
            case 1:
                pm.pot.pvalue = 30;
                break;
            case 2:
                pm.pot.pvalue = 50;
                break;
        }
    }

    public void Level(int val)
    {
        // 0 = Heat, 1 = Frost, 2 = Nature

        switch (val)
        {
            case 0:
                pm.pot.plevel = 1;
                break;
            case 1:
                pm.pot.plevel = 2;
                break;
            case 2:
                pm.pot.plevel = 3;
                break;
        }
    }

    #endregion
    public void Spawning()
    {
        menu1.alpha = 0;
        menu1.interactable = false;
        menu1.blocksRaycasts = false;
        menu2.alpha = 1;
        menu2.interactable = true;
        menu2.blocksRaycasts = true;
    }
    public void Submit()
    {
        menu2.alpha = 0;
        menu2.interactable = false;
        menu2.blocksRaycasts = false;

        menu3.alpha = 1;
        menu3.interactable = true;
        menu3.blocksRaycasts = true;

        typet.text = "Potion Type: " + pm.pot.ptype;
        levelt.text = "Potion Level: " + pm.pot.plevel;
        sizet.text = "Potion Size: " + pm.pot.psize;
        valuet.text = "Potion Value: " + pm.pot.pvalue;
    }

    
    
    
}
