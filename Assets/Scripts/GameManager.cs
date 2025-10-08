using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private bool gameStarted;


    [Header("Score Info")]
    public int score = 0;
    private int highScore = 0;
    [SerializeField] private TextMeshProUGUI scoreCount;
    [SerializeField] private TextMeshProUGUI highScoreCount;
    [SerializeField] private TextMeshProUGUI gameOverScoreCount;
    [SerializeField] private TextMeshProUGUI gameOverhighScoreCount;

    [Header("Lives Info")]
    public int lives = 1;
    [SerializeField] private TextMeshProUGUI livesCount;

    [Header("Apple Info")]
    [SerializeField] private GameObject apple;
    [SerializeField] private Transform appleSpawnPoint;
    private float appleSpawnRate;
    [SerializeField] private float appleXPos;

    [Header("Banana Info")]
    [SerializeField] private GameObject banana;
    [SerializeField] private Transform bananaSpawnPoint;
    private float bananaSpawnRate;
    [SerializeField] private float bananaXpos;

    [Header("Grapes Info")]
    [SerializeField] private GameObject grapes;
    [SerializeField] private Transform grapesSpawnPoint;
    private float grapesSpawnRate;
    [SerializeField] private float grapesXpos;

    [Header("Watermelon Info")]
    [SerializeField] private GameObject watermelon;
    [SerializeField] private Transform watermelonSpawnPoint;
    private float watermelonSpawnRate;
    [SerializeField] private float watermelonXpos;

    [Header("Bomb Info")]
    [SerializeField] private GameObject bomb;
    [SerializeField] private Transform bombSpawnPoint;
    private float bombSpawnRate;
    [SerializeField] private float bombXpos;

    [Header("CanvasGroups")]
    [SerializeField] private CanvasGroup gameCG;
    [SerializeField] private CanvasGroup gameStartCG;
    [SerializeField] private CanvasGroup gameOverCG;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (lives <= 0)
        {
            GameOver();
        }

        livesCount.text = lives.ToString();
    }

    public void GameStart()
    {
        Time.timeScale = 1;
        StartSpawn();
        ShowCG(gameCG);
        HideCG(gameStartCG);
        HideCG(gameOverCG);

        highScoreCount.text = highScore.ToString();
        highScore = PlayerPrefs.GetInt("highScore");
    }

    private void GameOver()
    {
        Time.timeScale = 0;
        ShowCG(gameOverCG);
        HideCG(gameCG);
        HideCG(gameStartCG);

        CancelInvoke();

        gameOverScoreCount.text = score.ToString();
        gameOverhighScoreCount.text = highScore.ToString();
    }

    public void IncrementScore()
    {
        score+= 2;
        scoreCount.text = score.ToString();

        if (score >= highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("highScore", score);
        }
    }

    private void StartSpawn()
    {
        appleSpawnRate = Random.Range(1, 4);
        bananaSpawnRate = Random.Range(1, 5);
        grapesSpawnRate = Random.Range(1, 6);
        watermelonSpawnRate = Random.Range(1, 8);
        bombSpawnRate = Random.Range(3, 10);

        InvokeRepeating("SpawnApple", 0.5f, appleSpawnRate);
        InvokeRepeating("SpawnBanana", 0.5f, bananaSpawnRate);
        InvokeRepeating("SpawnGrapes", 0.5f, grapesSpawnRate);
        InvokeRepeating("SpawnWatermelon", 0.5f, watermelonSpawnRate);
        InvokeRepeating("SpawnBomb", 0.5f, bombSpawnRate);
    }

    private void SpawnApple()
    {
        Vector2 spawnPosApple = appleSpawnPoint.position;
        spawnPosApple.x = Random.Range(-appleXPos, appleXPos);
        Instantiate(apple, spawnPosApple, Quaternion.identity);
    }

    private void SpawnBanana()
    {
        Vector2 spawnPosBanana = bananaSpawnPoint.position;
        spawnPosBanana.x = Random.Range(-bananaXpos, bananaXpos);
        Instantiate(banana, spawnPosBanana, Quaternion.identity);
    }

    private void SpawnGrapes()
    {
        Vector2 spawnPosGrapes = grapesSpawnPoint.position;
        spawnPosGrapes.x = Random.Range(-grapesXpos, grapesXpos);
        Instantiate(grapes, spawnPosGrapes, Quaternion.identity);
    }

    private void SpawnWatermelon()
    {
        Vector2 spawnPosWatermelon = watermelonSpawnPoint.position;
        spawnPosWatermelon.x = Random.Range(-watermelonXpos, watermelonXpos);
        Instantiate(watermelon, spawnPosWatermelon, Quaternion.identity);
    }

    private void SpawnBomb()
    {
        Vector2 spawnPosBomb = bombSpawnPoint.position;
        spawnPosBomb.x = Random.Range(-bombXpos, bombXpos);
        Instantiate(bomb, spawnPosBomb, Quaternion.identity);
    }

    private void ShowCG(CanvasGroup cg)
    {
        cg.alpha = 1;
        cg.interactable = true;
        cg.blocksRaycasts = true;
    }

    private void HideCG(CanvasGroup cg)
    {
        cg.alpha = 0;
        cg.interactable = false;
        cg.blocksRaycasts = false;
    }

    public void PlayAgainButtonCallBack()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
