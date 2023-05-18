using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] public static Database itemDB;
    public bool paused = false;

    void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            Pause();
        }
    }

    public void Pause()
    {
        paused = true;
        Cursor.lockState = CursorLockMode.None;
        pauseMenu.SetActive(true);
    }

    public void Unpause()
    {
        paused = false;
        Cursor.lockState = CursorLockMode.Locked;
        pauseMenu.SetActive(false);
    }
}
