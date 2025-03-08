using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [HideInInspector] public Vector2 moveDirection;
    [HideInInspector] public float lastDirectionX;
    [HideInInspector] public float lastDirectionY;

    private Rigidbody2D rd2d;

    private void Awake()
    {
        rd2d = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        HandleInput();
    }
    private void FixedUpdate()
    {
        Move();
    }

    private void HandleInput()
    {

        moveDirection.x = Input.GetAxisRaw("Horizontal");
        moveDirection.y = Input.GetAxisRaw("Vertical");
        moveDirection.Normalize();
        if (moveDirection.x != 0)
        {
            lastDirectionX = moveDirection.x;
        }
        if (moveDirection.y != 0)
        {
            lastDirectionY = moveDirection.y;
        }
    }
    private void Move()
    {
        rd2d.velocity = moveDirection * moveSpeed;
    }

}
