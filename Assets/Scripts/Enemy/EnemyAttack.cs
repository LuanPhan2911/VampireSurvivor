using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private EnemyController enemyController;


    private void Awake()
    {
        enemyController = GetComponent<EnemyController>();

    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(PlayerManager.PLAYER_TAG))
        {
            PlayerManager.Instance.playerStat.TakeDamge(
                enemyController.EnemyStat.currentDamage);
        }
    }


}
