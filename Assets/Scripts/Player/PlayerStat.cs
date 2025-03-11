using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{

    private float currentHp;
    private float currentRecovery;
    private float currentMight;

    private PlayerManager playerManager;

    [Header("Experince/Level")]
    public int experience;
    public int level = 1;
    public int experienceCap;
    [System.Serializable]
    public class LevelRange
    {
        public int startLevel;
        public int endLevel;
        public int experienceCapIncreased;
    }

    [SerializeField] private List<LevelRange> levelRangeList;
    [Header("Take Damge")]
    [SerializeField] private float takeDamagedTimerMax;
    private float takeDamageTimer;

    private void Update()
    {
        if (takeDamageTimer >= 0)
        {
            takeDamageTimer -= Time.deltaTime;
        }

    }

    private void Awake()
    {
        playerManager = GetComponent<PlayerManager>();

        currentHp = playerManager.characterSO.maxHp;
        currentMight = playerManager.characterSO.might;
        currentRecovery = playerManager.characterSO.recovery;

        experienceCap = levelRangeList[0].experienceCapIncreased;
    }

    public void InscreaseExperience(int amount)
    {
        experience += amount;
        LevelChecker();

    }
    private void LevelChecker()
    {
        if (experience >= experienceCap)
        {
            level++;
            experience -= experienceCap;
            int experienceCapInscreased = 0;
            foreach (var levelRange in levelRangeList)
            {
                if (level >= levelRange.startLevel && level <= levelRange.endLevel)
                {
                    experienceCapInscreased = levelRange.experienceCapIncreased;
                    break;
                }
            }
            experienceCap += experienceCapInscreased;

        }
    }
    public void TakeDamge(float amount)
    {
        if (takeDamageTimer < 0)
        {
            takeDamageTimer = takeDamagedTimerMax;
            currentHp -= amount;
            if (currentHp <= 0)
            {
                Die();
            }
        }

    }
    private void Die()
    {
        Debug.Log("Player die");
    }
    public void RestoreHealth(float amount)
    {
        currentHp = Mathf.Clamp(currentHp + amount, 0, playerManager.characterSO.maxHp);
    }


}
