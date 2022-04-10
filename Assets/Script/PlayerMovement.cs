using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{

    Rigidbody rb;
    public float speed = 10f;
    [SerializeField]  float jumpHeight = 8f;

    [SerializeField]  Transform groundCheck;
    [SerializeField] LayerMask ground;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalMove = Input.GetAxis("Horizontal");
        float verticalMove = Input.GetAxis("Vertical");

        rb.velocity = new Vector3(horizontalMove * speed, rb.velocity.y, verticalMove * speed);

        if (Input.GetButtonDown("Jump") && InGround())
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpHeight, rb.velocity.z);
        }

        //Run
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = 20f;
        } else if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = 10f;
        }

        //Pause
        if (Input.GetKey(KeyCode.Escape)) 
        {
            Time.timeScale = 0;
        } else if(Input.GetKey(KeyCode.R))
        {
            Time.timeScale = 1;
        }

        //Action
    }

    bool InGround()
    {
        return Physics.CheckSphere(groundCheck.position, .1f, ground);
    }
}
