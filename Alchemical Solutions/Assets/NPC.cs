using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class NPC : MonoBehaviour
{
    public GameObject Dialogue;
    bool active = false;
    public bool outOfRange = true;
    [SerializeField] GameObject SceneChangerGUI;
    public DialogueRunner dialogueRunner;
    // Start is called before the first frame update
    void Start()
    {
    }

    void Update()
    {
        if (active == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Is in trigger");
                Dialogue.SetActive(true);
                dialogueRunner.StartDialogue("HelloYarn");
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
