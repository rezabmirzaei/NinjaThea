using UnityEngine;

public class FinishLine : MonoBehaviour
{

    [SerializeField] private AudioSource finishLineCrossedSound;
    [SerializeField] private GameObject levelCompleteContainer;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player") && GameController.Instance.tasksCompleted)
        {
            finishLineCrossedSound.Play();
            levelCompleteContainer.SetActive(true);
        }
        else
        {
            Debug.Log("Complete all tasks first!");
        }

    }

}
