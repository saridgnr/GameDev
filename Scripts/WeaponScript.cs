using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour {

    public GameObject weapon_holder;

	// Use this for initialization
	void Start () {
        transform.position = weapon_holder.transform.position;
        transform.rotation = weapon_holder.transform.rotation;

    }

    // Update is called once per frame
    void LateUpdate () {
        transform.position = weapon_holder.transform.position;
        transform.rotation = weapon_holder.transform.rotation;
        transform.Rotate(0, 45, 25);
    }
}
