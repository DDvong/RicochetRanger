using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public AudioClip grassSound;

    private Animator animator;
    private SpriteRenderer sr;
    private Rigidbody2D rb;
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");   
        //move player
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
            
        animator.SetFloat("Speed", Mathf.Abs(moveInput));

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        {
            AudioSource.PlayClipAtPoint(grassSound, transform.position);
        }

        //flip sprite left and right
        if (moveInput < 0)
        {
            sr.flipX = true;
        }
        else if (moveInput >0) 
        {
            sr.flipX = false;  
        }
    }
}
