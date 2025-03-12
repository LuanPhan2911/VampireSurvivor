using UnityEngine;

public class SwordBehaviour : BaseProjectileWeaponBehaviour
{


    protected override void Update()
    {
        base.Update();

        transform.position += direction * currentSpeed * Time.deltaTime;
    }
}
