using UnityEngine;
public class IsoJumping : MonoBehaviour
{
    public float jumpforce = 10f;
    public Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
            {
                rb.AddForce(Vector3.up * jumpforce);
            }
        
    }
    
}