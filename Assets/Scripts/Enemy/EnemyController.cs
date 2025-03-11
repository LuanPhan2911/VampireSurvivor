using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public const string ENEMY_TAG = "Enemy";
    public EnemyMovement EnemyMovement { get; private set; }
    public EnemyStat EnemyStat { get; private set; }
    public EnemyAttack EnemyAttack { get; private set; }
    public EnemyAnimation EnemyAnimation { get; private set; }

    public Animator animator;
    public EnemyStatSO enemyStatSO;



    private void Awake()
    {
        EnemyMovement = GetComponent<EnemyMovement>();
        EnemyStat = GetComponent<EnemyStat>();
        EnemyAttack = GetComponent<EnemyAttack>();
        EnemyAnimation = GetComponent<EnemyAnimation>();
        animator = GetComponent<Animator>();
    }
}
