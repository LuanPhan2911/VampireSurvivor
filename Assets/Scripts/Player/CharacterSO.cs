using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Character")]
public class CharacterSO : ScriptableObject
{
    public GameObject weaponControlerPrefab;
    public float maxHp;
    public float recovery;
    public float moveSpeed;
    public float might;

    public float projectileSpeed;
    public float magnet;
}
