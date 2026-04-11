using UnityEngine;
using UnityEngine.SceneManagement;

public class WinMenu : MonoBehaviour
{
    public void Replay()
    {
        SceneManager.LoadScene(1); //replays the level by loading the game level scene
    }

    public void QuitToMenu()
    {
        SceneManager.LoadScene(0); //loads main menu scene
    }
}