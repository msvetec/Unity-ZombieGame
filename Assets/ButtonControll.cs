using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonControll : MonoBehaviour {

 

    public void StartGame()
    {
        int scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
        Time.timeScale = 1;
        ScoreManager.isPaused = true;
        ScoreManager.playerDead = false;
        ScoreManager.score = 0;
    }

    public void ExitGame()
    {
        Application.Quit();
    }
            
}
