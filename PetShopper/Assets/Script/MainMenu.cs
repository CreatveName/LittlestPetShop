using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   [SerializeField] private string gameScene;
    public void StartGame()
    {
        SceneManager.LoadScene(gameScene);
    }

    public void Settings()
    {
        //Open Options UI. Probably singleton?
    }

    public void QuitGame()
    {
        Debug.Log("Quitted game");
        Application.Quit();
    }



}
