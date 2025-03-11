using UnityEngine;

public class BaseWeaponController : MonoBehaviour
{
    public WeaponSO weaponSO;
    protected float currentCooldown;


    protected virtual void Start()
    {
        currentCooldown = weaponSO.cooldownDuration;
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
            currentCooldown = weaponSO.cooldownDuration;
        }
    }
    protected virtual void Attack()
    {

    }
}
