using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    CharacterMovement characterMovement;
    
    void Awake() => characterMovement = transform.parent.GetComponent<CharacterMovement>();

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 10)
        {
            characterMovement.touchingGround = true;
            characterMovement.whileJump = true;
            characterMovement.time = 0;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == 10)
            characterMovement.touchingGround = false;
    }
}
