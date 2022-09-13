using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform _TargetTransform;
    private float _zDiff;

    void Start()
    {
        Vector3 position = transform.position;
        float zPosition = ((SaveSystem.saveSystem.GetlvlN() * 230) - 33.87f);
        transform.position = new Vector3(position.x, position.y, zPosition);
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
