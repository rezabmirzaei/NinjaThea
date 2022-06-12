using UnityEngine;

public class Tutorial : MonoBehaviour
{
    private void Start()
    {
        // TODO make sure tutorial UI is NOT active
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            Debug.Log("Tutorial...");
            // TODO Display tutorial UI (destroy on close)
        }
    }

}
