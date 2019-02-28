using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManagerScript : MonoBehaviour {

    public Camera cam1;
    public Camera cam2;

    // Use this for initialization
    void Start () {
        cam1.enabled = true;
        cam2.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyUp(KeyCode.V))
        {
            if(cam1.enabled)
            {
                cam2.enabled = true;
                cam1.enabled = false;
            }
            else
            {
                cam2.enabled = false;
                cam1.enabled = true;
            }
        }
	}
}
