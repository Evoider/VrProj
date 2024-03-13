using System;
using UnityEngine;

public class GrabCamera : MonoBehaviour
{
    public static event Action OnCameraGrab;

    public void Grab()
    {
        OnCameraGrab?.Invoke();
    }
}