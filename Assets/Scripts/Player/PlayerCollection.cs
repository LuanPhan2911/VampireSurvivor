using UnityEngine;

public class PlayerCollection : MonoBehaviour
{

    private CircleCollider2D circleCollider2D;

    [SerializeField] private float pullSpeed;
    private void Awake()
    {
        circleCollider2D = GetComponent<CircleCollider2D>();

    }
    private void Start()
    {
        circleCollider2D.radius = PlayerManager.Instance.playerStat.currentMagnet;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.TryGetComponent<ICollectable>(out var collectable))
        {
            Rigidbody2D rigidbody2D = collision.gameObject.GetComponent<Rigidbody2D>();
            // pull direction : pull gem to player
            Vector3 pullDirection = (transform.position - collision.transform.position).normalized;

            rigidbody2D.AddForce(pullDirection * pullSpeed);
            collectable.Collect();
        }
    }
}
