using UnityEngine;
using UnityEngine.UI;

public class PanelDefaultButtonHighlighter : MonoBehaviour
{
    [SerializeField] private Button defaultHighlightedButton;

    private void Start()
    {
        defaultHighlightedButton.Select();
    }
}
