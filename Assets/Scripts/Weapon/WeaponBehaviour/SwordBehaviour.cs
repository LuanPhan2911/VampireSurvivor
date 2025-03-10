using UnityEngine;

public class SwordBehaviour : BaseWeaponBehaviour
{


    protected override void Update()
    {
        base.Update();

        transform.position += direction * controller.speed * Time.deltaTime;
    }
}
