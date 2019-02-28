using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PrisonerHealthScript : MonoBehaviour
{

    public int max_hp = 100;
    public int HP { get; set; }
    public Slider HealthSlider;
    Animator animator;
    PrisonerMovementScript playerMovement;
    bool isDead;
    bool damaged;


    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        playerMovement = GetComponent<PrisonerMovementScript>();
        this.HP = max_hp;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.position.y <= -10)
        {
            Death();
        }
    }

    public void TakeDamage(int amount)
    {
        damaged = true;
        HP -= amount;
        HealthSlider.value = HP;
        
        if(HP<=0 && !isDead)
        {
            Death();
        }
    }

    public void Death()
    {
        isDead = true;

        if (GloablScript.currentWave != 0)
        {
            GloablScript.currentWave--;
        }
        SceneManager.LoadScene("LastChance");
    }
}
