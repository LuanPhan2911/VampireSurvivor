using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    private EnemyController enemyController;


    private void Awake()
    {
        enemyController = GetComponent<EnemyController>();
    }



    private void Update()
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        Vector3 targetPosition = PlayerManager.Instance.transform.position;

        transform.position = Vector3.MoveTowards(transform.position, targetPosition,
           enemyController.EnemyStat.currentMoveSpeed * Time.deltaTime);
    }
}
