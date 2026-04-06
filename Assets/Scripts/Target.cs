using UnityEngine;
using UnityEngine.SceneManagement;

public class Target : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D collision)
    {
        //checks if the target has been hit with arrow
        if (collision.gameObject.CompareTag("Arrow"))
        {
            Destroy(gameObject); //Only destroy the target if the thing that hit it is tagged "Arrow".
            if (GameObject.FindGameObjectsWithTag("Fruit").Length <= 1)
            {
                SceneManager.LoadScene(3);
            }
        }
    }
}
