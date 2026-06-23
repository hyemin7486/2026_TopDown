using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    public GameObject panel;

    public TextMeshProUGUI bestTimeText;
    public TextMeshProUGUI currentTimeText;

    public TextMeshProUGUI coinText;
    public TextMeshProUGUI shieldText;

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

        RefreshShopUI();
    }

    private void RefreshShopUI()
    {
        coinText.text =
            "보유 코인 : " +
            GameDataManager.Instance.saveData.coin;

        shieldText.text =
            "보유 방패 : " +
            GameDataManager.Instance.saveData.shieldCount;

        Debug.Log("코인텍스트 = " + coinText.text);
        Debug.Log("방패텍스트 = " + shieldText.text);
    }

    public void BuyShield()
    {
        Debug.Log("방패 구매 버튼 클릭");

        if (GameDataManager.Instance.saveData.coin < 10)
        {
            Debug.Log("코인 부족");
            return;
        }

        GameDataManager.Instance.saveData.coin -= 10;
        GameDataManager.Instance.saveData.shieldCount++;

        GameDataManager.Instance.SaveJsonData();

        RefreshShopUI();
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