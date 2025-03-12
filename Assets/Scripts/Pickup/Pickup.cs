using UnityEngine;

public class Pickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(PlayerManager.PLAYER_TAG))
        {
            Destroy(gameObject);
        }
    }
}
