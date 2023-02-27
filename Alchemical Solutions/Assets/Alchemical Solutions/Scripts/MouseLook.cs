using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 200f;

    public Transform playerBody;

    float xRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        if (PlayerPrefs.GetFloat("MouseS") != null && PlayerPrefs.GetFloat("MouseS") > 0)
        {
            mouseSensitivity *= PlayerPrefs.GetFloat("MouseS");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameObject.Find("GameManager").GetComponent<GameManager>().paused)
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90, 90f);

            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            playerBody.Rotate(Vector3.up * mouseX);

        }

    }
}
