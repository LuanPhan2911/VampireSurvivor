using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{

    [Header("Player Stats")]
    public CharacterSO characterSO;
    public BasePassiveItem passiveItem;





    public float currentHp;
    public float currentRecovery;
    public float currentMight;
    public float currentMoveSpeed;
    public float currentMagnet;
    public float currentProjectileSpeed;




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






    private void Awake()
    {
        // for development
        if (CharacterSelection.Instance?.GetSelectionCharacterSO())
        {
            characterSO = CharacterSelection.Instance.GetSelectionCharacterSO();
            CharacterSelection.Instance.Destroy();
        }



        currentHp = characterSO.maxHp;
        currentMight = characterSO.might;
        currentRecovery = characterSO.recovery;
        currentMoveSpeed = characterSO.moveSpeed;
        currentMagnet = characterSO.magnet;
        currentProjectileSpeed = characterSO.projectileSpeed;

        experienceCap = levelRangeList[0].experienceCapIncreased;


    }
    private void Start()
    {
        InventoryManager.Instance.SpawnWeapon(characterSO.weaponControlerPrefab);


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

            GameManager.Instance.StartPlayerLevelUp();

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
                Kill();
            }
        }

    }
    private void Kill()
    {
        GameManager.Instance.GameOver();
    }
    public void RestoreHealth(float amount)
    {
        currentHp = Mathf.Clamp(currentHp + amount, 0, characterSO.maxHp);
    }
    private void Recovery()
    {
        currentHp = Mathf.Clamp(currentHp + currentRecovery * Time.deltaTime, 0, characterSO.maxHp);
    }



}
