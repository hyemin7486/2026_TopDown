using UnityEngine;

public class TitleManager : MonoBehaviour
{
    public void StartGame()
    {
        GameManager.Instance.StartGame();
    }

    public void QuitGame()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}