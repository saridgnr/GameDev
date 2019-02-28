using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WallsManagerScript : MonoBehaviour {
    public Rigidbody[] Walls;
    public SoulScript soul;
    public Image LoseImage;
    public int cooldown = 1;
    public int forcePerWave = 150;
    public int wallsCount = 10;
    float time = 0;
    // Use this for initialization
    void Start () {
        //Rigidbody instance = Instantiate(Walls[Random.Range(0, 2)]);
        //instance.AddForce(Vector3.left * forcePerWave * 1);
        time = cooldown;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (soul.didLose)
        {
            LoseImage.gameObject.SetActive(true);
            GloablScript.currentWave = 0;
            if(Input.GetKey(KeyCode.Space))
            {
                SceneManager.LoadScene("Menu");
            }
        }
        else
        {
            if (wallsCount <= 0)
            {
                SceneManager.LoadScene("TheRoad");
            }
            else
            {
                time -= Time.deltaTime;

                if (time <= 0)
                {
                    Spawn();
                }
            }
        }
    }

    void Spawn()
    {
        Rigidbody instance = Instantiate(Walls[Random.Range(0, 2)]);
        instance.AddForce(Vector3.left * forcePerWave * (GloablScript.currentWave + 1));
        time = cooldown;
        wallsCount--;
    }


}
