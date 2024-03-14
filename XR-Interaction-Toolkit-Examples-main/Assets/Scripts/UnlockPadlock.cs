using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class UnlockPadlock : MonoBehaviour
{
    
    [SerializeField] private AudioSource _clic;
    public static event Action OnUnlock;

    public void Unlock(SelectEnterEventArgs args)
    {
        _clic.Play();
        OnUnlock?.Invoke();
        Destroy(args.interactableObject.transform.gameObject);
    }
}