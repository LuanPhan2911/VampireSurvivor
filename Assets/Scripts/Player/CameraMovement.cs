using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform followTarget;
    [SerializeField] private Vector3 offset;

    private void Update()
    {
        transform.position = followTarget.position + offset;
    }
}
