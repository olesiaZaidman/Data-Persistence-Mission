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
   private InputUINameSaver inputNameSaver;

    [Header("UI")]
    [SerializeField] [Range(0f, 2f)] float sceneLoadDelay;

    [Header("BestScore")]
    public Text bestPlayerName;
    public Text bestScore;

    void Start()
    {
      ShowBestPlayerScoreUIInfo();
      inputNameSaver = FindObjectOfType<InputUINameSaver>();
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
        if (HighScoreManager.Instance != null)
        {
            DisplayBestPlayerName(HighScoreManager.Instance.bestScorePlayerName);
            DisplayScore(HighScoreManager.Instance.bestScore);
        }
    }


    public void OnStartButtonClick()
    {
        int mainScene = 1;
        if (inputNameSaver != null)
        { 
            HighScoreManager.Instance.CurentPlayerNameSelected(inputNameSaver.GetInputName()); 
        }

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
        InputEntiresHandler.AddEntryToTheList();
        int ratingScene = 2;
        StartCoroutine(LoadGameRoutine(sceneLoadDelay, ratingScene));
    }

    public void OnExitButtonClick()
    {
        HighScoreManager.Instance.SavePlayerData();

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
#endif
    }

}
