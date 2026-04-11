using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public void Retry()
    {
        SceneManager.LoadScene(1); //restarts the level by loading the game level scene
    }

    public void QuitToMenu()
    {
        SceneManager.LoadScene(0); //loads main menu scene
    }
}