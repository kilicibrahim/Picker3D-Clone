using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform _TargetTransform;
    private float _zDiff;

    void Start()
    {
        _zDiff = Mathf.Abs((_TargetTransform.position.z - transform.position.z)); // difference between picker and camera
    }

    void LateUpdate()
    {
        if (_TargetTransform == null) return;
        
        Vector3 temp = transform.position;
        temp.z = _TargetTransform.position.z - _zDiff;
        transform.position = temp;
    }
}
