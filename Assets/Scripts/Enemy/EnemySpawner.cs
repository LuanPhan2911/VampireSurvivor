using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [System.Serializable]
    public class EnemySpawn
    {
        public GameObject enemyPrefab;
        public string enemyName;
        public int enemyCount;//total enemies will be spawned
        public int spawnCount; //The number of enemies are already spawned
    }
    [System.Serializable]
    public class Wave
    {
        public string waveName;
        public int waveQuota; // the total enemies are spawned in this wave
        public float spawnInterval; // the interval at which to spawn enemy
        public int spawnCount; // The number of enemies are already spawned in this way
        public List<EnemySpawn> enemySpawnList;

    }
    [SerializeField] private List<Wave> waveList;
    [SerializeField] private int currentWaveCount;

    [Header("Spawn Paramter")]
    private float spawnTimer;
    [SerializeField] private float waveInterval; // the interval between each wave
    [SerializeField] private int enemyAlive;
    [SerializeField] private int maxEnemyAllowed;
    [SerializeField] private bool isMaxEnemyReached = false;

    [Header("Spawn Positions ")]
    public List<Transform> spawnEnemyPositionList;

    public static EnemySpawner Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        CalculateWaveQuota();

    }

    private void Update()
    {
        if (currentWaveCount < waveList.Count &&
           waveList[currentWaveCount].spawnCount == 0)

        {
            StartCoroutine(StartNextWave());
        }

        spawnTimer += Time.deltaTime;
        if (spawnTimer > waveList[currentWaveCount].spawnInterval)
        {
            spawnTimer = 0;
            SpawnEnemies();
        }


    }
    private IEnumerator StartNextWave()
    {
        yield return new WaitForSeconds(waveInterval);
        // if there are more waves start after current way, move on to next wave
        if (currentWaveCount < waveList.Count - 1)
        {
            currentWaveCount++;
            CalculateWaveQuota();
        }
    }
    private void CalculateWaveQuota()
    {
        foreach (var enemySpawn in waveList[currentWaveCount].enemySpawnList)
        {
            waveList[currentWaveCount].waveQuota += enemySpawn.enemyCount;

        }

    }
    private void SpawnEnemies()
    {

        if (waveList[currentWaveCount].spawnCount < waveList[currentWaveCount].waveQuota && !isMaxEnemyReached)
        {
            foreach (var enemySpawn in waveList[currentWaveCount].enemySpawnList)
            {
                if (enemySpawn.spawnCount < enemySpawn.enemyCount)
                {
                    if (enemyAlive < maxEnemyAllowed)
                    {
                        Vector2 spawnPosition = PlayerManager.Instance.transform.position +
                       spawnEnemyPositionList[Random.Range(0, spawnEnemyPositionList.Count)].position;
                        Instantiate(enemySpawn.enemyPrefab, spawnPosition, Quaternion.identity);

                        enemySpawn.spawnCount++;
                        waveList[currentWaveCount].spawnCount++;
                        enemyAlive++;
                    }
                    else
                    {
                        isMaxEnemyReached = true;
                    }

                }
            }
        }
        if (enemyAlive < maxEnemyAllowed)
        {
            isMaxEnemyReached = false;
        }


    }
    public void OnEnemyKilled()
    {
        enemyAlive--;
    }
}
