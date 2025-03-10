using UnityEngine;
public class SwordController : BaseWeaponController
{
    protected override void Attack()
    {
        base.Attack();
        Transform swordTransform = Instantiate(weaponPrefab);
        swordTransform.transform.position = transform.position;
        BaseWeaponBehaviour swordBehaviour = swordTransform.GetComponent<BaseWeaponBehaviour>();

        swordBehaviour.SetDirection(PlayerManager.Instance.playerMovement.lastDirection.normalized);
        swordBehaviour.SetControler(this);


    }
}
