using UnityEngine;
public class SwordController : BaseWeaponController
{
    protected override void Attack()
    {
        base.Attack();
        Transform swordTransform = Instantiate(weaponSO.transformPrefab);
        swordTransform.transform.position = transform.position;
        BaseWeaponBehaviour swordBehaviour = swordTransform.GetComponent<BaseWeaponBehaviour>();

        swordBehaviour.SetDirection(PlayerManager.Instance.playerMovement.lastDirection.normalized);



    }
}
