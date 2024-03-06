using UnityEngine;

public class ThrowEffect : MonoBehaviour
{
    [SerializeField] private int _forceAmount;
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
        //_rb.AddForce(Vector3.up * _forceAmount, ForceMode.Impulse);
        _rb.AddForce(Random.insideUnitSphere * 500f, ForceMode.Impulse);
    }

}