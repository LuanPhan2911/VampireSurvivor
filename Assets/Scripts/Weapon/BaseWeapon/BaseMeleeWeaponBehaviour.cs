using UnityEngine;

public class BaseMeleeWeaponBehaviour : MonoBehaviour
{
    public float destroyAfterSeconds;

    protected virtual void Start()
    {
        Destroy(gameObject, destroyAfterSeconds);
    }
    protected virtual void Update()
    {

    }
}
