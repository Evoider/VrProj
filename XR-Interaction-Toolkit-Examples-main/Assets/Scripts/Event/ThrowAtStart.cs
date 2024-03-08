using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowAtStart : MonoBehaviour
{
    private Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();

    }

    // Start is called before the first frame update
    void Start()
    {
        Activate();
    }
    public void Activate()
    {
        _rb.AddForce(Random.insideUnitSphere * 10f, ForceMode.Impulse);
    }
}
