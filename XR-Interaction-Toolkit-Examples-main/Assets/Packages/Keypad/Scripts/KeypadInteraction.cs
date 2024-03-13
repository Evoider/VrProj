using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

namespace NavKeypad { 
public class KeypadInteraction : MonoBehaviour
{
    [SerializeField] private XRRayInteractor LeftRayInteractor;
    [SerializeField] private XRRayInteractor RightRayInteractor;
    [SerializeField] private InputActionReference LeftInputActionReference;
    [SerializeField] private InputActionReference RightInputActionReference;

    private void Update()
    {
        ClickOnButton(LeftRayInteractor, LeftInputActionReference);
        ClickOnButton(RightRayInteractor, RightInputActionReference);
    }

    private void ClickOnButton(XRRayInteractor rayInteractor, InputActionReference inputActionReference)
    {
        RaycastHit res;
        if (!rayInteractor.TryGetCurrent3DRaycastHit(out res)) return;
        {
            if (!inputActionReference.action.triggered) return;
            Debug.Log("Button Pressed");
            if (res.collider.TryGetComponent(out KeypadButton keypadButton))
            {
                keypadButton.PressButton();
            }
        }
    }
}
}