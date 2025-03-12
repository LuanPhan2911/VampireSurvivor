public class ExperienceGem : Pickup, ICollectable
{
    public int experienceGranted;
    public void Collect()
    {
        PlayerManager.Instance.playerStat.InscreaseExperience(experienceGranted);
    }

}
