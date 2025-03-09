using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    [SerializeField] private Transform[] chunkPrefabArray;

    [SerializeField] private float checkRadius;
    [SerializeField] private int terrainSize;
    [SerializeField] private LayerMask terrainLayerMask;
    private Vector3 noTerrainPosition;

    [HideInInspector] public GameObject currentChunk;

    public static MapController Instance;

    [Header("Optimizer")]
    public float maxDistance;
    [SerializeField] private List<Transform> chunkTransformList;
    public float ptimizeTimerMax;
    private float optimizeTimer;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(Instance);
        }

    }


    private void Update()
    {
        if (currentChunk == null)
        {
            return;
        }
        ChunkChecker(Vector2.up);
        ChunkChecker(Vector2.down);
        ChunkChecker(Vector2.left);
        ChunkChecker(Vector2.right);

        ChunkChecker(Vector2.up + Vector2.left);
        ChunkChecker(Vector2.down + Vector2.left);
        ChunkChecker(Vector2.up + Vector2.right);
        ChunkChecker(Vector2.down + Vector2.right);

        if (optimizeTimer < ptimizeTimerMax)
        {
            optimizeTimer += Time.deltaTime;
        }
        else
        {
            optimizeTimer = 0;
            ChunkOptimizer();
        }

    }
    private void ChunkChecker(Vector2 direction)
    {
        if (PlayerManager.Instance.playerMovement.moveDirection != Vector2.zero)
        {

            Vector2 checkPosition = (Vector2)currentChunk.transform.position + direction * terrainSize;
            if (!Physics2D.OverlapCircle(checkPosition, checkRadius, terrainLayerMask))
            {
                noTerrainPosition = checkPosition;
                SpawnChunk();
            }
        }

    }
    private void SpawnChunk()
    {
        int randInt = Random.Range(0, chunkPrefabArray.Length);
        Transform chunkTransform = Instantiate(chunkPrefabArray[randInt], transform);
        chunkTransform.position = noTerrainPosition;

        chunkTransformList.Add(chunkTransform);

    }
    private void ChunkOptimizer()
    {
        foreach (var chunkTransform in chunkTransformList)
        {
            if (Vector3.Distance(chunkTransform.position, PlayerManager.Instance.transform.position) > maxDistance)
            {
                chunkTransform.gameObject.SetActive(false);
            }
            else
            {
                chunkTransform.gameObject.SetActive(true);
            }
        }
    }

}
