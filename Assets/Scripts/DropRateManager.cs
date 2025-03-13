using System.Collections.Generic;
using UnityEngine;

public class DropRateManager : MonoBehaviour
{

    [System.Serializable]
    public class Drop
    {
        public string itemName;
        public GameObject itemPrefab;
        public float rate;
    }
    [SerializeField] private List<Drop> dropList;


    private void OnDestroy()
    {
        if (!gameObject.scene.isLoaded)
        {
            // is loaded= true: play mode running
            //is loaded =false: play mode stop
            return;
        }
        SpawnItem();
    }

    private void SpawnItem()
    {
        // drop item when enemy destroy

        float rate = UnityEngine.Random.Range(0, 100f);
        List<Drop> spawnedDropList = new List<Drop>();
        foreach (var drop in dropList)
        {
            if (rate <= drop.rate)
            {
                spawnedDropList.Add(drop);
            }
        }
        if (spawnedDropList.Count > 0)
        {
            int dropIndex = UnityEngine.Random.Range(0, spawnedDropList.Count);
            Instantiate(spawnedDropList[dropIndex].itemPrefab, transform.position, Quaternion.identity);
        }
    }



}
