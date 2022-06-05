using UnityEngine;

public class DataPersistenceManager : MonoBehaviour
{

    public static DataPersistenceManager Instance;

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
    }

    private void Start()
    {
        this.dataPersister = new FileDataPersister();
    }

    public void SaveData()
    {
        dataPersister.Save(this.gameData);
    }

    public void LoadData()
    {
        // TODO Check if any saved data
        if (this.gameData == null)
        {
            this.gameData = new GameData();
        }
    }

}
