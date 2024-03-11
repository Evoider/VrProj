using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HandAnim : MonoBehaviour
{
    [SerializeField] private InputActionReference gripReference;
    [SerializeField] private InputActionReference pinchReference;

    [SerializeField] private Animator animator;
    
    

    // Update is called once per frame
    void Update()
    {
        float gripValue = gripReference.action.ReadValue<float>();
        animator.SetFloat("Grip", gripValue);
        float pinchValue = pinchReference.action.ReadValue<float>();
        animator.SetFloat("Pinch", pinchValue);
    }
}
