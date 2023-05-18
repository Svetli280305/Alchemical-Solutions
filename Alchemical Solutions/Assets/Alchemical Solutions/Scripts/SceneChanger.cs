using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] int sceneToLoad;

    bool active = false;
    public bool outOfRange = true;
    [SerializeField] GameObject SceneChangerGUI;

    private void Update()
    {
        if(active == true)
        {
            if (Keyboard.current.eKey.wasPressedThisFrame)
            {
                Debug.Log("Is in trigger");
                SceneManager.LoadScene(2);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Player")
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

