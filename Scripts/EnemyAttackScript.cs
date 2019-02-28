using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackScript : MonoBehaviour {
    public float attackDelta = 0.5f;
    public int attackDamage = 10;

    public Animator Animator { get; set; }
    public GameObject Player { get; set; }
    public PrisonerHealthScript playerHealth { get; set; }
    public EnemyHealthScript enemyHealth { get; set; }

    bool playerInRange;
    float timer;

    void Start () {
        Player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = Player.GetComponent<PrisonerHealthScript>();
        enemyHealth = GetComponent<EnemyHealthScript>();
        Animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        timer += Time.deltaTime;

        if(timer >= attackDelta && playerInRange && enemyHealth.HP > 0)
        {
            Animator.SetTrigger("Attack");
            Attack();
        }

        if(playerHealth.HP <= 0)
        {
            Animator.SetTrigger("PlayerDead");
        }
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player)
        {
            playerInRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == Player)
        {
            playerInRange = false;
        }
    }

    void Attack()
    {
        timer = 0f;

        if(playerHealth.HP > 0)
        {
            playerHealth.TakeDamage(attackDamage);
        }
    }
}
