using TMPro;
using UnityEngine;

public class CodePiece : MonoBehaviour
{
    [SerializeField] private CodeDisplay _codeDisplay;
    [SerializeField] private TMP_Text _text;

    private char _code;
    private int _index;

    public void InitCode(char code, int index)
    {
        _code = code;
        _index = index;
        _text.text = _code.ToString();
    }

    public void AddToCodeDisplay()
    {
        _codeDisplay.AddCodeDigit(_code, _index);
        Destroy(gameObject);
    }
}