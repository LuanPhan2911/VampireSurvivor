public class HealthPotion : Pickup
{
    public float restoreHealthAmount;
    public override void Collect()
    {
        if (isPicked)
        {
            return;
        }
        else
        {
            base.Collect();
        }
        PlayerManager.Instance.playerStat.RestoreHealth(restoreHealthAmount);

    }


}
