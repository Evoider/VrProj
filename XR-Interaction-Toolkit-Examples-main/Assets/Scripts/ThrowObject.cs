using UnityEngine;

public class ThrowObject : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private int _forceAmount;

    public void Activate()
    {
        _rb.AddForce(Vector3.up * _forceAmount, ForceMode.Impulse);
    }
}