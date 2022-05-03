using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{

    public static GameController Instance;
    public bool tasksCompleted;
    public bool gamePlaying;

    [SerializeField] private GameObject itemsContainer;
    [SerializeField] private GameObject hudContainer;
    [SerializeField] private TextMeshProUGUI itemText;
    [SerializeField] private TextMeshProUGUI tasksNotCompleteWarningText;

    private int numTotalItems;
    private string itemName;
    private int numItemsCollected;
    private float timeToAppear = 3f;
    private float timeWhenDisappear;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        itemName = itemsContainer.transform.name;
        numTotalItems = itemsContainer.transform.childCount;
        numItemsCollected = 0;
        itemText.text = $"{itemName} : {numItemsCollected}/{numTotalItems}";
        tasksCompleted = false;
        gamePlaying = true;
    }

    private void Update()
    {
        if (tasksNotCompleteWarningText.enabled && (Time.time >= timeWhenDisappear))
        {
            tasksNotCompleteWarningText.gameObject.SetActive(false);
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
        itemText.text = $"{itemName} : {numItemsCollected}/{numTotalItems}";
        CheckTasksCompleted();
    }

    private void CheckTasksCompleted()
    {
        tasksCompleted = numItemsCollected >= numTotalItems;
    }

}
