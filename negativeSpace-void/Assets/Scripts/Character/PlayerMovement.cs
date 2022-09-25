using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    
    public float runSpeed = 40f;
    float horizontalMove = 0f;
    float jumpSpeed = 10.0f;
    public Transform playerTransform;
    public Rigidbody2D playerRigidbody;
    public float distToGround;

    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        if (Input.GetButtonDown("Jump") && !IsGrounded())
        {
            playerRigidbody.AddForce(new Vector2(0f, jumpSpeed), ForceMode2D.Impulse);
        }
    }

    void FixedUpdate()
    {
        playerTransform.Translate(horizontalMove * Time.deltaTime, 0f, 0f);
        
    }

    private bool IsGrounded(){
    return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
    }


}
