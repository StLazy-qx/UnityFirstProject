using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTargetController : MonoBehaviour
{
    [SerializeField] private float camPositionSpeed = 5f;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Vector3 offset;

    void FixedUpdate()
    {
        Vector3 newCamPosition = playerTransform.position + offset;
        transform.position = Vector3.Lerp(transform.position, newCamPosition, camPositionSpeed * Time.deltaTime);
    }
}
