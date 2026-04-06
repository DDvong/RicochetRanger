using UnityEngine;
using UnityEngine.SceneManagement;

public class GameHp : MonoBehaviour
{
    public GameObject[] hearts;
    private int lives = 3;

    public void LoseLife()
    {
        lives--;

        if (lives >= 0)
        {
            hearts[lives].SetActive(false);
        }

        if (lives <= 0)
        {
            Debug.Log("Game Over!");
            SceneManager.LoadScene(2);
        }
    }
}