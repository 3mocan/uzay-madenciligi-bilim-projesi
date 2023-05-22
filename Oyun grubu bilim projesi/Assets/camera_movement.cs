using UnityEngine;

public class camera_movement : MonoBehaviour
{
    public Transform target;

    public float smoothSpeed = 0.125f;

    public Vector3 offset;

    void FixedUpdate()
    {
        Vector3 DesiredPosition = target.position + offset;
        Vector3 SmoothedPosition = Vector3.Lerp(transform.position, DesiredPosition, smoothSpeed);
        transform.position = SmoothedPosition;

        transform.LookAt(target);
    }



}
