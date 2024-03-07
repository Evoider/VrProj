using NaughtyAttributes;
using System;
using UnityEngine;

public class GravityTrigger : MonoBehaviour
{
    public static event Action OnGravity;
    [SerializeField, Tag] private string _player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != _player) return;
        OnGravity?.Invoke();
    }
}