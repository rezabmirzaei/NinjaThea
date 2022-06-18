using System;
using System.IO;
using UnityEngine;

public class FileDataPersister : IDataPersister
{

    private string filePath = Path.Combine(Application.persistentDataPath, "gamedata.ninja");

    public void Save(GameData gameData)
    {
        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(filePath));
            string gameDataJson = JsonUtility.ToJson(gameData, true);
            using (FileStream stream = new FileStream(filePath, FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write(gameDataJson);
                }
            }
        }
        catch (Exception e)
        {
            Debug.LogError(e);
        }

    }

    public void Load(GameData gameData)
    {
        // TODO Implement
    }

}
