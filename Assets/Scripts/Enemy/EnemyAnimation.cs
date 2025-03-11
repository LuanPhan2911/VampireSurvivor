using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    private const string IS_DIE = "IsDie";
    private EnemyController enemyController;
    private void Awake()
    {
        enemyController = GetComponent<EnemyController>();
    }

    public void SetDie()
    {
        enemyController.animator.SetBool(IS_DIE, true);
        enemyController.EnemyMovement.enabled = false;
    }
}
