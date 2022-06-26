using UnityEngine;

public class ItemCollector : MonoBehaviour
{

    [SerializeField] private AudioSource itemCollectedSound;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Collectible"))
        {
            itemCollectedSound.Play();
            GameController.Instance.ItemCollected();
            collision.gameObject.GetComponent<Animator>().SetTrigger("ItemCollected");
            // Item is destroyed by animator transition triggred by ItemCollected (OnStateExit)
        }
    }

}
