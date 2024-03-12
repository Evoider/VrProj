using System;
using TMPro;
using UnityEngine;

public class CodePiece : MonoBehaviour
{
    [SerializeField] private CodeDisplay _codeDisplay;
    [SerializeField] private TMP_Text _text;

    public void AddToCodeDisplay()
    {
        _codeDisplay.AddCodeDigit(int.Parse(_text.text));
        Destroy(gameObject);

    }
}
