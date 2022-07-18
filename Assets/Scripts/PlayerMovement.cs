using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 3f;
    [SerializeField] Animator anim;
    void Start()
    {
        
    }

    
    void Update()
    {
       MoverPersonaje(); 
    }

    void MoverPersonaje()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        Vector3 inputPlayer = new Vector3(hor,0,ver);

        transform.Translate(inputPlayer * speed * Time.deltaTime);

        if(inputPlayer == Vector3.zero)
        {
            anim.SetBool("estaCorriendo", false);
        } else
        {
            anim.SetBool("estaCorriendo", true);
        }
    }
}
