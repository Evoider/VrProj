using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CodeDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text codeText;
    private string code = "____"; 

    public void AddCodeDigit(int digit)
    {
        int index = code.IndexOf('_');
        if (index >= 0)
        {
            code = code.Remove(index, 1).Insert(index, digit.ToString());
            UpdateCodeDisplay();
        }
    }

    void UpdateCodeDisplay()
    {
        codeText.text = code;
    }
}
