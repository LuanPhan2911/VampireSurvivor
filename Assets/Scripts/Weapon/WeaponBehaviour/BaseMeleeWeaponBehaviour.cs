using UnityEngine;

public class BaseMeleeWeaponBehaviour : MonoBehaviour
{
    public float destroyAfterSeconds;
    public WeaponSO weaponSO;

    protected float currentDamage;
    protected float currentSpeed;
    protected float currentCooldownDuration;
    protected int currentPierce;

    protected virtual void Awake()
    {
        currentDamage = weaponSO.damage;
        currentSpeed = weaponSO.speed;
        currentCooldownDuration = weaponSO.cooldownDuration;
        currentPierce = weaponSO.pierce;
    }

    protected virtual void Start()
    {
        Destroy(gameObject, destroyAfterSeconds);
    }
    protected virtual void Update()
    {

    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.CompareTag(EnemyController.ENEMY_TAG))
        //{
        //    EnemyController enemyController = collision.GetComponent<EnemyController>();

        //    enemyController.EnemyStat.TakeDamage(currentDamage);
        //}
        if (collision.TryGetComponent<ITakeDamageable>(out var damageable))
        {
            damageable.TakeDamage(currentDamage);

        }
    }
}
