using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ScoreUI : MonoBehaviour
{
    public GridRowsUi rowUI; //prefab
    public ScoreManager scoreManager;

    void Start()
    {
        scoreManager.AddScore(new Score("Jim",5));
        scoreManager.AddScore(new Score("Loony", 3));
        scoreManager.AddScore(new Score("Clara", 7));

        var scores = scoreManager.GetHighScores().ToArray();

        for (int i = 0; i < scores.Length; i++)
        {
            var row = Instantiate(rowUI, transform).GetComponent<GridRowsUi>();
            row.rankText.text = (i + 1).ToString();
            row.nameText.text = scores[i].playerName.ToString();
            row.scoreText.text = scores[i].score.ToString();
        }
    }
}
