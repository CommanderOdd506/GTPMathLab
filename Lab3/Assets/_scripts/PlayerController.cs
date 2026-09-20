using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private float moveInput;
    public float moveSpeed;
    public float cameraBounds = 8.5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnMove(InputValue value)
    {
        Vector2 rawInput = value.Get<Vector2>();
        float xInput = rawInput.x;
        if (xInput > 0)
        {
            moveInput = 1;
        }
        else if (xInput < 0)
        {
            moveInput = -1;
        }
        else
        {
            moveInput = 0;
        }

    }

    // Update is called once per frame
    void Update()
    {
        float xMove = transform.position.x + moveInput * moveSpeed * Time.deltaTime;
        xMove = Mathf.Clamp(xMove, -cameraBounds, cameraBounds);
        Vector3 newPosition = new Vector3(xMove, 0);
        transform.position = newPosition;
    }
}
