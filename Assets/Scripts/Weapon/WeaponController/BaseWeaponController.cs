using UnityEngine;

public class BaseWeaponController : MonoBehaviour, ILevelUpable
{
    public WeaponSO weaponSO;
    protected float currentCooldown;
    [HideInInspector] public int slotIndex;


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

    public void LevelUp()
    {
        if (weaponSO.nextLevelWeaponSO != null)
        {
            weaponSO = weaponSO.nextLevelWeaponSO;
        }
        else
        {
            Debug.Log("No level up weapon");
        }
    }
}
