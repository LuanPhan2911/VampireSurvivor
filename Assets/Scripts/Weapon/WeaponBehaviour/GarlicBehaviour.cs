using System.Collections.Generic;
using UnityEngine;

public class GarlicBehaviour : BaseMeleeWeaponBehaviour
{
    private List<GameObject> enemyDamagedList;

    protected override void Awake()
    {
        base.Awake();
        enemyDamagedList = new List<GameObject>();
    }
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (!enemyDamagedList.Contains(collision.gameObject))
        {
            base.OnTriggerEnter2D(collision);
            enemyDamagedList.Add(collision.gameObject);
        }

    }
}
