using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    [SerializeField] private int _speedMove;

    void Update()
    {
        transform.Translate(_speedMove * Time.deltaTime, 0, 0);
    }
}
