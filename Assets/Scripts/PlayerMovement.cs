using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; //player speed
    public AudioClip grassSound; //sound effect for walking

    private Animator animator; //character animation
    private SpriteRenderer sr; //displays character image
    private Rigidbody2D rb; //character physics
    

    void Start()
    {   //variables for the component of the player object
        rb = GetComponent<Rigidbody2D>(); //gets physics component for moving player
        animator = GetComponent<Animator>(); //gets animation component for changing animations
        sr = GetComponent<SpriteRenderer>(); //gets sprite for animations
    }

    void Update()
    {
        float moveInput = Input.GetAxisRaw("Horizontal"); //detects horizontal movement inputs
        
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y); //move player based on physics velocity
        //tells the animator how fast its moving     
        animator.SetFloat("Speed", Mathf.Abs(moveInput)); //animation switch 
        //inputting a or d plays the walking sound 
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        {
            AudioSource.PlayClipAtPoint(grassSound, transform.position);
        }

        //flip sprite image based on movement key direction
        if (moveInput < 0) //moves left side
        {
            sr.flipX = true; //mirror image 
        }
        else if (moveInput > 0) //moving right side
        {
            sr.flipX = false; //faces right
        }
    }
}
