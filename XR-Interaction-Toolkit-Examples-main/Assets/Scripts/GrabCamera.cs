using System;
using UnityEngine;

public class GrabCamera : MonoBehaviour
{
    public static event Action OnCameraGrab;

    public void Grab()
    {
        Debug.Log("grab camera");
        OnCameraGrab?.Invoke();
    }
}