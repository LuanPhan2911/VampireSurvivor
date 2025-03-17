public class ExperienceGem : Pickup
{
    public int experienceGranted;
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
        PlayerManager.Instance.playerStat.InscreaseExperience(experienceGranted);
    }

}
