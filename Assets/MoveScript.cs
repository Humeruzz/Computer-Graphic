using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{

    public float speed;
    public float runSpeed;
    public Rigidbody RBplayer;
    public float jumpForce;
    private bool isGrounded;
    private SphereCollider coll;
    private Animator anim;
    
    void Start()
    {
        anim = GetComponent<Animator>();
        coll = GetComponentInChildren<SphereCollider>();
    }

    private void Update()
    {
        OnTriggerEnter(coll);
        OnTriggerExit(coll);
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            RBplayer.AddForce(0, jumpForce, 0);
        }
    }

    void FixedUpdate()
    {
        Vector3 move2 = transform.right * Input.GetAxis("Horizontal") + transform.forward * Input.GetAxis("Vertical");
        
        anim.SetFloat("Speed", Mathf.Abs(RBplayer.velocity.magnitude));

        if (Input.GetKey("left shift"))
        {
            RBplayer.AddForce(move2 * runSpeed);
        }
        RBplayer.AddForce(move2 * speed);
        Debug.Log(RBplayer.velocity);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ground")
        {
            anim.SetBool("Jump", false);
            isGrounded = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Ground")
        {
            anim.SetBool("Jump", true);
            isGrounded = false;
        }
    }
}
