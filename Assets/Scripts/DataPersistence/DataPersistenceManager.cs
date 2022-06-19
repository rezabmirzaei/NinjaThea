using UnityEngine;

public class DataPersistenceManager : MonoBehaviour
{

    public static DataPersistenceManager Instance;

    [SerializeField] private bool saveGameDataOnComplete;

    public GameData SaveGameData { get; private set; }
    private IDataPersister dataPersister;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        this.dataPersister = new FileDataPersister();
        LoadData();
        DontDestroyOnLoad(gameObject);
    }

    public void SaveData(LevelData levelData)
    {
        if (!saveGameDataOnComplete)
        {
            Debug.LogWarning("Game not saved! Flag 'saveGameDataOnComplete is " + saveGameDataOnComplete);
            return;
        }
        if (SaveGameData == null)
        {
            SaveGameData = new GameData();
        }
        SaveGameData.UpdateLevelStatus(levelData);
        dataPersister.Save(SaveGameData);
    }

    private void LoadData()
    {
        SaveGameData = dataPersister.Load();
        if (SaveGameData == null)
        {
            SaveGameData = new GameData();
        }
    }

}
