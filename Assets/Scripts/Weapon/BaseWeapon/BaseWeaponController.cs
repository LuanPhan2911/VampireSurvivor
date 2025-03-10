using UnityEngine;

public class BaseWeaponController : MonoBehaviour
{
    public Transform weaponPrefab;
    public float damaged;
    public float speed;
    public float cooldownDuration;
    public int pierce;
    protected float currentCooldown;


    protected virtual void Start()
    {
        currentCooldown = cooldownDuration;
    }
    protected virtual void Update()
    {
        if (currentCooldown > 0f)
        {
            currentCooldown -= Time.deltaTime;
        }
        else
        {
            Attack();
            currentCooldown = cooldownDuration;
        }
    }
    protected virtual void Attack()
    {

    }
}
