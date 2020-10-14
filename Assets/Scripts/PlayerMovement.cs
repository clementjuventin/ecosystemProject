using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    public Rigidbody2D rb;
    public bool isJumping;
    public bool isGrounded;
    public Transform groudCheckLeft;
    public Transform groudCheckRight;
    private Vector3 velocity = Vector3.zero;
    public Animator animator;
    public SpriteRenderer spriteRenderer;

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapArea(groudCheckLeft.position,groudCheckRight.position);

        float horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;

        if(Input.GetButtonDown("Jump")&&isGrounded){
            isJumping = true;
        }

        MovePlayer(horizontalMovement);

        FlipX(rb.velocity.x);
        animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
    }

    void MovePlayer(float _horizontalMovement)
    {
        if(isJumping){
            rb.AddForce(new Vector2(0f, jumpForce));
            isJumping = false;
        }
        Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);
    }
    void FlipX(float _velocityX){
        if(_velocityX > 0.1f){
            spriteRenderer.flipX = false;
        }
        else if(_velocityX < -0.1f){
            spriteRenderer.flipX = true;
        }
    }
}
