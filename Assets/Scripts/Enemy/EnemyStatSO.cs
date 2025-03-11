using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/EnemyStat")]
public class EnemyStatSO : ScriptableObject
{
    public float moveSpeed;
    public float maxHp;
    public float damgage;

    public float dieAnimationTime;
}
