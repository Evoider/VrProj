using HarmonyLib;
using System;
using UnityEngine;

public class SwitchLamp : MonoBehaviour
{
    public static event Action<int, bool> OnSwitch;

    [SerializeField] Light[] _lights;
    [SerializeField] int _id;

    [SerializeField] private GameObject _cluePrefab;

    private bool _canSwitch = true;
    private bool _isSolved = false;

    public AudioSource _player;

    private void Awake()
    {
        GameManager.OnLampsSolved += GameManager_OnLampsSolved;

        GameObject go = Instantiate(_cluePrefab, transform.position, Quaternion.identity, transform);
        go.GetComponent<SwitchLamp_SetKanji>().SetKanjiId(_id);
        _lights.AddRangeToArray(go.GetComponents<Light>());
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

        _player.Play();
    }

    private void GameManager_OnLampsReset()
    {
        Switch(false);
    }
}