using NUnit.Framework;
using TMPro;
using UnityEngine;

public class HighScoreText : MonoBehaviour
{
    private int _minutes, _seconds, _ms;
    private float _remain;
    [SerializeField] private HighScoreManager _manager;
    [SerializeField] private HighScoreManager2 _manager2;
    [SerializeField] private HighScoreManager3 _manager3;

    [SerializeField] private TMP_Text[] List1;
    [SerializeField] private TMP_Text[] List2;
    [SerializeField] private TMP_Text[] List3;

    private void Start()
    {
        SetText();
    }
    public void SetText()
    {
        for(int i = 0; i < _manager.HighScores.Count; i++)
        {
            List1[i].text = GetTimeString(_manager.HighScores[i]);
        }
        for (int i = 0; i < _manager2.HighScores2.Count; i++)
        {
            List2[i].text = GetTimeString(_manager2.HighScores2[i]);
        }
        for (int i = 0; i < _manager3.HighScores3.Count; i++)
        {
            List3[i].text = GetTimeString(_manager3.HighScores3[i]);
        }
    }

    public string GetTimeString(float time)
    {
        _minutes = (int)(time / 60);
        _remain = time % 60;

        _seconds = (int)_remain;
        _ms = (int)((_remain - _seconds) * 100);

        return _minutes.ToString("00") + ":" +
               _seconds.ToString("00") + "." +
               _ms.ToString("00");
    }
}
