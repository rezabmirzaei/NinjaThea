using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class LevelSelect : MonoBehaviour
{
    [SerializeField] private Button[] stageButtons;

    private void Start()
    {

        GameData gameData = DataPersistenceManager.Instance.SaveGameData;
        Boolean noGameData = gameData == null || gameData.LevelStatus.Count == 0;

        /*foreach (var levelButton in levelButtons)*/
        for (int i = 0; i < stageButtons.Length; i++)
        {
            Button levelButton = stageButtons[i];

            if (noGameData)
            {
                // No game data, gray out button
                levelButton.gameObject.GetComponentInChildren<TextMeshProUGUI>().color = Color.gray;
                continue;
            }

            bool stageAlreadyPlayed = false;
            foreach (var levelStatus in gameData.LevelStatus)
            {
                if (String.Equals(levelStatus.LevelName,
                    levelButton.gameObject.GetComponentInChildren<TextMeshProUGUI>().text,
                    StringComparison.OrdinalIgnoreCase))
                {
                    stageAlreadyPlayed = true;
                    levelButton.onClick.AddListener(delegate { ReplayStage(levelStatus.StageIndex); });
                    break;
                }
            }

            // Level not played yet, gray out the text in button
            if (!stageAlreadyPlayed)
            {
                levelButton.gameObject.GetComponentInChildren<TextMeshProUGUI>().color = Color.gray;
            }

        }

        void ReplayStage(int stageIndex)
        {
            SceneManager.LoadScene(stageIndex);
        }

    }

}
