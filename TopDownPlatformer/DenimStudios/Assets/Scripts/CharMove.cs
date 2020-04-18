using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMove : MonoBehaviour
{

    Rigidbody rb;
    float speed = 5f;

    bool IsLookingLeft = true;
    bool isGrounded;

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

        if((hori != 0 || vert != 0) && isGrounded)
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

    void FixedUpdate()
    {
        if (IsGrounded() && Input.GetButtonDown("Fire1"))
        {
            rb.AddForce(transform.up * 5f, ForceMode.Impulse);
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
                isGrounded = true;
                return true;
            }
        }
        isGrounded = false;
        return false;
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.collider.CompareTag("Ground"))
        {
            isGrounded = true;
            anim.SetBool("jump", false);
        }
    }

}
