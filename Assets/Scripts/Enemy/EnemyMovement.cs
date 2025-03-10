using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed;

    private void Update()
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        Vector3 targetPosition = PlayerManager.Instance.transform.position;

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }
}
