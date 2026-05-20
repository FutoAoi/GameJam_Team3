using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float time;
    public bool isRunning = true;
    public TMP_Text timeText;

    public TMP_Text timeOverText; // ←追加（これが専用）

    void Update()
    {
        if (isRunning)
        {
            time += Time.deltaTime;
        }

        if (timeText != null)
        {
            timeText.text = "Time: " + GetTimeString();
        }

        // 180秒でタイムオーバー
        if (time >= 180f && isRunning)
        {
            isRunning = false;

            if (timeText != null)
                timeText.gameObject.SetActive(false);

            if (timeOverText != null)
            {
                timeOverText.gameObject.SetActive(true);
                timeOverText.text = "TIME OVER";
            }
        }
    }

    public string GetTimeString()
    {
        int minutes = (int)(time / 60);
        float remain = time % 60;

        int seconds = (int)remain;
        int ms = (int)((remain - seconds) * 100);

        return minutes.ToString("0") + ":" +
               seconds.ToString("00") + "." +
               ms.ToString("00");
    }
}