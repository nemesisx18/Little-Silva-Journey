using UnityEngine;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour
{
    public void MainPlay()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void BackMenu()
    {
        Debug.Log("Back to Menu");
        
        SceneManager.LoadScene("MainMenu");
    }

    public void ClickEvent()
    {
        Application.Quit();
    }
}
