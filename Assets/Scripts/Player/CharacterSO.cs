using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Character")]
public class CharacterSO : ScriptableObject
{
    public GameObject weaponControlerPrefab;

    public string characterName;
    public Sprite icon;
    public float maxHp;
    public float recovery;
    public float moveSpeed;
    public float might;

    public float projectileSpeed;
    public float magnet;
}
