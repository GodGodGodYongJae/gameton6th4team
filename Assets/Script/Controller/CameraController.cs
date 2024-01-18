using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField]
    private GameObject _target;
    public float CameraSpeed { get; private set; } = 2.0f;
    private Vector3 _targetPos;
    // Update is called once per frame
    void FixedUpdate()
    {
        _targetPos = _target.transform.position;
        transform.position = Vector3.Lerp(transform.position, _targetPos, Time.deltaTime * CameraSpeed);
        transform.rotation = Quaternion.Lerp(transform.rotation, _target.transform.rotation, Time.deltaTime * CameraSpeed);
    }
}
