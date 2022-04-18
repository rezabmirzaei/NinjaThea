using UnityEngine;

public class ItemCollector : MonoBehaviour
{

    // TODO Handle points/collected items

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Banana"))
        {
            Destroy(collision.gameObject);
        }
    }

}
