using System;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    
    #region Variables
    [Header("Player Variables")]
    Rigidbody2D rb;
    
    [Header("Movement Variables")]
    [SerializeField] float moveSpeed = 5;
    [SerializeField] float jumpHeight = 8;
    float xAxis;

    [Header("GroundCheck Variables")] 
    [SerializeField] Transform groundCheck;
    [SerializeField] Vector2 groundCheckRadius;
    LayerMask ground;
    #endregion
    
    #region Update + Awake
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        ground = LayerMask.GetMask("Ground");
    }

    void Update()
    {
        WhileJump();
        Movement();
        
        if (!IsGrounded() && rb.linearVelocityY <= 0)
            Falling();
    }
    #endregion
    
    void Movement() => rb.linearVelocityX = moveSpeed * Input.GetAxisRaw("Horizontal");

    void WhileJump()
    {
        Debug.Log(rb.linearVelocity);
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
            rb.linearVelocityY = jumpHeight;

        if (Input.GetKeyUp(KeyCode.Space) && rb.linearVelocityY > 0)
            rb.linearVelocityY = 0;
    }

    bool IsGrounded() => Physics2D.OverlapBox(groundCheck.position, groundCheckRadius, 0, ground);
    
    void Falling() => rb.linearVelocityY = -jumpHeight;
}
