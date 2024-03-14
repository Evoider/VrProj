using UnityEngine;

public class GrabKey : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;

    public void ActivateGravity()
    {
        _rb.useGravity = true;
    }
}