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

    private void Start()
    {
        // シーン開始時にフェードイン
        fadeImage.color = new Color(0, 0, 0, 1);

        fadeImage.DOFade(0f, fadeTime);
    }

    public void StartGame(string loadScene)
    {
        // フェードアウト
        fadeImage.DOFade(1f, fadeTime)
        .OnComplete(() =>
        {
            // シーン移動
            SceneManager.LoadScene(loadScene);
        });
    }
}