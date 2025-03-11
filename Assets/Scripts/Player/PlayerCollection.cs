using UnityEngine;

public class PlayerCollection : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.TryGetComponent<ICollectable>(out var collectable))
        {
            collectable.Collect();
        }
    }
}
