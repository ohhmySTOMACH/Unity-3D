using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public  void ReloadGame()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }

    public void QuitApplication()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}
