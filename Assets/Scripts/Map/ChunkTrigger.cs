using UnityEngine;

public class ChunkTrigger : MonoBehaviour
{
    [SerializeField] private GameObject targetChunk;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            MapController.Instance.currentChunk = targetChunk;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            MapController.Instance.currentChunk = targetChunk;
        }
    }
}
