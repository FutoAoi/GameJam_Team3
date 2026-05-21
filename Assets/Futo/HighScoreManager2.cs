using System.Collections.Generic;
using UnityEngine;

public class HighScoreManager2 : MonoBehaviour
{
    private const string SaveKey2 = "HighScores2";

    public List<float> HighScores2 { get; private set; } = new();

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
        HighScores2.Add(time);

        // 昇順ソート（速い順）
        HighScores2.Sort();

        // 3件だけ残す
        if (HighScores2.Count > 3)
        {
            HighScores2.RemoveRange(3, HighScores2.Count - 3);
        }

        Save();
    }

    /// <summary>
    /// 保存
    /// </summary>
    private void Save()
    {
        string json = JsonUtility.ToJson(new ScoreData2(HighScores2));
        PlayerPrefs.SetString(SaveKey2, json);
        PlayerPrefs.Save();
    }

    /// <summary>
    /// 読み込み
    /// </summary>
    private void Load()
    {
        if (!PlayerPrefs.HasKey(SaveKey2))
        {
            HighScores2 = new List<float>();
            return;
        }

        string json = PlayerPrefs.GetString(SaveKey2);
        ScoreData2 data = JsonUtility.FromJson<ScoreData2>(json);

        HighScores2 = data.scores ?? new List<float>();
    }

    /// <summary>
    /// スコア削除用
    /// </summary>
    public void ResetScores()
    {
        PlayerPrefs.DeleteKey(SaveKey2);
        HighScores2.Clear();
    }

    [System.Serializable]
    private class ScoreData2
    {
        public List<float> scores;

        public ScoreData2(List<float> scores)
        {
            this.scores = scores;
        }
    }
}