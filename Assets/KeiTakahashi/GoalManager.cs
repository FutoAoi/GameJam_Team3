using UnityEngine;
using TMPro;
using DG.Tweening; // ★DOTweenを使うよ！

public class GoalManager : MonoBehaviour
{
    // 画面の「GoalText」をハメ込むための箱
    public GameObject goalTextObject;
    [SerializeField] private SceneMove _sceneMove;

    private bool isGoal = false;

    // プレイヤーがゴールに入った瞬間に自動で実行される呪文
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

            // ② 大きさをいったん「0」にする
            goalTextObject.transform.localScale = Vector3.zero;

            // ③ 【超重要！】0.5秒かけて1倍に大きくする
            // ★うしろに「.SetUpdate(true)」をつけるのがポイント！
            // これをつけると、ゲームの時間を止めても、このアニメーションだけはフリーズせずに動いてくれます！
            goalTextObject.transform.DOScale(1f, 0.5f)
                .SetEase(Ease.OutBack)
                .SetUpdate(true).OnComplete(() => _sceneMove.StartGame("ResultScene"));
        }

    }
}
