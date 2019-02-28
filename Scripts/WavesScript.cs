using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WavesScript : MonoBehaviour {
    public int lastWave = 10;
    public int monstersPerWave = 4;
    public PatrolScript spawner;
    public TextMeshProUGUI waveText;
    public TextMeshProUGUI victoryText;
    public Image victoryScreen;

    int deathsNumber;

	// Use this for initialization
	void Start () {
        victoryScreen.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if(GloablScript.currentWave == lastWave && CanMoveToNextWave())
        {
            victoryScreen.gameObject.SetActive(true);
            victoryText.text = string.Format("You Won!\nScore: {0}", CalculateScore());

            if(Input.GetKey(KeyCode.Space))
            {
                Debug.Log("ok");
                SceneManager.LoadScene("Menu");
            }
        }
		else if(CanMoveToNextWave())
        {
            waveText.text = string.Format("Press 'Space' to start Wave {0}", GloablScript.currentWave + 1);
            MoveToNextWave();
        }
        else
        {
            waveText.text = "";
        }
	}

    private int CalculateScore()
    {
        return GloablScript.currentWave * 100;
    }

    void MoveToNextWave()
    {
        if(Input.GetKey(KeyCode.Space) == true)
        {
            Debug.Log("Wave: " + GloablScript.currentWave);
            GloablScript.currentWave++;
            spawner.monstersTotal = GloablScript.currentWave * monstersPerWave;
        }
    }

    bool CanMoveToNextWave()
    {
        return (GameObject.FindGameObjectsWithTag("Enemy").Length == 0 && spawner.monstersTotal <= 0); 
    }
}
