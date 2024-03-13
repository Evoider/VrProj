using NavKeypad;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

public class GameManager : MonoBehaviour
{
    public static event Action OnLampsReset;
    public static event Action OnLampsSolved;

    [Header("Lamps")]
    [SerializeField] private KeySpawner _lampsKeySpawner;

    [Header("Notes & Keypad")]
    [SerializeField] private KeySpawner _notesKeySpawner;
    [SerializeField] private Keypad _keypad;
    [SerializeField] private CodePiece[] _notes;

    [Header("Music & Sounds")]
    [SerializeField] private AudioSource _player;
    [SerializeField] private AudioClip _successSound;
    [SerializeField] private AudioMixer _mixer;

    private bool[] _lamps;

    private void Awake()
    {
        InitLamps();
        InitNotes();
        _keypad.OnAccessGranted.AddListener(() => PuzzleComplete(_notesKeySpawner));
    }

    private void OnDestroy()
    {
        SwitchLamp.OnSwitch -= SwitchLamp_OnSwitch;
    }

    #region Lamps
    private void SwitchLamp_OnSwitch(int id, bool isOn)
    {
        _lamps[id] = isOn;

        if (isOn) StartCoroutine(CheckLight(id));
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
    private IEnumerator CheckLight(int id)
    {
        yield return new WaitForSeconds(1);

        for (int i = 0; i < id; i++)
        {
            //Debug.Log(_lamps[i]);
            if (!_lamps[i])
            {
                OnLampsReset?.Invoke();
                yield break;
            }
        }

        yield return new WaitForSeconds(.5f);

        if (id == 4)
        {
            Debug.Log("Puzzle solved");
            OnLampsSolved?.Invoke();
            PuzzleComplete(_lampsKeySpawner);
        }

        yield return null;
    }
    #endregion

    #region Notes
    private void InitNotes()
    {
        string combo = _keypad.KeypadCombo.ToString();

        for (int i = 0; i < combo.Length; i++)
        {
            _notes[i].InitCode(combo[i], i);
        }
    }
    #endregion

    private void PuzzleComplete(KeySpawner ks)
    {
        ks.Spawn();
        _mixer.outputAudioMixerGroup = _mixer.FindMatchingGroups("SFX")[0];
        _player.PlayOneShot(_successSound);
    }
}