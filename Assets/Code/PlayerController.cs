using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float xLimit = 2.5f;

    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        HandleTouchInput();
        LimitPosition();
    }
    void HandleTouchInput()
    {
#if UNITY_EDITOR
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.linearVelocity = new Vector2(-moveSpeed, 0);
            return;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.linearVelocity = new Vector2(moveSpeed, 0);
            return;
        }
        else
        {
            rb.linearVelocity = Vector2.zero;
        }
#endif
        if (Input.touchCount <= 0)
        {
            rb.linearVelocity = Vector3.zero;
            return;
        }
        Touch touch = Input.GetTouch(0);
        Vector2 touchPosition = touch.position;

        float screenWidth = Screen.width;

        if (touchPosition.x < screenWidth / 2)
        {
            rb.linearVelocity = new Vector2(moveSpeed, 0);
        }
    }
    void LimitPosition()
    {
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -xLimit, xLimit);
        transform.position = pos;
    }
}
