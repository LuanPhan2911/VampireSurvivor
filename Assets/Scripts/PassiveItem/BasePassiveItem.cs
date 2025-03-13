using UnityEngine;

public class BasePassiveItem : MonoBehaviour
{
    public PassiveItemSO passiveItemSO;
    protected PlayerStat playerStat;
    protected virtual void ApplyModifier()
    {

    }
    private void Start()
    {
        playerStat = PlayerManager.Instance.playerStat;
        ApplyModifier();

    }
}
