using UnityEngine;
using UnityEngine.UIElements;

public class ParallaxBackground : MonoBehaviour
{
    public float moveSpeed = 0.5f;
    private float startPosX;
    private float length;

    private void Start()
    {
        startPosX = transform.position.x;
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        length = spriteRenderer.bounds.size.x;
    }
    private void Update()
    {
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);

        if (transform.position.x < startPosX - length)
        {
            transform.position = new Vector3(startPosX, transform.position.y, transform.position.z);
        }
    }
}
