using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class SceneMove : MonoBehaviour
{
    [Header("フェード用の画像")]
    public Image fadeImage;

    [Header("フェード時間")]
    public float fadeTime = 1f;

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
}