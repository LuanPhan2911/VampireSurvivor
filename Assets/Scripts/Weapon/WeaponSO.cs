using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Weapon")]
public class WeaponSO : ScriptableObject
{
    public GameObject prefab;
    public float damage;
    public float speed;
    public float cooldownDuration;
    public float destroyAfterSeconds;
    public int pierce;

    public int level;
    public WeaponSO nextLevelWeaponSO;

    public Sprite icon;
}
