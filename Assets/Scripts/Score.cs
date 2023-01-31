using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Score : MonoBehaviour
{
    public string playerName;
    public int score;

    //constructor:
    public Score(string _name, int _score)
    {
        this.playerName = _name;
        this.score = _score;
    }
}
