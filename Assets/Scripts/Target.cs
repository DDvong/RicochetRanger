using UnityEngine;
using UnityEngine.SceneManagement;

public class Target : MonoBehaviour
{
    public AudioClip collectingSound;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Arrow"))
        {
            // check BEFORE destroying
            if (GameObject.FindGameObjectsWithTag("Fruit").Length == 1)
            {
                SceneManager.LoadScene(3);
            }
            AudioSource.PlayClipAtPoint(collectingSound, transform.position);
            Destroy(gameObject);
        }
    }
}