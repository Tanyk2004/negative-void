using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    
    public float runSpeed = 40f;
    public float horizontalMove = 0f;
    public float jumpSpeed = 10.0f;
    public Transform playerTransform;
    public Rigidbody2D playerRigidbody;
    public float distToGround;
    public LayerMask groundLayer;
    public float groundRange = 1.0f;
    public Transform groundCheck;
    public int collisionlength = 1;
    void Start()
    {
        collisionlength = 1;
    }
    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            playerRigidbody.AddForce(new Vector2(0f, jumpSpeed), ForceMode2D.Impulse);
        }
    }

    void FixedUpdate()
    {
        playerTransform.Translate(horizontalMove * Time.deltaTime, 0f, 0f);
        
    }

    private bool IsGrounded(){
        Collider2D[] detectGround = Physics2D.OverlapCircleAll(groundCheck.position, 
                groundRange, groundLayer);
        collisionlength = detectGround.Length;
        if (collisionlength > 0){
            return true;
        }
        else{
            return false;
        }

        
    }

    

}
