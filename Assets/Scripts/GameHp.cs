using UnityEngine;
using UnityEngine.SceneManagement;

public class GameHp : MonoBehaviour
{
    public GameObject[] hearts; //array used to store and manage heart images shown on game level screen
    private int lives; //tracks the lives 

    void Start()
    {
        lives = hearts.Length; //sets the lives to how many hearts in the array which is 3
    }

    public void LoseLife() // arrow hits ranger
    {
        if (lives <= 0) //if the player already has 0 lives, stop the function
            return;

        lives--; //reduces the life counter by 1
        hearts[lives].SetActive(false); //hides the heart icon on the screen

        if (lives == 0) //no lives, loads game over scene
        {
            SceneManager.LoadScene(2);
        }
    }
}