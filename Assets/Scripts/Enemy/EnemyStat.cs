using UnityEngine;

public class EnemyStat : MonoBehaviour
{
    private EnemyController enemyController;

    private float currentHp;
    private float currentDamage;



    private void Awake()
    {
        enemyController = GetComponent<EnemyController>();

        currentHp = enemyController.enemyStatSO.maxHp;
        currentDamage = enemyController.enemyStatSO.damgage;
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
        Destroy(gameObject);
    }
}
