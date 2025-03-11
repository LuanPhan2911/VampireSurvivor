using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public const string enemyTag = "Enemy";
    public EnemyMovement EnemyMovement { get; private set; }
    public EnemyStat EnemyStat { get; private set; }

    public EnemyStatSO enemyStatSO;

    private void Awake()
    {
        EnemyMovement = GetComponent<EnemyMovement>();
        EnemyStat = GetComponent<EnemyStat>();
    }
}
