using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.IO;
public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public List<ScoreEntry> scores;


    //constructor: CAN WE USE IT SOMEHOW?
    //public ScoreManager()
    //{
    //    scores = new List<Scoree>();
    //}

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        // LoadData();
    }

    //public void AddNames()
    // {
    //     scores.Add(new Scoree("Alice", 12));
    //     scores.Add(new Scoree("Poly", 3));
    //     scores.Add(new Scoree("Jo", 2));
    //     scores.Add(new Scoree("Bob", 16));
    //     scores.Add(new Scoree("Mike", 8));
    //     scores.Add(new Scoree("Hud", 78));
    //     scores.Add(new Scoree("Loli", 45));
    //     scores.Add(new Scoree("Pit", 3));
    // }

    public ScoreEntry AddScoreEntry(string _name, int _score)
    {
        // scores.Add(_score);

        ScoreEntry entry = new ScoreEntry();
        entry.playerNameEntry = _name;
        entry.scoreEntry = _score;
        return entry;
    }

    public IEnumerable<ScoreEntry> GetHighScores(List<ScoreEntry> _scores)
    {
        return _scores.OrderByDescending(player => player.scoreEntry);
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

public class HighScores : MonoBehaviour
{
    public List<ScoreEntry> scores = new List<ScoreEntry>();
}


public class ScoreEntry : MonoBehaviour
{
    /*Represents a single high score entry*/
    //[System.Serializable]
    public string playerNameEntry;
    public int scoreEntry;

    //constructor:
    //public ScoreEntry(string _name, int _score)
    //{
    //    this.playerNameEntry = _name;
    //    this.scoreEntry = _score;
    //}
}
