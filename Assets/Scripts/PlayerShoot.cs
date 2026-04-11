using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject arrowPrefab; //spawning arrow 
    public Transform arrowShoot; //shooting point 
    public float arrowSpeed = 15f; //arrow speed

    public GameObject currentArrow; //tracks arrow deployed
    public AudioClip shootSound; //firing sound

    void Update()
    {
        //left mouse button clicked and if theres not an arrow on the screen
        if (Input.GetMouseButtonDown(0) && currentArrow == null)
        {
            Shoot();
        }
    }

    void Shoot()
    {   //creates arrow at the spawn point position
        currentArrow = Instantiate(arrowPrefab, arrowShoot.position, Quaternion.identity); 
        AudioSource.PlayClipAtPoint(shootSound, transform.position); //plays shooting sound at transform position
        //ignores collision with the arrow and player
        CapsuleCollider2D playerCollider = GetComponent<CapsuleCollider2D>(); 
        Collider2D arrowCollider = currentArrow.GetComponent<Collider2D>();
        Physics2D.IgnoreCollision(arrowCollider, playerCollider);

        Rigidbody2D rb = currentArrow.GetComponent<Rigidbody2D>(); //get physics component for any arrow deployed

        //convert mouse position to game position 
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //calculate direction by subtracting the player's position from the mouse position
        Vector2 direction = (mouseWorldPos - arrowShoot.position).normalized;

        //arrow launched based on speed at specific direction
        rb.linearVelocity = direction * arrowSpeed;
    }
}
