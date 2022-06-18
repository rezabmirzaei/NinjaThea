using UnityEngine;

public class DataPersistenceManager : MonoBehaviour
{

    public static DataPersistenceManager Instance;

    [SerializeField] private bool saveGameDataOnComplete;

    private GameData gameData;
    private IDataPersister dataPersister;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        this.dataPersister = new FileDataPersister();
        LoadData();
    }

    public void SaveData(LevelData levelData)
    {
        if (!saveGameDataOnComplete)
        {
            Debug.LogWarning("Game not saved! Flag 'saveGameDataOnComplete is " + saveGameDataOnComplete);
            return;
        }
        if (gameData == null)
        {
            gameData = new GameData();
        }
        gameData.UpdateLevelStatus(levelData);
        dataPersister.Save(gameData);
    }

    private void LoadData()
    {
        gameData = dataPersister.Load();
        if (gameData == null)
        {
            gameData = new GameData();
        }
    }

}
