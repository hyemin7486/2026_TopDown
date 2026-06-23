using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public string titleSceneName = "TitleScene";
    public string gameSceneName = "GameScene";

    [HideInInspector]
    public GameOverUI gameOverUI;

    private void Awake()
    {
        Instance = this;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(gameSceneName);
    }

    public void GameOver()
    {
        Debug.Log("게임오버 호출");

        GameDataManager.Instance.SaveGameResult();

        if (TimeUI.surviveTime > GameDataManager.Instance.saveData.bestTime)
        {
            GameDataManager.Instance.saveData.bestTime = TimeUI.surviveTime;
            GameDataManager.Instance.SaveJsonData();
        }

        if (gameOverUI != null)
        {
            Debug.Log("게임오버 UI 실행");

            gameOverUI.Show(TimeUI.surviveTime);
        }
        else
        {
            Debug.LogError("게임오버 UI 연결 안됨");
        }
    }

    public void GoTitle()
    {
        SceneManager.LoadScene(titleSceneName);
    }
}