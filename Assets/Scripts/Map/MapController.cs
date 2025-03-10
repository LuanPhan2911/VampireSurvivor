using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    [SerializeField] private Transform[] chunkPrefabArray;

    [SerializeField] private float checkRadius;
    [SerializeField] private int terrainSize;
    [SerializeField] private LayerMask terrainLayerMask;

    [HideInInspector] public GameObject currentChunk;

    public static MapController Instance;

    [Header("Optimizer")]
    public float maxDistance;
    [SerializeField] private List<Transform> chunkTransformList;
    public float optimizeTimerMax;
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
        ChunkChecker();

        if (optimizeTimer < optimizeTimerMax)
        {
            optimizeTimer += Time.deltaTime;
        }
        else
        {
            optimizeTimer = 0;
            ChunkOptimizer();
        }

    }
    private void ChunkChecker()
    {
        if (PlayerManager.Instance.playerMovement.moveDirection != Vector2.zero)
        {

            foreach (var direction in GetSideDirection(PlayerManager.Instance.playerMovement.moveDirection))
            {
                Vector2 checkPosition = (Vector2)currentChunk.transform.position + direction.normalized * terrainSize;

                if (!Physics2D.OverlapPoint(checkPosition, terrainLayerMask))
                {
                    SpawnChunk(checkPosition);
                }
            }

        }

    }
    private void SpawnChunk(Vector2 spawnPosition)
    {
        int randInt = Random.Range(0, chunkPrefabArray.Length);
        Transform chunkTransform = Instantiate(chunkPrefabArray[randInt], transform);
        chunkTransform.position = spawnPosition;

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

    private Vector2[] GetSideDirection(Vector2 direction)
    {

        // Determine perpendicular shift (left and right)
        Vector2 leftShift = new Vector2(-direction.y, direction.x);
        Vector2 rightShift = new Vector2(direction.y, -direction.x);

        // Return an array of previous (left), current, and next (right) directions
        return new Vector2[] { direction + leftShift, direction, direction + rightShift };
    }

}
