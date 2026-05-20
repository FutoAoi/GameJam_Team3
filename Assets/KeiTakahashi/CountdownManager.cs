using System.Collections;
using UnityEngine;
using TMPro;
using DG.Tweening; // ★DOTweenの呪文を使うための「辞書」を開くよ！

public class CountdownManager : MonoBehaviour
{
    [SerializeField] private PlayerMoveInputSystem _moveInputSystem;
    [SerializeField] private TextMeshProUGUI _countdownText;

    void Start()
    {
        // ゲーム開始時にカウントダウンをスタート
        StartCoroutine(CountdownRoutine());
    }

    IEnumerator CountdownRoutine()
    {
        // 1. 最初は「3」を表示して、アニメーション！
        PlayTextWithAnimation("3");
        yield return new WaitForSeconds(1.0f); // 1秒待つ

        // 2. 「2」を表示して、アニメーション！
        PlayTextWithAnimation("2");
        yield return new WaitForSeconds(1.0f);

        // 3. 「1」を表示して、アニメーション！
        PlayTextWithAnimation("1");
        yield return new WaitForSeconds(1.0f);

        // 4. 「Go!」を表示して、アニメーション！
        PlayTextWithAnimation("Go!");

        // ★追加：TimeManager（タイマー）を見つけて、タイマーをスタートさせる！
        TimeManager timeManager = FindFirstObjectByType<TimeManager>();
        if (timeManager != null)
        {
            timeManager.SwichTimer();
            _moveInputSystem.CanMove = true;
        }

        Debug.Log("ゲームスタート！");
        yield return new WaitForSeconds(1.0f);

        // 5. 最後に文字をフェードアウト（ふわっと透明にする）して消します
        // 0.3秒かけて文字の透明度を0（見えない状態）にします
        _countdownText.DOFade(0f, 0.3f);
    }

    // ★文字をセットして、DOTweenで動かす
    void PlayTextWithAnimation(string newText)
    {
        // 画面の文字を書き換えます
        _countdownText.text = newText;

        // 文字の透明度を1（完全に見える状態）に戻しておきます（最後のフェードアウト対策）
        _countdownText.color = new Color(_countdownText.color.r, _countdownText.color.g, _countdownText.color.b, 1f);

        // ① 一度、文字の大きさを「0（点のように小さくて見えない状態）」にします
        _countdownText.transform.localScale = Vector3.zero;

        // ② 【1行の魔法！】0.3秒かけて、元の大きさ「1倍」まで大きくします
        // うしろの .SetEase(Ease.OutBack) をつけることで、ちょっと行き過ぎてから戻る弾む動きになります
        _countdownText.transform.DOScale(3f, 0.3f).SetEase(Ease.OutBack);
    }
}