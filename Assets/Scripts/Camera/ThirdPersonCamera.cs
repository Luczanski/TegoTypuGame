using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform target;            // The target the camera will follow
    public Vector3 offset;              // The offset from the target's position
    public float smoothTime = 0.3f;     // The smooth time for the camera movement

    private Vector3 velocity = Vector3.zero;

    private void LateUpdate()
    {
        if (target == null)
            return;

        // Calculate the target position with the offset applied after rotation
        Vector3 targetPosition = target.position + target.TransformDirection(offset);

        // Smoothly move the camera towards the target position
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);

        // Make the camera look at the target
        transform.LookAt(target.position + Vector3.up * offset.y);
    }
}
