using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{

    [Header("Player Stats")]
    private CharacterSO characterSO;
    public float currentHp;
    public float currentRecovery;
    public float currentMight;
    public float currentMoveSpeed;
    public float currentMagnet;



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

    private List<GameObject> spawnedWeaponList;

    private void Awake()
    {
        characterSO = CharacterSelection.Instance.GetSelectionCharacterSO();
        CharacterSelection.Instance.Destroy();

        currentHp = characterSO.maxHp;
        currentMight = characterSO.might;
        currentRecovery = characterSO.recovery;
        currentMoveSpeed = characterSO.moveSpeed;
        currentMagnet = characterSO.magnet;

        experienceCap = levelRangeList[0].experienceCapIncreased;

        spawnedWeaponList = new List<GameObject>();
    }
    private void Start()
    {
        SpawnStartWeapon(characterSO.statingWeapon);
    }

    private void Update()
    {
        if (takeDamageTimer >= 0)
        {
            takeDamageTimer -= Time.deltaTime;
        }
        Recovery();

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
        currentHp = Mathf.Clamp(currentHp + amount, 0, characterSO.maxHp);
    }
    private void Recovery()
    {
        currentHp = Mathf.Clamp(currentHp + currentRecovery * Time.deltaTime, 0, characterSO.maxHp);
    }
    private void SpawnStartWeapon(GameObject startWeaponPrefab)
    {
        GameObject startWeapon = Instantiate(startWeaponPrefab, transform);

        spawnedWeaponList.Add(startWeapon);
    }


}
