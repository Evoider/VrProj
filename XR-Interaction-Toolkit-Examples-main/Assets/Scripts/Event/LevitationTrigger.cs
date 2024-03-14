using System;
using UnityEngine;

public class LevitationTrigger : MonoBehaviour
{
    public static event Action OnLevitated;
    [SerializeField] private AudioSource _tableMoving;

    private void OnTriggerEnter(Collider other)
    {
        _tableMoving.Play();
        OnLevitated?.Invoke();

    }
}