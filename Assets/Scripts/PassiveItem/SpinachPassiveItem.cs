public class SpinachPassiveItem : BasePassiveItem
{
    protected override void ApplyModifier()
    {
        playerStat.currentMight *= 1 + passiveItemSO.multiplier / 100f;
    }
}
