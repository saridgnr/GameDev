using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShooterScript : MonoBehaviour {

    public Rigidbody projectilePrefab;
    public float force = 300;
    public float cooldown = 1f;
    float time;
    Vector3 projectileOffset;
    // Use this for initialization
    void Start () {
        projectileOffset = new Vector3(0, 1f, 0);
        time = 0;

    }
	
	// Update is called once per frame
	void Update () {
        time -= Time.deltaTime;
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (time <= 0)
        {
            Rigidbody projectileInstance;
            projectileInstance = Instantiate(projectilePrefab, gameObject.transform.position + projectileOffset, gameObject.transform.rotation) as Rigidbody;
            projectileInstance.AddForce(gameObject.transform.forward * force);
            time = cooldown;
        }
    }
}
