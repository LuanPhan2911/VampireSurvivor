using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    [HideInInspector] public PlayerMovement playerMovement;
    [HideInInspector] public PlayerAnimation playerAnimation;
    [HideInInspector] public Animator animator;
    [HideInInspector] public SpriteRenderer spriteRenderer;


    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerAnimation = GetComponent<PlayerAnimation>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
}
