using UnityEngine;

public class Pickup : MonoBehaviour, ICollectable
{
    protected bool isPicked = false;
    public virtual void Collect()
    {
        isPicked = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(PlayerManager.PLAYER_TAG))
        {
            Destroy(gameObject);
        }
    }
}
