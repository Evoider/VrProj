using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class UnlockPadlock : MonoBehaviour
{
    public static event Action OnUnlock;

    public void Unlock(SelectEnterEventArgs args)
    {
        OnUnlock?.Invoke();
        Destroy(args.interactableObject.transform.gameObject);
    }
}