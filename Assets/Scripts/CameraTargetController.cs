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
        Vector3 newCamPosition = new Vector3(offset.x, playerTransform.position.y + offset.y, playerTransform.position.z + offset.z);
        transform.position = Vector3.Lerp(transform.position, newCamPosition, camPositionSpeed * Time.deltaTime);
    }
}
