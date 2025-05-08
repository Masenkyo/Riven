using System;
using System.Collections;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    // Player variables
    float moveSpeed = 5;
    float jumpHeight = 10;
    bool touchingGround;

    void Update()
    {
        Movement();
        
        if (Input.GetKey(KeyCode.Space))
            WhileJump();
        else if (!touchingGround)
            Falling();
    } 
    
    // void FixedUpdate() => GroundCheck();

    void Movement()
    {
        var pos = GetComponent<Rigidbody2D>().position;
        pos.x += Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime;
        GetComponent<Rigidbody2D>().position = pos;
    }

    void WhileJump()
    {
        var pos = GetComponent<Rigidbody2D>().position;
        pos.y += jumpHeight * Time.deltaTime;
        GetComponent<Rigidbody2D>().position = pos;
    }

    void Falling()
    {
        var pos = GetComponent<Rigidbody2D>().position;
        pos.y -= jumpHeight * Time.deltaTime;
        GetComponent<Rigidbody2D>().position = pos;
    }

    // void GroundCheck()
    // {
    //     RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, 100, 10);
    //
    //     touchingGround = hit;
    //
    //     if (hit)
    //     {
    //         Debug.Log(hit);
    //     }
    // }
    
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == 10)
            touchingGround = true;
    }
    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.layer == 10)
            touchingGround = false;
    }

}
