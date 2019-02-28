using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthScript : MonoBehaviour {
    public int startingHealth = 100;
    public int HP { get; set; }
    Animator anim;
    AudioSource enemyAudio;
    CapsuleCollider capsuleCollider;
    public bool isDead;

    void Start () {
        anim = GetComponent<Animator>();
        enemyAudio = GetComponent<AudioSource>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        HP = startingHealth;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void TakeDamage(int amount)
    {
        if(isDead)
        {
            return;
        }

        HP -= amount;

        if(HP <= 0)
        {
            Death();
        }
    }

    public void Death()
    {
        isDead = true;
        anim.SetTrigger("Dead");
        capsuleCollider.isTrigger = true;
        enemyAudio.Play();
        Destroy(gameObject, 2f);
    }
}
