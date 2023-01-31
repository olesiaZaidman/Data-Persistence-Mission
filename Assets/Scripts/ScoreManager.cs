using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.IO;
public class ScoreManager : MonoBehaviour
{
    private ScoreData scoreData;

    void Awake()
    {
        //    LoadScore();      // used to scoreData = new ScoreData();
        scoreData = new ScoreData();
    }

    public IEnumerable<Score> GetHighScores()
    {
        return scoreData.bestScores.OrderByDescending(x => x.score);
        //first  is an argument
        //second part is expression  to return
    }

    public void AddScore(Score _score)
    {
        scoreData.bestScores.Add(_score);
    }

    private void OnDestroy()
    {
       // SaveScore();
    }

    //public void SaveScore() //on GameOver
    //{
    //    string json = JsonUtility.ToJson(scoreData);
    //    File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    //}

    //public void LoadScore()
    //{
    //    string path = Application.persistentDataPath + "/savefile.json";
    //    if (File.Exists(path))
    //    {
    //        string json = File.ReadAllText(path);
    //        scoreData = JsonUtility.FromJson<ScoreData>(json);
    //    }
    //}

}
