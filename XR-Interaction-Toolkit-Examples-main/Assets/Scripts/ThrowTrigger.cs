using NaughtyAttributes;
using System;
using UnityEngine;

public class ThrowTrigger : MonoBehaviour
{
    public static event Action OnThrow;

    [SerializeField, Tag] private string _player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != _player) return;
        Debug.Log("on throw");
        OnThrow?.Invoke();
    }
}