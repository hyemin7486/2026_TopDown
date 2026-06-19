using TMPro;
using UnityEngine;

public class TimeUI : MonoBehaviour
{
    public TextMeshProUGUI timeText;

    public static float surviveTime;

    private void Start()
    {
        surviveTime = 0;
    }

    private void Update()
    {
        surviveTime += Time.deltaTime;

        timeText.text =
            Mathf.FloorToInt(surviveTime) + "√ ";
    }
}