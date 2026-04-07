using UnityEngine;
using UnityEngine.SceneManagement;

public class GameHp : MonoBehaviour
{
    public GameObject[] hearts;
    private int lives;

    void Start()
    {
        lives = hearts.Length;
    }

    public void LoseLife()
    {
        if (lives <= 0)
            return;

        lives--;
        hearts[lives].SetActive(false);

        if (lives == 0)
        {
            SceneManager.LoadScene(2);
        }
    }
}