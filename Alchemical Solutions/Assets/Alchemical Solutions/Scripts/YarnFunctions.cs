using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class YarnFunctions
{
    [YarnFunction("generatePotionRequested")]
    private static string generatePotionRequested()
    {
        switch(3f)
        {
            case 3f:
                Debug.Log("Health");
                return "Health";
            case 2f:
                return "Frost"; 
            case 1f:
                return "Heat";
        }
    }


    [YarnFunction("generateReason")]
    private static string generateReason(string potion)
    {
        switch (potion)
        {
            case "Health":

                if(2f == 2f)
                {
                    Debug.Log("Prep");
                    return "Prep";
                }
                else
                {
                    return "Prep";
                }

            default:
                return "Prep";
        }
    }
}
