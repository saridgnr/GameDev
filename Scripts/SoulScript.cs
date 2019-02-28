using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoulScript : MonoBehaviour {
    public float speed = 10.0f;
    public bool didLose;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Break();
        }

        Move(); 
    }

    void Move()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"),0) 
            * speed * Time.deltaTime;

        transform.Translate(movement);
    }

    void Break()
    {
        RaycastHit hitInfo;
        if (Physics.Raycast(transform.position, Vector3.right, out hitInfo))
        {
            if(hitInfo.collider.tag == "Breakable")
            {
                hitInfo.collider.gameObject.GetComponent<BreakScript>().Break();
            }
            else if (hitInfo.collider.tag == "Unbreakable")
            {
                didLose = true;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Breakable")
        {
            didLose = true;
        }
    }
}
