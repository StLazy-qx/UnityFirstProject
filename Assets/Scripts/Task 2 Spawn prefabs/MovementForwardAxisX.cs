using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementForwardAxisX : MonoBehaviour
{
    [SerializeField] private int _speedMove;

    private void Update()
    {
        transform.Translate(_speedMove * Time.deltaTime, 0, 0);
    }
}
