using UnityEngine;

public class IsoFollowCam : MonoBehaviour
{
    public Transform PlayerTransform;

    private Vector3 cameraOffset;

    [Range(0.01f, 1.0f)]

    public bool lookAtPlayer = false;

    public float Smoothness = 0.5f;

    void Start()
    {
        cameraOffset = transform.position - PlayerTransform.position;
        
    }


    void LateUpdate()
    {
        Vector3 newPos = PlayerTransform.position + cameraOffset;

        transform.position = Vector3.Slerp(transform.position, newPos, Smoothness);

        if (lookAtPlayer)
            transform.LookAt(PlayerTransform);
    }
}
