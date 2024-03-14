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
        gameObject.transform.position = new Vector3(_head.position.x, _head.position.y + _yOffset, _head.position.z);
    }
}
