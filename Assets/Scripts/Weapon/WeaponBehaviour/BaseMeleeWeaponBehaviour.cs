using UnityEngine;

public class BaseMeleeWeaponBehaviour : MonoBehaviour
{

    [HideInInspector] public WeaponSO weaponSO;

    protected float currentDamage;
    protected float currentSpeed;
    protected float currentCooldownDuration;
    protected int currentPierce;

    protected virtual void Awake()
    {

    }

    protected virtual void Start()
    {
        currentDamage = weaponSO.damage;
        currentSpeed = weaponSO.speed;
        currentCooldownDuration = weaponSO.cooldownDuration;
        currentPierce = weaponSO.pierce;

        Destroy(gameObject, weaponSO.destroyAfterSeconds);
    }
    protected virtual void Update()
    {

    }

    public float GetCurrentDamage()
    {
        return currentDamage *= PlayerManager.Instance.playerStat.currentMight;
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
            damageable.TakeDamage(GetCurrentDamage());

        }
    }
}
