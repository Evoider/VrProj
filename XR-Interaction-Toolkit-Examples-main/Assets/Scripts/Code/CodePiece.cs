using UnityEngine;

public class CodePiece : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AddToCodeDisplay();
            Destroy(gameObject);
        }
    }

    void AddToCodeDisplay()
    {
        string digitText = GetComponentInChildren<TextMesh>().text;
        if (!string.IsNullOrEmpty(digitText))
        {
            int digit;
            if (int.TryParse(digitText, out digit))
            {
                CodeDisplay codeDisplay = FindObjectOfType<CodeDisplay>();
                if (codeDisplay != null)
                {
                    codeDisplay.AddCodeDigit(digit);
                }
            }
        }
    }
}
