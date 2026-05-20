using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
using Unity.VisualScripting;

public class SceneMove : MonoBehaviour
{
    [Header("フェード用の画像")]
    public Image fadeImage;

    [Header("フェード時間")]
    public float fadeTime = 1f;

    [Header("クレジットパネル")]
    public GameObject creditPanel;

    [Header("オプションパネル")]
    public GameObject optionPanel;

    // フェード移行したか記録
    private static bool isFade = false;

    private void Start()
    {
        // フェード移行後だけフェードイン
        if (isFade)
        {
            fadeImage.color = new Color(0, 0, 0, 1);

            fadeImage.DOFade(0f, fadeTime);

            isFade = false;
        }
        else
        {
            // 通常開始時は透明
            fadeImage.color = new Color(0, 0, 0, 0);
        }
    }

    public void StartGame(string loadScene)
    {
        // フェード移行フラグON
        isFade = true;

        // フェードアウト
        fadeImage.DOFade(1f, fadeTime)
        .OnComplete(() =>
        {
            SceneManager.LoadScene(loadScene);
        });
    }

    
    // クレジット表示
    public void PopupPanel()
    {
        creditPanel.SetActive(true);

        // 最初小さくする
        creditPanel.transform.localScale = Vector3.zero;

        // 拡大アニメーション
        creditPanel.transform.DOScale(1f, 0.3f)
            .SetEase(Ease.OutBack);
    }

    // クレジットを閉じる
    public void ClosePanel()
    {
        // 縮小してから消す
        creditPanel.transform.DOScale(0f, 0.2f)
            .OnComplete(() =>
            {
                creditPanel.SetActive(false);
            });
    }

    //オプションを表示
    public void PopupOptionPanel()
    {
        optionPanel.SetActive(true);

        // 最初小さくする
        optionPanel.transform.localScale = Vector3.zero;

        // 拡大アニメーション
        optionPanel.transform.DOScale(1f, 0.3f)
            .SetEase(Ease.OutBack);
    }

    // クレジットを閉じる
    public void CloseOptionPanel()
    {
        // 縮小してから消す
        optionPanel.transform.DOScale(0f, 0.2f)
            .OnComplete(() =>
            {
                optionPanel.SetActive(false);
            });
    }
}