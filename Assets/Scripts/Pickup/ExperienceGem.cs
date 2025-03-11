using UnityEngine;

public class ExperienceGem : MonoBehaviour, ICollectable
{
    public int experienceGranted;
    public void Collect()
    {
        PlayerManager.Instance.playerStat.InscreaseExperience(experienceGranted);
        Destroy(gameObject);
    }
}
