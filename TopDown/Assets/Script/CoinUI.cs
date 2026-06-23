using TMPro;
using UnityEngine;

public class CoinUI : MonoBehaviour
{
    public static CoinUI Instance;

    public TextMeshProUGUI coinText;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        UpdateCoin();
    }

    public void UpdateCoin()
    {
        coinText.text =
            "ÄÚÀÎ : " +
            GameDataManager.Instance.saveData.coin;
    }
}