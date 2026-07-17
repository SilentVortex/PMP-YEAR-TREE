using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void playLevel1()
    {
        SceneManager.LoadScene("Level1");
        Debug.Log("Player loaded Level 1");
    }
    public void playLevel2()
    {
        SceneManager.LoadScene("Level2");
        Debug.Log("Player loaded Level 2");
    }
    public void playLevel3()
    {
        SceneManager.LoadScene("Level3");
        Debug.Log("Player loaded Level 3");
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
