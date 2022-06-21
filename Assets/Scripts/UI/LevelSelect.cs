using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;

public class LevelSelect : MonoBehaviour
{
    [SerializeField] private Button[] levelButtons;

    private void Start()
    {
        GameData gameData = DataPersistenceManager.Instance.SaveGameData;
        if (gameData == null || gameData.LevelStatus.Count == 0) return;
        foreach (var levelStatus in gameData.LevelStatus)
        {
            foreach (var levelButton in levelButtons)
            {
                if (String.Equals(levelStatus.LevelName,
                    levelButton.gameObject.GetComponentInChildren<TextMeshProUGUI>().text,
                    StringComparison.OrdinalIgnoreCase))
                {
                    levelButton.interactable = true;
                }
            }
        }
    }

}
