using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMove : MonoBehaviour
{

    Rigidbody rb;
    float speed = 5f;

    bool IsLookingLeft = true;

    //bool IsGrounded;

    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float hori = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");

        Debug.Log(hori);

        Vector3 move = new Vector3(hori, 0, vert);

        if(hori < 0 && !IsLookingLeft)
        {
            IsLookingLeft = true;
            transform.Rotate(Vector3.up, -180);
        }
        else if (hori >= 0 && IsLookingLeft)
        {
            IsLookingLeft = false;
            transform.Rotate(Vector3.up, 180);
        }

        if(hori != 0 || vert != 0)
        {
            anim.SetBool("walk", true);
        }
        else
        {
            anim.SetBool("walk", false);
        }

        transform.position += move * Time.deltaTime * speed;
        //rb.AddForce(move * speed);
    }

    private void FixedUpdate()
    {
        if (Input.GetButtonDown("Fire1") && IsGrounded())
        {
            rb.AddForce(0, 8f, 0, ForceMode.Impulse);
            anim.SetBool("jump", true);
        }
    }

  bool IsGrounded()
    {
        Ray ray = new Ray(transform.position, -transform.up);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 0.6f))
        {
            if (hit.collider.CompareTag("Ground"))
            {
                IsGrounded = true;
                return true;
            }
        }
        IsGrounded = false;
        return false;
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.collider.CompareTag("Ground"))
        {
            IsGrounded = true;
            anim.SetBool("jump", false);
        }
    }

}
