using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Arrow"))
            return;

        if (GameDataManager.Instance.saveData.shieldCount > 0)
        {
            GameDataManager.Instance.saveData.shieldCount--;

            GameDataManager.Instance.SaveJsonData();

            Debug.Log("방패 사용");

            Destroy(collision.gameObject);

            return;
        }

        Debug.Log("게임오버 실행");

        GameManager.Instance.GameOver();
    }
}