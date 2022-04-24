using UnityEngine;

public class ItemCollector : MonoBehaviour
{

    // TODO Handle points/collected items
    [SerializeField] private AudioSource itemCollectedSound;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Banana"))
        {
            itemCollectedSound.Play();
            collision.gameObject.GetComponent<Animator>().SetTrigger("ItemCollected");
            // Item is destroyed by animator transition triggred by ItemCollected (OnStateExit)
        }
    }

}
