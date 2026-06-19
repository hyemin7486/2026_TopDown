using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    public GameObject panel;

    public TextMeshProUGUI bestTimeText;
    public TextMeshProUGUI currentTimeText;

    private void Start()
    {
        GameManager.Instance.gameOverUI = this;

        panel.SetActive(false);
    }

    public void Show(float currentTime)
    {
        Time.timeScale = 0f;

        panel.SetActive(true);

        bestTimeText.text =
            "최고 기록 : " +
            GameDataManager.Instance.saveData.bestTime.ToString("F2") +
            "초";

        currentTimeText.text =
            "이번 기록 : " +
            currentTime.ToString("F2") +
            "초";
    }

    public void Retry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoTitle()
    {
        Time.timeScale = 1f;
        GameManager.Instance.GoTitle();
    }
}