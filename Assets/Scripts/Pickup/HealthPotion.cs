using UnityEngine;

public class HealthPotion : MonoBehaviour, ICollectable
{
    public float restoreHealthAmount;
    public void Collect()
    {
        PlayerManager.Instance.playerStat.RestoreHealth(restoreHealthAmount);
        Destroy(gameObject);
    }


}
