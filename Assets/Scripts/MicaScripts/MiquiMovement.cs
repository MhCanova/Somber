using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiquiMovement : MonoBehaviour
{
    [SerializeField] float speed = 2f;
    Animator anim;
    
    public Vector3 jump;
    public float jumpForce = 2.0f;
    
    Rigidbody rb;
    bool isGrounded;
    bool isJumping;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }
     
    void OnCollisionStay()
    {
        isGrounded = true;
    }

    void OnCollisionExit()
    {
        isGrounded = false;
    }

    void Update()
    {
        MovePlayer();
        PlayerJump();
    }

    void MovePlayer()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        Vector3 inputPlayer = new Vector3(hor,0,ver);

        transform.Translate(inputPlayer * speed * Time.deltaTime );

        if(inputPlayer == Vector3.zero)
        {
            anim.SetBool("isRunning", false);
        }
        else
        {
            anim.SetBool("isRunning", true);
        }
    }

    void PlayerJump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            anim.SetBool("isJumping", true);
            isGrounded = false;
        }
        else
        {
            anim.SetBool("isJumping", false);
        }
    }
}
