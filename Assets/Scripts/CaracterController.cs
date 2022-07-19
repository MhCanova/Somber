using System.Collections;
using System.Collections.Generic;
using UnityEngine;





public class CaracterController : MonoBehaviour
{

    [Header("Movimiento Del Personaje")]

    [SerializeField] float movSpeed;
    [SerializeField] float smoothRotation = 0.1f;

    public CharacterController controller;
    public Transform camara;

    float rotationSpeed;
    

    [Header("Variables Salto y Suelo")]

    public Transform groundChecher;
    public float groundDistance;
    public LayerMask groundMask;

    Vector3 speed;

    bool isGrounded;

    [SerializeField] float gravity = -9.81f;

    [SerializeField] float jumpHeight;



    //Animacion

    [Header("Variables de Anim")]

    public Animator animator;
    public string variableMovimiento;
    public string variableSuelo;





    void Start()
    {

        controller = GetComponent<CharacterController>();
    }



    void Update()
    {
        isGrounded = Physics.CheckSphere(groundChecher.position, groundDistance, groundMask);

        if (isGrounded && speed.y < 0)
        {

            speed.y = -2f;

        }



        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direccion = new Vector3(horizontal, 0f, vertical).normalized; //Normalizado es para que al moverse en diagonal no vaya mas rapido
        animator.SetFloat(variableMovimiento, (Mathf.Abs(vertical) + Mathf.Abs(horizontal)));



        if (direccion.magnitude >= 0.1f)
        {

            float anguloARotar = Mathf.Atan2(direccion.x, direccion.z) * Mathf.Rad2Deg + camara.eulerAngles.y;
            float angulo = Mathf.SmoothDampAngle(transform.eulerAngles.y, anguloARotar, ref rotationSpeed, smoothRotation);
            transform.rotation = Quaternion.Euler(0f, angulo, 0f);



            Vector3 direccionDelMovimiento = Quaternion.Euler(0f, anguloARotar, 0f) * Vector3.forward;
            controller.Move(direccionDelMovimiento.normalized * movSpeed * Time.deltaTime);

        }



        if (Input.GetButtonDown("Jump") && isGrounded)
        {

            speed.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }



        speed.y += gravity * Time.deltaTime;
        controller.Move(speed * Time.deltaTime);

        animator.SetBool(variableSuelo, controller.isGrounded);

    }



}