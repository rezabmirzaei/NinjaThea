using UnityEngine;

public class Parallax : MonoBehaviour
{

    [SerializeField] private GameObject cam;
    [SerializeField] private float parallaxEffect;
    private float length, startPos;



    private void Start()
    {
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    private void Update()
    {
        float dist = cam.transform.position.x * parallaxEffect;
        transform.position = new Vector3(startPos + dist, .0f, transform.position.z);
    }
}
