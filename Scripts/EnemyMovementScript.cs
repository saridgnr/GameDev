using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovementScript : MonoBehaviour {
    Transform player;
    NavMeshAgent nav;
    public PrisonerHealthScript playerHealth{ get; set; }
    public EnemyHealthScript enemyHealth { get; set; }


    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        nav = GetComponent<NavMeshAgent>();
        playerHealth = player.GetComponent<PrisonerHealthScript>();
        enemyHealth = GetComponent<EnemyHealthScript>();


    }

    // Update is called once per frame
    void FixedUpdate () {
        if (enemyHealth.HP > 0 && playerHealth.HP > 0)
        {
            nav.SetDestination(player.position);
        }
        else
        {
            nav.enabled = false;
        }
	}
}
