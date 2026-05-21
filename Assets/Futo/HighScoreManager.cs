using System.Collections.Generic;
using UnityEngine;

public class HighScoreManager : MonoBehaviour
{
    private const string SaveKey = "HighScores";

    public List<float> HighScores { get; private set; } = new();

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
        HighScores.Add(time);

        // 昇順ソート（速い順）
        HighScores.Sort();

        // 3件だけ残す
        if (HighScores.Count > 3)
        {
            HighScores.RemoveRange(3, HighScores.Count - 3);
        }

        Save();
    }

    /// <summary>
    /// 保存
    /// </summary>
    private void Save()
    {
        string json = JsonUtility.ToJson(new ScoreData(HighScores));
        PlayerPrefs.SetString(SaveKey, json);
        PlayerPrefs.Save();
    }

    /// <summary>
    /// 読み込み
    /// </summary>
    private void Load()
    {
        if (!PlayerPrefs.HasKey(SaveKey))
        {
            HighScores = new List<float>();
            return;
        }

        string json = PlayerPrefs.GetString(SaveKey);
        ScoreData data = JsonUtility.FromJson<ScoreData>(json);

        HighScores = data.scores ?? new List<float>();
    }

    /// <summary>
    /// スコア削除用
    /// </summary>
    public void ResetScores()
    {
        PlayerPrefs.DeleteKey(SaveKey);
        HighScores.Clear();
    }

    [System.Serializable]
    private class ScoreData
    {
        public List<float> scores;

        public ScoreData(List<float> scores)
        {
            this.scores = scores;
        }
    }
}