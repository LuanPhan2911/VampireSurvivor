using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/PassiveItem")]
public class PassiveItemSO : ScriptableObject
{
    public string passiveItemName;
    public string description;

    public float multiplier;

    public int level;
    public PassiveItemSO nextLevelPassiveItemSO;

    public Sprite icon;
}
