using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class RandomMinigamePicker : MonoBehaviour
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
                Debug.Log("Is in trigger");
                int index = Random.Range(2, 4);
                SceneManager.LoadScene(index);
                Cursor.lockState = CursorLockMode.Confined;
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
