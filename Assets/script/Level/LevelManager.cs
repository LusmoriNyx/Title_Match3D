using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private List<LevelData> levelDataList;

    [SerializeField] private Transform plane;
    [SerializeField] private float ySpawnPosition = 0.2f;

    private int currentLevelIndex = 0;
    [SerializeField] private float minDistance = 1f;
    void Start()
    {
        InitializeFuntionPool();
        SpawnItem();
    }
    public void NextLevel()
    {
        ClearFuntionPool();
        currentLevelIndex++;
        InitializeFuntionPool();
        SpawnItem();
    }
    private void SpawnItem()
    {
        float xMin = plane.position.x - plane.localScale.x / 2;
        float zMin = plane.position.z - plane.localScale.z / 2;
        float xMax = plane.position.x + plane.localScale.x / 2;
        float zMax = plane.position.z + plane.localScale.z / 2;
        foreach (var item in levelDataList[currentLevelIndex].itemDataThisLevel)
        {
            for (int i = 0; i < item.spawnAmount; i++)
            {
                bool isTooClose = true;
                Vector3 spawnPosition = new Vector3(Random.Range(xMin, xMax), ySpawnPosition, Random.Range(zMin, zMax));
                while (isTooClose)
                {
                    GameObject spawnedGameObject = ObjectPoolManager.Instance.GetObject(item.ItemType);
                    if (spawnedGameObject != null)
                    {
                        spawnedGameObject.transform.position = spawnPosition;
                        spawnedGameObject.transform.rotation = Quaternion.identity;
                    }
                    isTooClose = false;
                    foreach (var itemSpawned in levelDataList[currentLevelIndex].itemDataThisLevel)
                    {
                        if(Vector3.Distance(spawnPosition, itemSpawned.itemPrefab.transform.position) < minDistance)
                        {
                            isTooClose = true;
                            break;
                        }
                    }
                }
            }
        }
    }
    private void InitializeFuntionPool()
    {
        ObjectPoolManager.Instance.InitPool(levelDataList[currentLevelIndex].itemDataThisLevel);
    }
    private void ClearFuntionPool()
    {
        ObjectPoolManager.Instance.ClearDictionary();
    }
}
