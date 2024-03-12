using System;
using TMPro;
using UnityEngine;

public class SwitchLamp : MonoBehaviour
{
    public static event Action<int, bool> OnSwitch;

    [SerializeField] Light[] _lights;
    [SerializeField] int _id;
    [SerializeField] TMP_Text _kanji;

    private string[] _kanjiList;
    private bool _canSwitch = true;
    private bool _isSolved = false;

    // TODO -> activate input

    private void Awake()
    {
        _kanjiList = new string[5] { "月", "火", "水", "木", "金" };
        _kanji.text = _kanjiList[_id];

        GameManager.OnLampsSolved += GameManager_OnLampsSolved;
    }

    private void OnDestroy()
    {
        GameManager.OnLampsSolved -= GameManager_OnLampsSolved;
    }

    private void GameManager_OnLampsSolved()
    {
        _isSolved = true;
    }

    public void Switch(bool isOn)
    {
        if (!_canSwitch || _isSolved) return;
        if (isOn) GameManager.OnLampsReset += GameManager_OnLampsReset;
        else GameManager.OnLampsReset -= GameManager_OnLampsReset;

        foreach (Light light in _lights)
        {
            light.gameObject.SetActive(isOn);
        }

        OnSwitch?.Invoke(_id, isOn);
    }

    private void GameManager_OnLampsReset()
    {
        Switch(false);
    }
}