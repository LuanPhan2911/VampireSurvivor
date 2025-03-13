public class WingPassiveItem : BasePassiveItem
{
    protected override void ApplyModifier()
    {
        playerStat.currentMoveSpeed *= 1 + passiveItemSO.multiplier / 100f;
    }
}
