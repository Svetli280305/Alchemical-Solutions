using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject groundChecker;
    public LayerMask whatIsGround;
    //Animator anim;
    bool isOnGround = true;
    bool doubleJump = false;
    public float checkRadius = 1f;
    public float jumpForce = 300f;


    //public AudioClip jump;
    //public AudioSource playerSFX;

    //Ceate a reference to the Rigidbody2D so we can manipulate it
    Rigidbody2D playerObject;
    float movementSpeed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        //Find the rigidbody2D component that is attached to the same object as this script
        playerObject = GetComponent<Rigidbody2D>();
        //playerSFX = GetComponent<AudioSource>();

        //anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //anim.SetBool("IsOnGround", isOnGround);
        //Create a 'float' that will be equal to the players horizontal input
        //float movementValueX = Input.GetAxis("Horizontal") * movementSpeed;

        playerObject.velocity = new Vector2(1.0f*movementSpeed, playerObject.velocity.y);

        //Change the X velocity of the Rigidbody2D to be equal to the movement value
        //playerObject.velocity = new Vector2(movementValueX, playerObject.velocity.y);

        //Check to see if the ground check object is touching the ground
        isOnGround = Physics2D.OverlapCircle(groundChecker.transform.position, 0.1f, whatIsGround);
        if (isOnGround == true)
        {
            doubleJump = false;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isOnGround == true)
            {
                //playerSFX.PlayOneShot(jump);
                playerObject.AddForce(new Vector2(0.0f, jumpForce));
            }
            else if (doubleJump == false)
            {
                //playerSFX.PlayOneShot(jump);
                playerObject.velocity = new Vector2(playerObject.velocity.x, 0.0f);
                playerObject.AddForce(new Vector2(0.0f, jumpForce));
                doubleJump = true;
            }
        }

    }
}
