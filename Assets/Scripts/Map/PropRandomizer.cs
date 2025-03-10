using UnityEngine;

public class PropRandomizer : MonoBehaviour
{
    [SerializeField] private Transform[] propPositionTransformArray;
    [SerializeField] private Transform[] propPrefabsArray;

    private void Start()
    {
        SpawnProp();
    }

    private void SpawnProp()
    {
        foreach (var propPositionTransform in propPositionTransformArray)
        {
            int randInt = Random.Range(0, propPrefabsArray.Length);
            Instantiate(propPrefabsArray[randInt], propPositionTransform);
        }
    }
}
