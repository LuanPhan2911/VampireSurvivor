using UnityEngine;

public class EnemyStat : MonoBehaviour, ITakeDamageable
{

    [Header("Enemy Stats")]
    public EnemyStatSO enemyStatSO;
    public float currentHp;
    public float currentMoveSpeed;
    public float currentDamage;

    private void Awake()
    {


        currentHp = enemyStatSO.maxHp;
        currentMoveSpeed = enemyStatSO.moveSpeed;
        currentDamage = enemyStatSO.damgage;

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
        Destroy(gameObject);

    }
}
