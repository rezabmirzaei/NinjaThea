using UnityEngine;
using UnityEngine.UI;

public class PanelDefaultButtonHighlighter : MonoBehaviour
{
    [SerializeField] private Button defaultHighlightedButton;

    private void Start()
    {
        HighlightDefaultButton();
    }

    public void HighlightDefaultButton()
    {
        if (defaultHighlightedButton) defaultHighlightedButton.Select();
    }
}
