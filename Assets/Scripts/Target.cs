using UnityEngine;
using UnityEngine.SceneManagement;

public class Target : MonoBehaviour
{
    public AudioClip collectingSound; //slot to hold sound effect of arrow hitting fruit

    void OnCollisionEnter2D(Collision2D collision) //runs when hitting an object
    {
        if (collision.gameObject.CompareTag("Arrow")) //checks to see if the object got hit with an arrow tag
        {
            //checks upon the impact of destroying
            if (GameObject.FindGameObjectsWithTag("Fruit").Length == 1) //checks if its the last fruit in the scene 
            {
                SceneManager.LoadScene(3); //switches to win scene
            }
            AudioSource.PlayClipAtPoint(collectingSound, transform.position); //plays the sound at the current fruit transform position 
            Destroy(gameObject);
        }
    }
}