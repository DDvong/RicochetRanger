using UnityEngine;

public class Arrow : MonoBehaviour
{

    public float lifeTime = 4f; // Arrow exists for 4 seconds
    private Rigidbody2D rb;
    private bool canHitPlayer = false; // starts false!

    public AudioClip ricochetSound;
    public AudioClip hurtSound;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // Destroy arrow after a few seconds
        Destroy(gameObject, lifeTime);
        Invoke("EnablePlayerHit", 0.2f);
    }

    void Update()
    {
        // rotate arrow to face movement direction
        if (rb.linearVelocity != Vector2.zero)
        {
            float angle = Mathf.Atan2(rb.linearVelocity.y, rb.linearVelocity.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }

    }

    void OnDestroy()
    {
        PlayerShoot player = Object.FindFirstObjectByType<PlayerShoot>();

        if (player != null)
        {
            player.currentArrow = null;
        }
    }
    void EnablePlayerHit()
    {
        canHitPlayer = true;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && canHitPlayer)
        {
            FindAnyObjectByType<GameHp>().LoseLife();
            AudioSource.PlayClipAtPoint(hurtSound, transform.position);
            Destroy(gameObject);
        }
    }
}
