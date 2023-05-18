using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    /*
    public CharacterController controller;

    public float speed = 12f;
    public float gravity =-9.81f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.6f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    void Start()
    {

    }
    private void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
    }




    private void HandleMovement()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (!GameObject.Find("GameManager").GetComponent<GameManager>().paused)
        {
            if (isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;

            controller.Move(move * speed * Time.deltaTime);

            if (Input.GetKeyDown("space") && isGrounded)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }

            velocity.y += gravity * Time.deltaTime;

            controller.Move(velocity * Time.deltaTime);
        }
    }
    */

    private InputMaster controls;

    private float moveSpeed = 9f;

    [SerializeField] private Vector3 velocity;

    private float gravity = -9.81f;

    [SerializeField] private Vector2 move;

    private float jumpHeight = 2.4f;

    private CharacterController controller;

    public Transform ground;

    public float distanceToGround = 0.2f;

    [SerializeField] private LayerMask groundMask;

    private bool isGrounded;

    private void Awake()
    {
        controls = new InputMaster();
        controller = GetComponent<CharacterController>();
        SaveGameManager.TryLoadData();
    }

    private void Update()
    {
        Grav();
        PlayerMovement();
        Jump();
    }

    private void Grav()
    {
        isGrounded = Physics.CheckSphere(ground.position, distanceToGround, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    private void PlayerMovement()
    {
        
        move = controls.Player.Movement.ReadValue<Vector2>();

        Vector3 movement = (move.y * transform.forward) + (move.x * transform.right);
        controller.Move(movement * moveSpeed * Time.deltaTime);
    }

    private void Jump()
    {

    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }
}
