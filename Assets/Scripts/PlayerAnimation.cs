using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private PlayerManager playerManager;


    private const string IS_MOVE = "IsMove";

    private void Awake()
    {
        playerManager = GetComponent<PlayerManager>();
    }

    private void Update()
    {
        if (playerManager.playerMovement.moveDirection != Vector2.zero)
        {
            // is move
            playerManager.animator.SetBool(IS_MOVE, true);
            FlipSprite();
        }
        else
        {
            playerManager.animator.SetBool(IS_MOVE, false);
        }
    }

    private void FlipSprite()
    {
        if (playerManager.playerMovement.moveDirection.x < 0)
        {
            playerManager.spriteRenderer.flipX = true;
        }
        else if (playerManager.playerMovement.moveDirection.x > 0)
        {
            playerManager.spriteRenderer.flipX = false;
        }
    }
}
