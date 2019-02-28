using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour {
    public float destroyTime = 3f;
    public int dmg = 25;
	// Use this for initialization
	void Start () {
        Destroy(gameObject, destroyTime);
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            var enemyHP = other.gameObject.GetComponent<EnemyHealthScript>();
            if (!enemyHP.isDead)
            {
                enemyHP.TakeDamage(dmg);
                Destroy(gameObject, 0);
            }
        }

        if(other.tag == "Environment")
        {
            Destroy(gameObject, 0);
        }
    }
}
