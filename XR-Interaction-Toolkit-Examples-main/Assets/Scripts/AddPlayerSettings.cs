using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Content.Interaction;

public class AddPlayerSettings : MonoBehaviour
{

    [SerializeField] LocomotionManager manager;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("snapRot") == 0)
        {
            manager.leftHandTurnStyle = LocomotionManager.TurnStyle.Smooth;
            manager.rightHandTurnStyle = LocomotionManager.TurnStyle.Smooth;
        }
        if (PlayerPrefs.GetInt("comfortMode") == 0)
        {
            manager.enableComfortMode = false;
        }
    }
}
