using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] Transform _head;
    [SerializeField] Canvas _canvas;

    // Update is called once per frame
    void Update()
    {
        _canvas.transform.position = _head.position + _head.transform.forward * 0.5f;
        _canvas.transform.Translate(new Vector3(0, 0, 0.5f), Space.Self);
        _canvas.transform.forward = _head.transform.forward;
    }
}
