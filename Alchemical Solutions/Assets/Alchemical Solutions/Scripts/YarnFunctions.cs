using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class YarnFunctions
{
    [YarnFunction("generatePotionRequested")]
    private static string generatePotionRequested()
    {
        int r = Random.Range(1, 4);
        switch (r)
        {
            case 1:
                Debug.Log("Health");
                return "Health";
            case 2:
                return "Frost";
            case 3:
                return "Heat";
            default:
                return "Heat";
        }
    }


    [YarnFunction("generateReason")]
    private static string generateReason(string potion)
    {
        int r = Random.Range(1, 3);
        switch (potion)
        {
            case "Health":
                
                if(r == 1)
                {
                    Debug.Log("LowHP");
                    return "LowHP";
                }
                else
                {
                    Debug.Log("Prep");
                    return "Prep";
                }
                break;


            case "Frost":
                if (r == 1)
                {
                    Debug.Log("Cooling");
                    return "Cooling";
                }
                else
                {
                    Debug.Log("Fever");
                    return "Fever";
                }


            case "Heat":
                if (r == 1)
                {
                    Debug.Log("Firewood");
                    return "Firewood";
                }
                else
                {
                    Debug.Log("Cold");
                    return "Cold";
                }

            default:
                return "Prep";
        }
    }
}
