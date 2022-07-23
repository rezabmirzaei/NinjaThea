using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;
using System.Collections;

public class GameController : MonoBehaviour
{

    public static GameController Instance;
    public bool tasksCompleted;
    public bool gamePlaying;

    // TODO Handle music better in AudioManager
    [SerializeField] private AudioSource backgroundMusic;
    [SerializeField] private GameObject itemsContainer;
    [SerializeField] private TextMeshProUGUI itemText;
    [SerializeField] private GameObject enemiesContainer;
    [SerializeField] private TextMeshProUGUI enemyText;
    [SerializeField] private GameObject hudContainer;
    [SerializeField] private GameObject levelCompleteContainer;
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private TextMeshProUGUI countdownText;
    [SerializeField] private string[] countdownSteps;
    // TODO Rethink this. Doen Unity handle tuples? > E.g. use together with countdownSteps, each step has own audio.
    [SerializeField] private AudioSource countdownStepsAudio;
    [SerializeField] private TextMeshProUGUI levelCompleteTimeText;
    [SerializeField] private TextMeshProUGUI tasksNotCompleteWarningText;
    [SerializeField] private TextMeshProUGUI bestText;
    [SerializeField] private TextMeshProUGUI stageText;
    [SerializeField] private String customStageText;


    private int numTotalItems;
    private string itemName;
    private int numItemsCollected;
    private int numTotalEnemies;
    private string enemyName;
    private int numdEnemiesKilled;
    private float timeToAppear = 3f;
    private float timeWhenDisappear;
    private float startTime;
    private float elapsedTime;
    private TimeSpan timePlaying;
    private string currentSceneName;
    private int currentSceneIndex;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private void Start()
    {
        currentSceneName = SceneManager.GetActiveScene().name;
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        itemName = itemsContainer.transform.name;
        numTotalItems = itemsContainer.transform.childCount;
        numItemsCollected = 0;
        itemText.text = $"{itemName}: {numItemsCollected}/{numTotalItems}";

        enemyName = enemiesContainer.transform.name;
        numTotalEnemies = enemiesContainer.transform.childCount;
        numdEnemiesKilled = 0;
        enemyText.text = $"{enemyName}: {numdEnemiesKilled}/{numTotalEnemies}";

        timeText.text = "Time: 00:00.00";
        SetBestText();
        countdownText.text = "";

        if (string.IsNullOrEmpty(customStageText))
            stageText.text = SceneManager.GetActiveScene().name;
        else
            stageText.text = customStageText;

        tasksCompleted = false;
        gamePlaying = false;

        Cursor.visible = false;

        StartCoroutine(CountdownToBeginGame());
    }

    private void Update()
    {
        if (gamePlaying)
        {
            elapsedTime = Time.time - startTime;
            timePlaying = TimeSpan.FromSeconds(elapsedTime);
            timeText.text = "Time: " + timePlaying.ToString("mm':'ss'.'ff");
            // TODO Refactor
            if (tasksNotCompleteWarningText.enabled && (Time.time >= timeWhenDisappear))
            {
                tasksNotCompleteWarningText.gameObject.SetActive(false);
            }
        }
    }

    IEnumerator CountdownToBeginGame()
    {

        int iterations = 0;
        foreach (string step in countdownSteps)
        {
            iterations++;
            if (iterations == countdownSteps.Length)
            {
                countdownText.fontSize = 168;
                countdownText.fontStyle = FontStyles.Italic | FontStyles.Bold;
                BeginGame();
            }
            countdownText.text = step;
            countdownStepsAudio.Play();
            yield return new WaitForSeconds(1f);
        }

        yield return new WaitForSeconds(.5f);
        countdownText.gameObject.SetActive(false);

    }

    private void BeginGame()
    {
        gamePlaying = true;
        startTime = Time.time;
        // TODO Handle better in AudioManager
        backgroundMusic.gameObject.SetActive(true);
    }

    private void SetBestText()
    {
        bestText.text = "Best: --";
        if (DataPersistenceManager.Instance == null) return;
        GameData gameData = DataPersistenceManager.Instance.SaveGameData;
        if (gameData == null || gameData.LevelStatus.Count == 0) return;

        foreach (var levelStatus in gameData.LevelStatus)
        {
            if (levelStatus.LevelName.Equals(currentSceneName))
            {
                bestText.text = "Best: " + levelStatus.CompletionTime;
                break;
            }
        }

    }

    public void DisplayTasksNotCompleteWarningText()
    {
        tasksNotCompleteWarningText.gameObject.SetActive(true);
        timeWhenDisappear = Time.time + timeToAppear;
    }

    public void ItemCollected()
    {
        numItemsCollected++;
        itemText.text = $"{itemName}: {numItemsCollected}/{numTotalItems}";
        CheckTasksCompleted();
    }

    public void EnemyKilled()
    {
        numdEnemiesKilled++;
        enemyText.text = $"{enemyName}: {numdEnemiesKilled}/{numTotalEnemies}";
        CheckTasksCompleted();
    }

    private void CheckTasksCompleted()
    {
        tasksCompleted = (numItemsCollected >= numTotalItems) && (numdEnemiesKilled >= numTotalEnemies);
    }

    public void LevelComplete()
    {
        string completionTime = timePlaying.ToString("mm':'ss'.'ff");
        LevelData levelData = new LevelData(currentSceneName, completionTime, currentSceneIndex);
        if (DataPersistenceManager.Instance != null) DataPersistenceManager.Instance.SaveData(levelData);
        levelCompleteContainer.SetActive(true);
        Cursor.visible = true;
        // TODO Handle better in AudioManager
        backgroundMusic.gameObject.SetActive(false);
        gamePlaying = false;
        levelCompleteTimeText.text = "Time: " + completionTime;
    }

}
