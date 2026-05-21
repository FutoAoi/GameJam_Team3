using UnityEngine;
using TMPro;
using DG.Tweening; // ★DOTweenを使うよ！

public class GoalManager : MonoBehaviour
{
    // 画面の「GoalText」をハメ込むための箱
    public GameObject goalTextObject;
    [SerializeField] private SceneMove _sceneMove;
    [SerializeField] private TimeManager _timeManager;
    [SerializeField] private HighScoreManager2 _scoreManager2;
    [SerializeField] private HighScoreManager3 _scoreManager3;
    [SerializeField] private HighScoreManager _scoreManager;
    [SerializeField] private GameObject _resultPanel;
    [SerializeField] private TMP_Text _resultText;

    private bool isGoal = false;

    // プレイヤーがゴールに入った瞬間に自動で実行される呪文
    private void OnTriggerEnter(Collider other)
    {
        // まだゴールしていなくて、触った相手が「Player（プレイヤー）」だったら
        if (!isGoal && other.CompareTag("Player"))
        {
            if(_scoreManager != null)
            {
                _scoreManager.AddScore(_timeManager.NowTime);
            }
            if (_scoreManager2 != null)
            {
                _scoreManager2.AddScore(_timeManager.NowTime);
            }
            if (_scoreManager3 != null)
            {
                _scoreManager3.AddScore(_timeManager.NowTime);
            }
            _resultText.text = _timeManager.GetTimeString();
            isGoal = true;
            PlayGoalEffects();
        }
    }

    // ゴールしたときの豪華な演出
    void PlayGoalEffects()
    {

        if (goalTextObject != null)
        {
            _timeManager.SwichTimer();
            // ① 隠しておいた文字を画面に表示する！
            goalTextObject.SetActive(true);

            // ② 大きさをいったん「0」にする
            goalTextObject.transform.localScale = Vector3.zero;

            // ③ 【超重要！】0.5秒かけて1倍に大きくする
            // ★うしろに「.SetUpdate(true)」をつけるのがポイント！
            // これをつけると、ゲームの時間を止めても、このアニメーションだけはフリーズせずに動いてくれます！
            goalTextObject.transform.DOScale(1f, 0.5f)
                .SetEase(Ease.OutBack)
                .SetUpdate(true).OnComplete(() => PopupResultPanel());
        }
    }

    public void PopupResultPanel()
    {
        _resultPanel.SetActive(true);

        // 最初小さくする
        _resultPanel.transform.localScale = Vector3.zero;

        // 拡大アニメーション
        _resultPanel.transform.DOScale(1f, 0.3f)
            .SetEase(Ease.OutBack);
    }
}
