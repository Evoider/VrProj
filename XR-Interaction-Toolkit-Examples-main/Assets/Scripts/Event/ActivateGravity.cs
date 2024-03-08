using UnityEngine;

public class ActivateGravity : MonoBehaviour
{
    private Rigidbody _rb;


    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();

        GravityTrigger.OnGravity += GravityTrigger_OnGravity;
    }

    private void GravityTrigger_OnGravity()
    {
        _rb.useGravity = true;
    }

    private void OnDestroy()
    {
        GravityTrigger.OnGravity -= GravityTrigger_OnGravity;
    }
}
