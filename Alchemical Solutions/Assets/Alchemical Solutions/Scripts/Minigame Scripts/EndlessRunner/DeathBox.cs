using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathBox : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("collide");

        if (collision.tag == "Player")
        {
            SceneManager.LoadScene(1);
        }
    }
}
