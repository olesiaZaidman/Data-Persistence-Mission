using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ScoreUI : MonoBehaviour
{
    public GridRowsUi rowUI; //prefab
  //  public ScoreManager scoreManager;

    public List<GridRowsUi> rowEntries;

    void Start()
    { 
        CreateNewRowOfPlayerScoreRating(ScoreManager.Instance.scores, rowEntries);
    }

    void CreateNewRowOfPlayerScoreRating(List<ScoreEntry> _scores, List<GridRowsUi> _rowEntries)
    {
        var scores = ScoreManager.Instance.GetHighScores(_scores).ToArray();
        int numberOfResults = Mathf.Clamp(scores.Length,0,5);

        for (int i = 0; i < numberOfResults; i++)  // for (int i = 0; i < scores.Length; i++)
        {
            var row = Instantiate(rowUI, transform).GetComponent<GridRowsUi>();

            int rank = i + 1;
            string rankString;

            switch (rank)
            {
                case 1:
                    rankString = "1st";
                    break;
                case 2:
                    rankString = "2nd";
                    break;
                case 3:
                    rankString = "3rd";
                    break;
                default:
                    rankString = rank.ToString()+"th";
                    break;
            }
            int playerScore = scores[i].scoreEntry;             //for Test: Random.Range(0,100);
            string playerName = scores[i].playerNameEntry.ToString(); //for Test: "--";
            row.rankText.text = rankString;            //row.rankText.text = (i + 1).ToString();
                                                    
                                                 
            row.nameText.text = playerName;  //  row.nameText.text = scores[i].playerName.ToString();
            row.scoreText.text = playerScore.ToString();     //   row.scoreText.text = scores[i].score.ToString();

            _rowEntries.Add(row);
        }
    }


}

