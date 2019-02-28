using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    private float cameraDistanceMax = 20f;
    private float cameraDistanceMin = 5f;
    public GameObject player;       //Public variable to store a reference to the player game object
    public float rot_speed = 90f;
    public float scroll_speed = 30f;
    public Vector3 scrollVector;


    private Vector3 offset;         //Private variable to store the offset distance between the player and camera

    // Use this for initialization
    void Start()
    {
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        offset = transform.position - player.transform.position;
    }

    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        Vector3 scroll_delta = scrollVector * Input.GetAxis("Mouse ScrollWheel") * scroll_speed * Time.deltaTime;
        offset += scroll_delta;
        transform.position = player.transform.position + offset;
        float distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance < cameraDistanceMin || distance > cameraDistanceMax)
            offset -= scroll_delta;



        //if (Input.GetKey(KeyCode.Mouse1))
        //{
        //    float mouse_speed = Input.GetAxis("Mouse X") * this.rot_speed;
        //    var mouse_move = new Vector3(0, mouse_speed * Time.deltaTime, 0);
        //    transform.Rotate(transform.rotation * mouse_move);
        //}
    }

    
}
