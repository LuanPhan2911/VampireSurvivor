using UnityEngine;

public class GarlicController : BaseWeaponController
{

    protected override void Attack()
    {
        base.Attack();

        GameObject garlic = Instantiate(weaponSO.prefab, transform);
        garlic.GetComponent<BaseMeleeWeaponBehaviour>().weaponSO = weaponSO;
    }
}
