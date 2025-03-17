using UnityEngine;

public class BobbingAnimation : MonoBehaviour
{
    [SerializeField] private float frequency;
    [SerializeField] private float magnitude;
    [SerializeField] private Vector3 direction;

    private Vector3 initialPositiion;
    private void Start()
    {
        initialPositiion = transform.position;
    }
    private void Update()
    {
        transform.position = initialPositiion + direction * Mathf.Sin(frequency * Time.time) * magnitude;
    }

}
