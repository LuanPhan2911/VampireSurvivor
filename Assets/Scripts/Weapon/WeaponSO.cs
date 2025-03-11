using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Weapon")]
public class WeaponSO : ScriptableObject
{
    public Transform transformPrefab;
    public float damage;
    public float speed;
    public float cooldownDuration;
    public int pierce;
}
