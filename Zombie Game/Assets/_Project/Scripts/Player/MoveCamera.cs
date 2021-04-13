using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    [SerializeField] private Transform head;
    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
    }

    private void Update()
    {
        _transform.position = head.position;    
    }
}
