using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static event Action OnLampsReset;
    public static event Action OnLampsSolved;
    private bool[] _lamps;

    private void Awake()
    {
        InitLamps();
    }

    private void OnDestroy()
    {
        SwitchLamp.OnSwitch -= SwitchLamp_OnSwitch;
    }

    private void InitLamps()
    {
        SwitchLamp.OnSwitch += SwitchLamp_OnSwitch;

        _lamps = new bool[5];

        for (int i = 0; i < 5; i++)
        {
            _lamps[i] = false;
        }
    }

    private void SwitchLamp_OnSwitch(int id, bool isOn)
    {
        _lamps[id] = isOn;

        if (isOn)
        {
            for (int i = 0;i < id; i++)
            {
                if (!_lamps[i])
                {
                    OnLampsReset?.Invoke();
                    return;
                }
            }
        }

        if (id == 5)
        {
            Debug.Log("Puzzle solved");
            OnLampsSolved?.Invoke();
            PuzzleComplete();
        }
    }

    private void PuzzleComplete()
    {
        // TODO -> drop key, sound
    }
}