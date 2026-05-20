using UnityEngine;
using TMPro;
using DG.Tweening; // ★DOTweenを使うよ！

public class TimeManager : MonoBehaviour
{
    [SerializeField] private float _timeoverTime = 180;
    [SerializeField] private TextMeshProUGUI _timerText;
    [SerializeField] private GameObject _timeOverTextObject;

    private float _time;
    private bool _isTimerRunning = false;
    private int _minutes, _seconds, _ms;
    private float _remain;


    void Update()
    {
        if (_isTimerRunning)
        {
            _time += Time.deltaTime;
        }

        if (_timerText != null)
        {
            _timerText.text = "タイム: " + GetTimeString();
        }

        if (_time >= 180f && _isTimerRunning)
        {
            _isTimerRunning = false;
            TimeOver();
        }
    }

    // カウントダウン終了時に呼び出されるスタート合図
    public void SwichTimer()
    {
        _isTimerRunning = !_isTimerRunning;
    }

    void TimeOver()
    {
        _timerText.text = "TIME UP!";

        if (_timeOverTextObject != null)
        {
            _timeOverTextObject.SetActive(true);

            _timeOverTextObject.transform.localScale = Vector3.zero;
            _timeOverTextObject.transform.DOScale(1f, 0.5f)
                .SetEase(Ease.OutBack)
                .SetUpdate(true);
        }
    }

    public string GetTimeString()
    {
        _minutes = (int)(_time / 60);
        _remain = _time % 60;

        _seconds = (int)_remain;
        _ms = (int)((_remain - _seconds) * 100);

        return _minutes.ToString("00") + ":" +
               _seconds.ToString("00") + "." +
               _ms.ToString("00");
    }
}
