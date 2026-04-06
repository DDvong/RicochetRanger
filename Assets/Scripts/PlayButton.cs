using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButtonScript : MonoBehaviour
{
    public void StartGame()
    {
        Debug.Log("PLAY button clicked");
        SceneManager.LoadScene(1);
    }
}