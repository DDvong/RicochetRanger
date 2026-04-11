using UnityEngine;
using UnityEngine.SceneManagement; //allows to switch between game scenes

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(1); //switches scene to game level
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        SceneManager.LoadScene(0); //exits game
    }
}