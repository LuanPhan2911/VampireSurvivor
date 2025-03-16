using UnityEngine;

public class BasePassiveItem : MonoBehaviour, ILevelUpable
{
    public PassiveItemSO passiveItemSO;
    protected PlayerStat playerStat;
    [HideInInspector] public int slotIndex;

    public void LevelUp()
    {
        if (passiveItemSO.nextLevelPassiveItemSO != null)
        {
            passiveItemSO = passiveItemSO.nextLevelPassiveItemSO;
        }
        else
        {
            Debug.Log("No level up passive item");
        }
    }

    protected virtual void ApplyModifier()
    {

    }
    private void Start()
    {
        playerStat = PlayerManager.Instance.playerStat;
        ApplyModifier();

    }
}
