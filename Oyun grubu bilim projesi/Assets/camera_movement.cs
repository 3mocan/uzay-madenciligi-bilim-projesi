using UnityEngine;

public class camera_movement : MonoBehaviour
{
    public Transform target; 
    public float smoothSpeed = 0.125f;
    private Vector3 velocity = Vector3.zero;

    private Vector3 offset = new Vector3(0f,0f,-10f);

    void FixedUpdate()
    {
        Vector3 DesiredPosition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, DesiredPosition, ref velocity, smoothSpeed);

    }



}
