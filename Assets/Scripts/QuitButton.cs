using UnityEngine;


public class QuitButtonScript : MonoBehaviour
{
    public void QuitGame()
    {
        Debug.Log("QUIT button clicked");
        Application.Quit();
    }
}