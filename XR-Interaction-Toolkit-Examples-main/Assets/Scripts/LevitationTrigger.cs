using System;
using UnityEngine;

public class LevitationTrigger : MonoBehaviour
{
    public static event Action OnLevitated;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("on levitate");
        OnLevitated?.Invoke();
    }
}