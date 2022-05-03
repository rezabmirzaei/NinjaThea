using UnityEngine;
using TMPro;
using System;

public class GameController : MonoBehaviour
{

    public static GameController Instance;
    public bool tasksCompleted;
    public bool gamePlaying;

    [SerializeField] private GameObject itemsContainer;
    [SerializeField] private GameObject hudContainer;
    [SerializeField] private TextMeshProUGUI itemText;
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private TextMeshProUGUI tasksNotCompleteWarningText;

    private int numTotalItems;
    private string itemName;
    private int numItemsCollected;
    private float timeToAppear = 3f;
    private float timeWhenDisappear;
    private float startTime;
    private float elapsedTime;
    private TimeSpan timePlaying;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        itemName = itemsContainer.transform.name;
        numTotalItems = itemsContainer.transform.childCount;
        numItemsCollected = 0;
        itemText.text = $"{itemName}: {numItemsCollected}/{numTotalItems}";
        timeText.text = "Time: 00:00.00";
        tasksCompleted = false;
        gamePlaying = false;

        BeginGame();
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

    private void BeginGame()
    {
        gamePlaying = true;
        startTime = Time.time;
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

    private void CheckTasksCompleted()
    {
        tasksCompleted = numItemsCollected >= numTotalItems;
    }

}
