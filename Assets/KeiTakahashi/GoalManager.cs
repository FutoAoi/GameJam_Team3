using UnityEngine;
using TMPro;
using DG.Tweening; // ★DOTweenの魔法を使う

public class GoalManager : MonoBehaviour
{
    // 画面の「GoalText」をハメ込むための箱
    public GameObject goalTextObject;

    private bool isGoal = false;

    // ★プレイヤーが「ゴールエリア」に入った瞬間に自動で実行される呪文
    private void OnTriggerEnter(Collider other)
    {
        // まだゴールしていなくて、触った相手が「Player（プレイヤー）」だったら
        if (!isGoal && other.CompareTag("Player"))
        {
            isGoal = true;
            PlayGoalEffects();
        }
    }

    // ゴールしたときの豪華な演出
    void PlayGoalEffects()
    {
        Debug.Log("ゴール！おめでとう！");

        if (goalTextObject != null)
        {
            // ① 隠しておいた文字を画面に表示する！
            goalTextObject.SetActive(true);

            // ② 【DOTweenの魔法】大きさをいったん「0」にする
            goalTextObject.transform.localScale = Vector3.zero;

            // ③ 0.5秒かけて「1.2倍」に大きくして、最後に「1倍」でピタッと止める！
            // SetEase(Ease.OutBack) でポヨンとした気持ちいい動きになります
            goalTextObject.transform.DOScale(1f, 0.5f).SetEase(Ease.OutBack);
        }

        // ④ ゴールしたのでゲームの動きを一時停止する
        Time.timeScale = 0f;
    }
}
