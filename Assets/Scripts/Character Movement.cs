using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    // Player variables
    public bool touchingGround;
    public bool whileJump;
    float moveSpeed = 5;
    float jumpHeight = 8;

    void Update()
    {
        Movement();
        
        if (Input.GetKey(KeyCode.Space) && whileJump)
            WhileJump();
        else if (!touchingGround)
            Falling();
    } 
    
    void Movement()
    {
        var pos = GetComponent<Rigidbody2D>().position;
        pos.x += Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime;
        GetComponent<Rigidbody2D>().position = pos;
    }

    [HideInInspector] public float time = 0;
    
    void WhileJump()
    {
        time += Time.deltaTime;
        
        if (time > 0.75f)
            whileJump = false;
        
        var pos = GetComponent<Rigidbody2D>().position;
        pos.y += jumpHeight * Time.deltaTime;
        GetComponent<Rigidbody2D>().position = pos;
    }

    void Falling()
    {
        if (Input.GetKeyUp(KeyCode.Space))
            whileJump = false;
        
        var pos = GetComponent<Rigidbody2D>().position;
        pos.y -= jumpHeight * Time.deltaTime;
        GetComponent<Rigidbody2D>().position = pos;
    }
}
