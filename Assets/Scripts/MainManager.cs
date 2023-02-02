using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{

   // public ScoreManager scoreManager;

    [Header("Brick Wall")]
    public Brick BrickPrefab;
    public int lineCount = 6;

    [Header("Ball")]
    public Rigidbody Ball;

    [Header("UI")]
    public Text ScoreText;
    public GameObject GameOverText;

    private int points;
    private bool isGameStarted = false;
    private bool isGameOver = false;
    MenuUIHandler bestScoreUi;

    private void Awake()
    {
      bestScoreUi = FindObjectOfType<MenuUIHandler>();
    }

    void Start()
    {
        bestScoreUi.ShowBestPlayerScoreUIInfo();
        CreateBrickWall();
    }

   public void CreateBrickWall()
    {
        const float step = 0.6f;
        int perLine = Mathf.FloorToInt(4.0f / step);

        int[] pointCountArray = new[] { 1, 1, 2, 2, 5, 5 };
        for (int i = 0; i < lineCount; ++i)
        {
            for (int x = 0; x < perLine; ++x)
            {
                Vector3 position = new Vector3(-1.5f + step * x, 2.5f + i * 0.3f, 0);
                var brick = Instantiate(BrickPrefab, position, Quaternion.identity);
                brick.pointValue = pointCountArray[i];
                brick.onDestroyed.AddListener(AddPoint); //in Brick script:  onDestroyed.Invoke(pointValue);
                //every brick has its point value
                //and brick has  an Event   public UnityEvent<int> onDestroyed;
            }
        }
    }

    private void Update()
    {
        if (!isGameStarted)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ForceBallMovementIfNewGame();
            }
        }
        else if (isGameOver) //DeathZone defines gameOver condition
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                RestartGame();
            }
        }
    }

    void ForceBallMovementIfNewGame()
    {
        isGameStarted = true;
        float randomDirection = Random.Range(-1.0f, 1.0f);
        Vector3 forceDir = new Vector3(randomDirection, 1, 0);
        forceDir.Normalize();

        Ball.transform.SetParent(null);
        Ball.AddForce(forceDir * 2.0f, ForceMode.VelocityChange);
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void AddPoint(int point)
    {
        points += point;
        ScoreText.text = $"Score : {points}";

        if (points > UIScoreManager.Instance.bestScore)
        {
            bestScoreUi.NewBestPlayerNameSaved(MenuUIHandler.currentPlayerName);//to acces static variable put the class!
            bestScoreUi.NewBestScoreSaved(points);
        }
    }

    public void GameOver() //DeathZone calls this method
    {
        bestScoreUi.ShowBestPlayerScoreUIInfo();
        isGameOver = true;
        GameOverText.SetActive(true);
    }

}
