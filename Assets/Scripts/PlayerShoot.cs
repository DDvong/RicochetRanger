using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject arrowPrefab; //spawning arrows  
    public Transform arrowShoot; //shooting point (where the arrow where be drawn upon) where arrow spawns
    public float arrowSpeed = 15f; //arrow speed

    public GameObject currentArrow;
    public AudioClip shootSound;

    // Update is called once per frame
    void Update()
    {
        //left mouse button clicked
        if (Input.GetMouseButtonDown(0) && currentArrow == null)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        currentArrow = Instantiate(arrowPrefab, arrowShoot.position, Quaternion.identity);
        AudioSource.PlayClipAtPoint(shootSound, transform.position);

        CapsuleCollider2D playerCollider = GetComponent<CapsuleCollider2D>();
        Collider2D arrowCollider = currentArrow.GetComponent<Collider2D>();
        Physics2D.IgnoreCollision(arrowCollider, playerCollider);

        Rigidbody2D rb = currentArrow.GetComponent<Rigidbody2D>();

        // get mouse position in world
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // direction from player to mouse
        Vector2 direction = (mouseWorldPos - arrowShoot.position).normalized;

        // launch arrow
        rb.linearVelocity = direction * arrowSpeed;
    }
}
