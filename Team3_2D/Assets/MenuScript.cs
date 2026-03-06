using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public void OnClickPlayButton()
    {
        SceneManager.LoadScene("Level1");
    }

    public void OnClickHelpButton()
    {
        SceneManager.LoadScene("Help");
    }

    public void OnClickQuitButton()
    {
        Application.Quit();
        Debug.Log("Quit Button Was Clicked.");
    }
}
