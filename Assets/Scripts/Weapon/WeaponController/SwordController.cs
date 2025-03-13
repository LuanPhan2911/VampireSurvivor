using UnityEngine;
public class SwordController : BaseWeaponController
{
    protected override void Attack()
    {
        base.Attack();
        GameObject sword = Instantiate(weaponSO.prefab);
        sword.transform.position = transform.position;
        BaseProjectileWeaponBehaviour swordBehaviour = sword.GetComponent<BaseProjectileWeaponBehaviour>();

        swordBehaviour.weaponSO = weaponSO;
        swordBehaviour.SetDirection(PlayerManager.Instance.playerMovement.lastDirection.normalized);



    }
}
