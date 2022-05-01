using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{

    public static GameController Instance;

    [SerializeField] private GameObject itemsContainer;
    [SerializeField] private GameObject hudContainer;
    [SerializeField] private TextMeshProUGUI itemText;

    private int numTotalItems;
    private string itemName;
    private int numItemsCollected = 0;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        itemName = itemsContainer.transform.name;
        numTotalItems = itemsContainer.transform.childCount;
        itemText.text = $"{itemName} : {numItemsCollected}/{numTotalItems}";
    }

    public void ItemCollected()
    {
        numItemsCollected++;
        itemText.text = $"{itemName} : {numItemsCollected}/{numTotalItems}";
    }

}
