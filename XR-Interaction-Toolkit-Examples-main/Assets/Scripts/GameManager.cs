using System;
using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static event Action OnLampsReset;
    public static event Action OnLampsSolved;
    private bool[] _lamps;
    public AudioSource _successSound;

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

        if (isOn) StartCoroutine(CheckLight(id));
    }

    private IEnumerator CheckLight(int id)
    {
        yield return new WaitForSeconds(1);

        for (int i = 0; i < id; i++)
        {
            Debug.Log(_lamps[i]);
            if (!_lamps[i])
            {
                OnLampsReset?.Invoke();
                yield break;
            }
        }

        yield return new WaitForSeconds(1);

        if (id == 4)
        {
            Debug.Log("Puzzle solved");
            OnLampsSolved?.Invoke();
            PuzzleComplete();
        }

        yield return null;
    }

    private void PuzzleComplete()
    {
        _successSound.Play();
    }
}