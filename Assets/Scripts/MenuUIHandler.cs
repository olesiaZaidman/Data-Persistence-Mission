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
    public string playerName;
    public TextMeshProUGUI inputField;
    public Text textDisplay;
    [SerializeField] [Range(0f, 2f)] float sceneLoadDelay;
    //public string bestScore;

    [Header("BestScore")]
    public GameObject bestScoreUi;
    public Text bestPlayerName;
    public Text bestScore;

    void Awake()
    {
        if (UIScoreManager.Instance.isBestScoreSaved)
        { bestScoreUi.SetActive(true); }
        else
            bestScoreUi.SetActive(false);
    }

    public void StoreName()
    {
        playerName = inputField.text;
        UIScoreManager.Instance.bestScorePlayerName = playerName;
        textDisplay.text = UIScoreManager.Instance.bestScorePlayerName;
    }

    public void OnStartButtonClick()
    {
        StoreName();
        StartCoroutine(LoadGameRoutine(sceneLoadDelay));
    }

    IEnumerator LoadGameRoutine(float _delay)
    {
        yield return new WaitForSeconds(_delay);
        SceneManager.LoadScene(1);
    }

    public void OnExitButtonClick()
    {
        UIScoreManager.Instance.SavePlayerData();

        /*When the code is compiled inside the Editor then UNITY_EDITOR is true, 
      * it will keep the EditorApplication.ExitPlaymode() code and discard the Application.Quit.*/
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif

        /*When you build a player, 
         * UNITY_EDITOR will be false, and so it will keep Application.Quit()
         * and discard EditorApplication.ExitPlaymode() !*/
    }




    //private void Start()
    //{
    //    if (MainManager.Instance != null)
    //    {
    //        SetName(MainManager.Instance.TeamColor);
    //    }
    //}

    //void SetName(string n)
    //{
    //    var colorHandler = GetComponentInChildren<ColorHandler>();
    //    if (colorHandler != null)
    //    {
    //        colorHandler.SetColor(n);
    //    }
    //}
}
