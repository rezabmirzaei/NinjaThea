using UnityEngine;

public class SimpleImageLerp : MonoBehaviour
{
    [SerializeField] private float xPosition;
    [SerializeField] private float yPosition;

    private void Start()
    {
        transform.LeanMoveLocal(new Vector2(xPosition, yPosition), 1).setEaseOutQuart().setLoopPingPong();
    }

}
