using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private EnemyController enemyController;

    private float currentDamage;
    private void Awake()
    {
        enemyController = GetComponent<EnemyController>();
        currentDamage = enemyController.enemyStatSO.damgage;
    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(PlayerManager.PLAYER_TAG))
        {
            PlayerManager.Instance.playerStat.TakeDamge(currentDamage);
        }
    }


}
