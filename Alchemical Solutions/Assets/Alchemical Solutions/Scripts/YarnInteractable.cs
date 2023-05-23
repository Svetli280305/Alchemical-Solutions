using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Yarn.Unity;
public class YarnInteractable : MonoBehaviour
{
    public string conversationStartNode;
    private DialogueRunner dialogueRunner;
    private bool interactable = true;
    [SerializeField] private bool inRange = false;
    [SerializeField] private bool isCurrentConvo = false;

    private void Start()
    {
        dialogueRunner = FindObjectOfType<Yarn.Unity.DialogueRunner>();
        dialogueRunner.onDialogueComplete.AddListener(EndConversation);
    }


    private void StartConversation()
    {
        Cursor.lockState = CursorLockMode.None;
        Debug.Log($"Staring Dialogue");
        dialogueRunner.StartDialogue(conversationStartNode);
    }

    private void Update()
    {
        if(inRange && interactable && !dialogueRunner.IsDialogueRunning && Keyboard.current.eKey.wasPressedThisFrame)
        {
            isCurrentConvo = true;
            StartConversation();
        }
    }
    // reverse StartConversation's changes: 
    // re-enable scene interaction, deactivate indicator, etc.
    private void EndConversation()
    {
        if (isCurrentConvo)
        {
            Cursor.lockState = CursorLockMode.Locked;
            isCurrentConvo = false;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            inRange = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            inRange = false;
        }
    }
    // make character not able to be clicked on
    public void DisableConversation()
    {

    }
}
