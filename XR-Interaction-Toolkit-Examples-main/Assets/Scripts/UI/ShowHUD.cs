using NaughtyAttributes;
using System;
using TMPro;
using UnityEngine;

public class ShowHUD : MonoBehaviour
{
    public static event Action OnShow;

    [SerializeField] private TMP_Text _text;
    [SerializeField, Layer] private int _playerLayer;

    private void Update()
    {
        transform.LookAt(transform.position + Camera.main.transform.rotation * Vector3.forward, Camera.main.transform.rotation * Vector3.up);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == _playerLayer)
        {
            _text.gameObject.SetActive(true);
            OnShow?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == _playerLayer) _text.gameObject.SetActive(false);
    }
}