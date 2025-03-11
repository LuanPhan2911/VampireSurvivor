using UnityEngine;

public class SwordBehaviour : BaseWeaponBehaviour
{


    protected override void Update()
    {
        base.Update();

        transform.position += direction * weaponSO.speed * Time.deltaTime;
    }
}
