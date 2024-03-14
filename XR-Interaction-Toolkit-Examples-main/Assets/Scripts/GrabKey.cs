using UnityEngine;
using UnityEngine.VFX;

public class GrabKey : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private VisualEffect _effect;

    public void ActivateGravity()
    {
        _rb.useGravity = true;
        _effect.enabled = false;
    }
}