using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

	public void PlayGame()
    {
        GloablScript.currentWave = 0;
        SceneManager.LoadScene("TheRoad");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
