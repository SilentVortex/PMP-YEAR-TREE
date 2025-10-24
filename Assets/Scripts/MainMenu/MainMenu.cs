using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void playLevel1()
    {
        SceneManager.LoadScene("Level1");
        Debug.Log("Player loaded Lev");
    }

    public void playMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Debug.Log("Player loaded main menu");
    }

    public void quit()
    {
        Application.Quit();
        Debug.Log("Player has quit!");
    }
}
