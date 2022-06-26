using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class LevelSelect : MonoBehaviour
{
    [SerializeField] private Button[] levelButtons;

    private void Start()
    {

        GameData gameData = DataPersistenceManager.Instance.SaveGameData;
        if (gameData == null || gameData.LevelStatus.Count == 0) return;

        foreach (var levelButton in levelButtons)
        {
            bool levelAlreadyPlayed = false;
            foreach (var levelStatus in gameData.LevelStatus)
            {
                if (String.Equals(levelStatus.LevelName,
                    levelButton.gameObject.GetComponentInChildren<TextMeshProUGUI>().text,
                    StringComparison.OrdinalIgnoreCase))
                {
                    levelAlreadyPlayed = true;
                    levelButton.onClick.AddListener(delegate { ReplayLevel(levelStatus.LevelName); });
                    break;
                }
            }

            // Level not played yet, gray out the text in button
            if (!levelAlreadyPlayed)
            {
                levelButton.gameObject.GetComponentInChildren<TextMeshProUGUI>().color = Color.gray;
            }
        }

        void ReplayLevel(string levelName)
        {
            SceneManager.LoadScene(levelName);
        }

    }

}