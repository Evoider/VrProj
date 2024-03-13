using System;
using UnityEngine;

public class FadeInHUD : MonoBehaviour
{
    public static event Action OnActivate;

    [SerializeField] private Animation _animation;
    [SerializeField] private AnimationClip _clip;

    private void Awake()
    {
        GrabCamera.OnCameraGrab += GrabCamera_OnCameraGrab;
    }

    private void OnDestroy()
    {
        GrabCamera.OnCameraGrab -= GrabCamera_OnCameraGrab;
    }

    private void GrabCamera_OnCameraGrab()
    {
        _animation.Play(_clip.name);
        OnActivate?.Invoke();
    }
}