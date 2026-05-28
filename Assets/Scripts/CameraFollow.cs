using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Target")]
    public Transform target;           // Drag the Ghost GameObject here

    [Header("Follow Settings")]
    public float smoothSpeed = 5f;     // Higher = snappier, lower = floatier
    public Vector3 offset = new Vector3(0f, 0f, -10f); // Keep Z at -10 for 2D

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 desiredPos = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, desiredPos, smoothSpeed * Time.deltaTime);
    }
}
