public class HealthPotion : Pickup, ICollectable
{
    public float restoreHealthAmount;
    public void Collect()
    {
        PlayerManager.Instance.playerStat.RestoreHealth(restoreHealthAmount);

    }


}
