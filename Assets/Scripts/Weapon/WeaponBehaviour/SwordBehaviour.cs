using UnityEngine;

public class SwordBehaviour : BaseProjectileWeaponBehaviour
{


    protected override void Update()
    {
        base.Update();

        transform.position += direction * weaponSO.speed * Time.deltaTime;
    }
}
