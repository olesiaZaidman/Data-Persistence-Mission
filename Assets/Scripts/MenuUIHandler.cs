using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MenuUIHandler : MonoBehaviour
{
    [Header("UI")]
    public TextMeshProUGUI inputField;
    [SerializeField] [Range(0f, 2f)] float sceneLoadDelay;

    [Header("BestScore")]
    public Text bestPlayerName;
    public Text bestScore;

    public static string currentPlayerName;

    void Start()
    {

        ShowBestPlayerScoreUIInfo();
    }

    public string StoreName()
    {
        string playerName = inputField.text;
        return playerName;
    }


    public void DisplayBestPlayerName(string _name)
    {
        bestPlayerName.text = _name;
    }

    public void DisplayScore(int _score)
    {
        bestScore.text = _score.ToString();
    }

    public void ShowBestPlayerScoreUIInfo()
    {
        if (UIScoreManager.Instance != null)
        {
            DisplayBestPlayerName(UIScoreManager.Instance.bestScorePlayerName);
            DisplayScore(UIScoreManager.Instance.bestScore);
        }
    }


    public void NewBestPlayerNameSaved(string _name)
    {
        UIScoreManager.Instance.bestScorePlayerName = _name;
    }

    public void CurentPlayerNameSelected(string _name)
    {
        currentPlayerName = _name;
    }


    public void NewBestScoreSaved(int _score)
    {
        UIScoreManager.Instance.bestScore = _score;
    }

    public void OnStartButtonClick()
    {
        int mainScene = 1;
        CurentPlayerNameSelected(StoreName());
        StartCoroutine(LoadGameRoutine(sceneLoadDelay, mainScene));
    }

    IEnumerator LoadGameRoutine(float _delay, int _scene)
    {
        yield return new WaitForSeconds(_delay);
        SceneManager.LoadScene(_scene);
    }

    public void OnMenuButtonClick()
    {
        int startScene = 0;
        StartCoroutine(LoadGameRoutine(sceneLoadDelay, startScene));
    }

    public void OnQuitToRatingButtonClick()
    {
        int ratingScene = 2;
        StartCoroutine(LoadGameRoutine(sceneLoadDelay, ratingScene));
    }

    public void OnExitButtonClick()
    {
        UIScoreManager.Instance.SavePlayerData();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
#endif
    }

}
