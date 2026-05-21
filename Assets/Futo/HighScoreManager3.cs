using System.Collections.Generic;
using UnityEngine;

public class HighScoreManager3 : MonoBehaviour
{
    private const string SaveKey3 = "HighScores3";

    public List<float> HighScores3 { get; private set; } = new();

    private void Awake()
    {
        Load();
    }

    /// <summary>
    /// タイムを追加
    /// 小さいほど良いタイム（タイムアタック想定）
    /// </summary>
    public void AddScore(float time)
    {
        HighScores3.Add(time);

        // 昇順ソート（速い順）
        HighScores3.Sort();

        // 3件だけ残す
        if (HighScores3.Count > 3)
        {
            HighScores3.RemoveRange(3, HighScores3.Count - 3);
        }

        Save();
    }

    /// <summary>
    /// 保存
    /// </summary>
    private void Save()
    {
        string json = JsonUtility.ToJson(new ScoreData3(HighScores3));
        PlayerPrefs.SetString(SaveKey3, json);
        PlayerPrefs.Save();
    }

    /// <summary>
    /// 読み込み
    /// </summary>
    private void Load()
    {
        if (!PlayerPrefs.HasKey(SaveKey3))
        {
            HighScores3 = new List<float>();
            return;
        }

        string json = PlayerPrefs.GetString(SaveKey3);
        ScoreData3 data = JsonUtility.FromJson<ScoreData3>(json);

        HighScores3 = data.scores ?? new List<float>();
    }

    /// <summary>
    /// スコア削除用
    /// </summary>
    public void ResetScores()
    {
        PlayerPrefs.DeleteKey(SaveKey3);
        HighScores3.Clear();
    }

    [System.Serializable]
    private class ScoreData3
    {
        public List<float> scores;

        public ScoreData3(List<float> scores)
        {
            this.scores = scores;
        }
    }
}