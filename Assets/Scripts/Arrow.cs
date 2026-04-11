using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float lifeTime = 4f; //arrow exists for 4 seconds
    private Rigidbody2D rb; //physics component on the arrow to track movement during rotation
    private bool canHitPlayer = false; //makes sure the arrow doesnt hit ranger instantly 

    public AudioClip hurtSound; //sound for hitting ranger

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //gets rb component attached to arrow
        Destroy(gameObject, lifeTime); //deletes arrow after 4 seconds
        Invoke("EnablePlayerHit", 0.2f); //calls function after 0.2 seconds
    }

    void Update()
    {   //converting movement into rotation 
        if (rb.linearVelocity != Vector2.zero) //checks if the arrow is moving, to rotate arrow
        {
            //calculates direction based the arrow speed on x and y axis
            float angle = Mathf.Atan2(rb.linearVelocity.y, rb.linearVelocity.x) * Mathf.Rad2Deg; 
            transform.rotation = Quaternion.Euler(0, 0, angle); //turn the arrow to face that calculated angle on the Z-axis
        }

    }
    
    void OnDestroy()
    {
        PlayerShoot player = Object.FindFirstObjectByType<PlayerShoot>(); //find playershoot shooting script 

        if (player != null) //find player to exist to allow arrow to shoot again
        {
            player.currentArrow = null;
        }
    }
    void EnablePlayerHit() //allows arrow to damage ranger
    {
        canHitPlayer = true;
    }

    void OnCollisionEnter2D(Collision2D collision) //arrow hits an object
    {
        //checks if arrow collides with player and allows arrow to damage player
        if (collision.gameObject.CompareTag("Player") && canHitPlayer) 
        {
            FindAnyObjectByType<GameHp>().LoseLife(); //find GameHp script and remove life from player
            AudioSource.PlayClipAtPoint(hurtSound, transform.position); //play hurt sound at transform positioned 
            Destroy(gameObject); //remove arrow after it hits player
        }
    }
}
