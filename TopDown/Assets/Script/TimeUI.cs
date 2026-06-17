using TMPro;
using UnityEngine;

public class TimeUI : MonoBehaviour
{
    public TextMeshProUGUI timeText;

    private float surviveTime;

    private void Update()
    {
        surviveTime += Time.deltaTime;

        timeText.text =
            "생존 시간 : " +
            Mathf.FloorToInt(surviveTime);
    }
}