using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Character")]
public class CharacterSO : ScriptableObject
{
    public GameObject statingWeapon;
    public float maxHp;
    public float recovery;
    public float moveSpeed;
    public float might;

    public float projectileSpeed;
    public float magnet;
}
