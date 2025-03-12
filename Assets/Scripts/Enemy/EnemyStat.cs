using UnityEngine;

public class EnemyStat : MonoBehaviour, ITakeDamageable
{

    [Header("Enemy Stats")]
    public EnemySO enemySO;
    public float currentHp;
    public float currentMoveSpeed;
    public float currentDamage;

    public float despawnDistance = 20;

    private void Awake()
    {


        currentHp = enemySO.maxHp;
        currentMoveSpeed = enemySO.moveSpeed;
        currentDamage = enemySO.damgage;

    }
    private void Update()
    {
        if (Vector2.Distance(PlayerManager.Instance.transform.position, transform.position) > despawnDistance)
        {
            MoveEnemyNearlyPlayer();
        }
    }
    public void TakeDamage(float damage)
    {

        currentHp -= damage;
        if (currentHp <= 0)
        {
            // kill enemy
            Kill();
        }
    }

    private void Kill()
    {
        gameObject.GetComponent<DropRateManager>().SpawnItem();
        EnemySpawner.Instance.OnEnemyKilled();
        Destroy(gameObject);
    }

    private void MoveEnemyNearlyPlayer()
    {
        transform.position = PlayerManager.Instance.transform.position +
                      EnemySpawner.Instance.spawnEnemyPositionList[Random.Range(0, EnemySpawner.Instance.spawnEnemyPositionList.Count)].position;
    }
}
