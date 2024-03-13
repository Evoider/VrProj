using System.Text;
using TMPro;
using UnityEngine;

public class CodeDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text codeText;
    private string code = "____"; 

    public void AddCodeDigit(char digit, int index)
    {
        StringBuilder newCode = new(code);
        newCode[index] = digit;
        code = newCode.ToString();
        codeText.text = code;
    }
}