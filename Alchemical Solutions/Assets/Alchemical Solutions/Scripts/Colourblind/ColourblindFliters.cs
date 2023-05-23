using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColourblindFliters : MonoBehaviour
{
    public Toggle toggleNone;
    public Toggle toggleProtanopia;
    public Toggle toggleDeuteranopia;

    private void Start()
    {
        if(PlayerPrefs.GetInt("ToggleBool1") == 1)
        {
            toggleNone.isOn = true;
        }
        else
        {
            toggleNone.isOn = false;
        }

        if (PlayerPrefs.GetInt("ToggleBool2") == 1)
        {
            toggleNone.isOn = true;
        }
        else
        {
            toggleNone.isOn = false;
        }

        if (PlayerPrefs.GetInt("ToggleBool3") == 1)
        {
            toggleNone.isOn = true;
        }
        else
        {
            toggleNone.isOn = false;
        }
    }

    private void Update()
    {
        if (toggleNone.isOn)
        {
            PlayerPrefs.SetInt("ToggleBool1", 1);
        }
        else
        {
            PlayerPrefs.SetInt("ToggleBool1", 0);
        }

        if (toggleProtanopia.isOn)
        {
            PlayerPrefs.SetInt("ToggleBool1", 1);
        }
        else
        {
            PlayerPrefs.SetInt("ToggleBool1", 0);
        }

        if (toggleDeuteranopia.isOn)
        {
            PlayerPrefs.SetInt("ToggleBool1", 1);
        }
        else
        {
            PlayerPrefs.SetInt("ToggleBool1", 0);
        }



    }

}

