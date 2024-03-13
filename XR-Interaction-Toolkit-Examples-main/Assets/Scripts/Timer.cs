using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] Canvas _gameOverCanvas;
    [SerializeField] private TMP_Text timerText;
    private float timeRemaining = 600f; // 10 minutes en secondes

    void Update()
    {
        if (timeRemaining > 0f)
        {
            timeRemaining -= Time.deltaTime;
            UpdateTimerDisplay();
        }
        else
        {
            GameLost();
        }
    }

    void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(timeRemaining / 60f);
        int seconds = Mathf.FloorToInt(timeRemaining % 60f);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void GameLost()
    {
        if (_gameOverCanvas != null)
        {
            _gameOverCanvas.gameObject.SetActive(true);
        }
        Debug.Log("La partie est perdue !");
    }
}
