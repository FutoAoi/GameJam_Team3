using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class ResultUI : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI _scoreText;
    [SerializeField]
    TextMeshProUGUI _rank1ScoreText;
    [SerializeField]
    TextMeshProUGUI _rank2ScoreText;
    [SerializeField]
    TextMeshProUGUI _rank3ScoreText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int score = GameManager.score;

        int score1 = PlayerPrefs.GetInt("Score1", 9999);
        int score2 = PlayerPrefs.GetInt("Score2", 9999);
        int score3 = PlayerPrefs.GetInt("Score3", 9999);


        if(score < score1)
        {
            score3 = score2;
            score2 = score1;
            score1 = score;
        }
        else if(score < score2)
        {
            score3 = score2;
            score2 = score;
        }
        else if(score < score3)
        {
            score3 = score;
        }

        PlayerPrefs.SetInt("Score1", score1);
        PlayerPrefs.SetInt("Score2", score2);
        PlayerPrefs.SetInt("Score3", score3);
        PlayerPrefs.Save();


        _scoreText.text = "Score : " + TimeText(score);
        _rank1ScoreText.text = "1st : " + TimeText(score1);
        _rank2ScoreText.text = "2nd : " + TimeText(score2);
        _rank3ScoreText.text = "3rd : " + TimeText(score3);
    }

    string TimeText(int time)
    {
        return (time / 60).ToString("00") + ":" + (time % 60).ToString("00");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // public void BackTitle()
    //{
    //    SceneManager.LoadScene("TitleScene");
    //}

}
