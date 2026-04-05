using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    //variables to edit information in inspector
    public GameObject arrowPrefab; //spawning arrows  
    public Transform arrowShoot; //shooting point (where the arrow where be drawn upon) where arrow spawns
    public float arrowSpeed = 10f; //arrow speed

    private GameObject currentArrow;


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
        //gets the physics component from rigidbody to manipulate the arrow
        Rigidbody2D rb = currentArrow.GetComponent<Rigidbody2D>();
        //retrieves info about mouse cursor on the game world where the position is converted into game coordinates
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //direction from shoot point to mouse
        Vector2 direction = mousePosition - (Vector2)arrowShoot.position;
        direction.Normalize();
        //launch arrow
        rb.linearVelocity = direction * arrowSpeed;
    }
}
