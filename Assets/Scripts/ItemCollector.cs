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
            Destroy(collision.gameObject);
        }
    }

}
