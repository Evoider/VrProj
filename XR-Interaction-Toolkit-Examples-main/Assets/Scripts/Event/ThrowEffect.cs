using UnityEngine;

public class ThrowEffect : MonoBehaviour
{
    private Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();

        ThrowTrigger.OnThrow += ThrowTrigger_OnThrow;
    }

    private void OnDestroy()
    {
        ThrowTrigger.OnThrow -= ThrowTrigger_OnThrow;

    }

    private void ThrowTrigger_OnThrow()
    {
        Activate();
    }

    public void Activate()
    {
        _rb.AddForce(Random.insideUnitSphere * 10f, ForceMode.Impulse);
        ThrowTrigger.OnThrow -= ThrowTrigger_OnThrow;
    }

}