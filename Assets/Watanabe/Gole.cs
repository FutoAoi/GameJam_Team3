using UnityEngine;
using TMPro;

public class Gole : MonoBehaviour
{
    public Timer timer;
    public TMP_Text resultText;

    void Start()
    {
        resultText.gameObject.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            timer.isRunning = false;
            timer.timeText.gameObject.SetActive(false);

            float time = timer.time;

            int minutes = (int)(time / 60);
            float remain = time % 60;

            int seconds = (int)remain;
            int ms = (int)((remain - seconds) * 100);

            resultText.gameObject.SetActive(true);
            resultText.text =
                "CLEAR TIME: " +
                minutes + ":" +
                seconds.ToString("00") + "." +
                ms.ToString("00");


        }
    }
}