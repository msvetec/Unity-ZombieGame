using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButtonController : MonoBehaviour {

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
        
}
