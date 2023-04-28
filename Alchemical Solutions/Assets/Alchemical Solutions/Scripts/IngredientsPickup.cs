using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientsPickup : MonoBehaviour
{

    bool active = false;
    public bool outOfRange = true;
    [SerializeField] GameObject SceneChangerGUI;

    private void Update()
    {
        if (active == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("+Ingredients");
                Destroy(gameObject);
                SceneChangerGUI.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            active = true;
            SceneChangerGUI.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            active = false;
            SceneChangerGUI.SetActive(false);
        }
    }
}
