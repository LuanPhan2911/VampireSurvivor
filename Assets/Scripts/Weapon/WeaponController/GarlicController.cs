using UnityEngine;

public class GarlicController : BaseWeaponController
{

    protected override void Attack()
    {
        base.Attack();

        Transform garlicTransform = Instantiate(weaponSO.transformPrefab, transform);
    }
}
