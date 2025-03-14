using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [HideInInspector] public Vector2 moveDirection;
    public Vector2 lastDirection;
    private PlayerManager playerManager;



    private Rigidbody2D rd2d;

    private void Awake()
    {
        rd2d = GetComponent<Rigidbody2D>();
        playerManager = GetComponent<PlayerManager>();
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

        if (moveDirection != Vector2.zero)
        {
            lastDirection = new Vector2(moveDirection.x, moveDirection.y);
        }


    }
    private void Move()
    {
        rd2d.velocity = moveDirection.normalized * playerManager.playerStat.currentMoveSpeed;
    }

}
