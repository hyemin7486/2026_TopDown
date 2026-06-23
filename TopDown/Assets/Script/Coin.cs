using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameDataManager.Instance.saveData.coin++;

            GameDataManager.Instance.SaveJsonData();

            CoinUI.Instance.UpdateCoin();

            Destroy(gameObject);
        }
    }
}