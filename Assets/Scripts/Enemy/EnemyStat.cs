using UnityEngine;

public class EnemyStat : MonoBehaviour, ITakeDamageable
{
    private EnemyController enemyController;

    private float currentHp;

    private void Awake()
    {
        enemyController = GetComponent<EnemyController>();

        currentHp = enemyController.enemyStatSO.maxHp;

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
