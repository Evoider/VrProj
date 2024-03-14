using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowHead : MonoBehaviour
{
    [SerializeField] private Transform _head;
    [SerializeField] private float _yOffset;

    // Update is called once per frame
    void Update()
    {
        Vector3 headPos = _head.position;
        headPos.y += _yOffset;
        gameObject.transform.position = headPos;
        
        Quaternion headRot = _head.rotation;
        headRot.x = 0;
        //headRot.y += 90;
        headRot.z = 0;
        gameObject.transform.rotation = headRot;
    }
}
