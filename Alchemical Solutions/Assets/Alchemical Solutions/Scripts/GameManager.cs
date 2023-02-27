using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    public bool paused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
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
