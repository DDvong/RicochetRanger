using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    //variables to edit information in inspector
    public GameObject arrowPrefab; //spawning arrows  
    public Transform arrowShoot; //shooting point (where the arrow where be drawn upon) where arrow spawns
    public float arrowSpeed = 10f; //arrow speed

    public GameObject currentArrow;


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
        //spawns a copy of the arrow prefab at the arrowShoot position create arrow
        currentArrow = Instantiate(arrowPrefab, arrowShoot.position, Quaternion.identity);
        //ignore collision between arrow and player
        CapsuleCollider2D playerCollider = GetComponent<CapsuleCollider2D>();
        Collider2D arrowCollider = currentArrow.GetComponent<Collider2D>();
        Physics2D.IgnoreCollision(arrowCollider, playerCollider);
        //gets the physics component from rigidbody to manipulate the arrow
        Rigidbody2D rb = currentArrow.GetComponent<Rigidbody2D>();
        Vector3 mouseScreenPos = Input.mousePosition;
        mouseScreenPos.z = -Camera.main.transform.position.z;
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mouseScreenPos);
        //retrieves info about mouse cursor on the game world where the position is converted into game coordinates
        Vector2 direction = (mouseWorldPos - arrowShoot.position).normalized;
        //direction from shoot point to mouse

        //launch arrow
        rb.linearVelocity = direction * arrowSpeed;
    }
}
