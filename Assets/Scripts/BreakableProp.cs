using UnityEngine;

public class BreakableProp : MonoBehaviour, ITakeDamageable
{
    public float health;


    public void TakeDamage(float damge)
    {
        health -= damge;
        if (health <= 0)
        {
            Kill();
        }
    }
    private void Kill()
    {
        Destroy(gameObject);

    }
}
