using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Enemy")]
public class EnemySO : ScriptableObject
{
    public float moveSpeed;
    public float maxHp;
    public float damgage;
}
