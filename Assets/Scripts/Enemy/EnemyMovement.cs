using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    private EnemyController enemyController;

    private float currentMoveSpeed;
    private void Awake()
    {
        enemyController = GetComponent<EnemyController>();

        currentMoveSpeed = enemyController.enemyStatSO.moveSpeed;
    }



    private void Update()
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        Vector3 targetPosition = PlayerManager.Instance.transform.position;

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, currentMoveSpeed * Time.deltaTime);
    }
}
