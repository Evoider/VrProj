using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Content.Interaction;

public class ManageContinousTurn : MonoBehaviour
{
    [SerializeField] LocomotionManager manager;
    private bool rotationstyle = true;

    public void EnableContinuousTurn()
    {
        if (rotationstyle == true)
        {
            manager.leftHandTurnStyle = LocomotionManager.TurnStyle.Smooth;
            manager.rightHandTurnStyle = LocomotionManager.TurnStyle.Smooth;
            rotationstyle = false;
        }
        else
        {
            manager.leftHandTurnStyle = LocomotionManager.TurnStyle.Snap;
            manager.rightHandTurnStyle = LocomotionManager.TurnStyle.Snap;
            rotationstyle = true;
        }
    }


}
