using System.Collections;
using UnityEngine;

public class LevitationEffect : MonoBehaviour
{
    [SerializeField] private float levitationHeight = 0.1f;
    [SerializeField] private float levitationSpeed = 1.0f;

    private Rigidbody _rb;
    private Vector3 _startPos;
    private bool _levitate = false;
    [SerializeField] private float _forceUp = 0.7f;
     
    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();

        ThrowTrigger.OnThrow += ThrowTrigger_OnThrow;
        LevitationTrigger.OnLevitated += SchoolSceneController_OnLevitated;
    }

    private void ThrowTrigger_OnThrow()
    {
        _levitate = false;
        _rb.useGravity = true;
        _rb.constraints = RigidbodyConstraints.None;
        ThrowTrigger.OnThrow -= ThrowTrigger_OnThrow;
    }

    private void FixedUpdate()
    {
        if (_levitate)
        {
            Vector3 newPosition = _startPos + new Vector3(0, Mathf.Sin(Time.time * levitationSpeed) * levitationHeight, 0);
            transform.position = newPosition; // Déplace l'objet vers la nouvelle position
        }
    }

    private void OnDestroy()
    {
        LevitationTrigger.OnLevitated -= SchoolSceneController_OnLevitated;
        ThrowTrigger.OnThrow -= ThrowTrigger_OnThrow;
    }

    private void SchoolSceneController_OnLevitated()
    {
        StartCoroutine(Up());
        LevitationTrigger.OnLevitated -= SchoolSceneController_OnLevitated;
    }

    private IEnumerator Up()
    {
        _rb.AddForce(Vector3.up * _forceUp, ForceMode.Impulse);
        _rb.useGravity = false;
        yield return new WaitForSeconds(2);
        _startPos = transform.position;
        _levitate = true;
    }
}