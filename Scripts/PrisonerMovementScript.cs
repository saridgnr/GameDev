using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrisonerMovementScript : MonoBehaviour
{
    public float speed = 2.0f;
    public float sprint_modifier = 1.5f;
    Vector3 movement;
    Animator anim;
    Rigidbody playerRigidbody;
    int floorMask;
    float camRayLength = 100f;
    void Start()
    {
        floorMask = LayerMask.GetMask("Floor");
        anim = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        //var horizontal_move = Input.mousePosition.normalized.x;
        movement = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        movement = movement.normalized * speed * Time.deltaTime;
        anim.SetBool("isWalking", movement != Vector3.zero);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            movement *= sprint_modifier;
            anim.SetBool("isRunning", true);

        }
        else
        {
            anim.SetBool("isRunning", false);
        }

        playerRigidbody.MovePosition(transform.position + movement);
        if (movement != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(movement);
        }

    }
}
