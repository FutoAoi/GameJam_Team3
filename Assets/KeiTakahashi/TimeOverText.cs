using UnityEngine;
using TMPro;
using DG.Tweening; // ★DOTweenを使うよ！

public class TimeManager : MonoBehaviour
{
    // 右上のタイム表示用
    public TextMeshProUGUI timeText;

    // 時間切れの時に表示するデカい「TIME UP!」の文字
    public GameObject timeOverTextObject;

    // 制限時間（3分 ＝ 180秒）
    public float timeLimit = 180f;

    private bool isTimerRunning = false;

    void Start()
    {
        UpdateText();
    }

    void Update()
    {
        // カウントダウン終了の合図が来たら、時間を減らし始める
        if (isTimerRunning)
        {
            timeLimit -= Time.deltaTime;

            if (timeLimit <= 0)
            {
                timeLimit = 0;
                isTimerRunning = false; // タイマー停止
                TimeOver();
            }

            UpdateText();
        }
    }

    // カウントダウン終了時に呼び出されるスタート合図
    public void StartTimer()
    {
        isTimerRunning = true;
    }

    void UpdateText()
    {
        timeText.text = "TIME: " + Mathf.CeilToInt(timeLimit).ToString();
    }

    // 時間切れになったときの処理
    void TimeOver()
    {
        Debug.Log("タイムアップ！ゲームオーバー！");
        timeText.text = "TIME UP!";

        if (timeOverTextObject != null)
        {
            // ① 隠しておいたデカい「TIME UP!」を画面に表示！
            timeOverTextObject.SetActive(true);

            // ② 一時停止の罠を突破してDOTweenで表示させる！
            timeOverTextObject.transform.localScale = Vector3.zero;
            timeOverTextObject.transform.DOScale(1f, 0.5f)
                .SetEase(Ease.OutBack)
                .SetUpdate(true); // ★時間が止まっても、このアニメだけは動かす設定！
        }

        // ③ ゲームの動きを完全にストップさせる
        Time.timeScale = 0f;
    }
}
