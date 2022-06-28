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
        Vector3 camPosition = cam.transform.position;
        float temp = camPosition.x * (1 - parallaxEffect);
        float dist = camPosition.x * parallaxEffect;
        float yPosition = camPosition.y <= -2.0f ? camPosition.y : -2.0f;
        transform.position = new Vector3(startPos + dist, yPosition, transform.position.z);

        if (temp > startPos + length) startPos += length;
        else if (temp < startPos - length) startPos -= length;
    }
}
