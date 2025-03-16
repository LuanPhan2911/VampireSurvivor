
using UnityEngine;

public class BaseProjectileWeaponBehaviour : MonoBehaviour
{
    [HideInInspector] public WeaponSO weaponSO;
    protected Vector3 direction;




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

    public void SetDirection(Vector3 direction)
    {
        this.direction = direction;
        float dirx = direction.x;
        float diry = direction.y;

        Vector3 scale = transform.localScale;
        Vector3 rotation = transform.rotation.eulerAngles;

        if (dirx < 0 && diry == 0) //left
        {
            scale.x = scale.x * -1;
            scale.y = scale.y * -1;
        }
        else if (dirx == 0 && diry < 0) //down
        {
            scale.y = scale.y * -1;
        }
        else if (dirx == 0 && diry > 0) //up
        {
            scale.x = scale.x * -1;
        }
        else if (dirx > 0 && diry > 0) //right up
        {
            rotation.z = 0f;
        }
        else if (dirx > 0 && diry < 0) //right down
        {
            rotation.z = -90f;
        }
        else if (dirx < 0 && diry > 0) //left up
        {
            scale.x = scale.x * -1;
            scale.y = scale.y * -1;
            rotation.z = -90f;
        }
        else if (dirx < 0 && diry < 0) //left down
        {
            scale.x = scale.x * -1;
            scale.y = scale.y * -1;
            rotation.z = 0f;
        }

        transform.localScale = scale;
        transform.rotation = Quaternion.Euler(rotation);    //Can't simply set the vector because cannot convert
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {

        //if (collision.CompareTag(EnemyController.ENEMY_TAG))
        //{
        //    EnemyController enemyController = collision.GetComponent<EnemyController>();

        //    enemyController.EnemyStat.TakeDamage(currentDamage);
        //    RecudePierce();
        //}

        if (collision.TryGetComponent<ITakeDamageable>(out var damageable))
        {

            damageable.TakeDamage(GetCurrentDamage());
            ReducePierce();
        }
    }

    private void ReducePierce()
    {
        currentPierce--;
        if (currentPierce <= 0)
        {
            Destroy(gameObject);
        }
    }




}
