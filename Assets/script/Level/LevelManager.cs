using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private List<LevelData> levelDataList;

    private List<GameObject> spawnedItems = new List<GameObject>();

    [SerializeField] private Transform plane;
    [SerializeField] private float ySpawnPosition = 0.2f;

    private int currentLevelIndex = 0;
    void Start()
    {
        SpawnItem();
    }
    public void NextLevel()
    {
        ClearSpawnedItems();
        currentLevelIndex++;
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
                Vector3 spawnPosition = new Vector3(Random.Range(xMin, xMax), ySpawnPosition, Random.Range(zMin, zMax));
                GameObject spawnedGameObject = Instantiate(item.itemPrefab, spawnPosition, Quaternion.identity);
                spawnedItems.Add(spawnedGameObject);
            }
        }
    }
    private void ClearSpawnedItems()
    {
        foreach (var item in spawnedItems)
        {
            Destroy(item);
        }
        spawnedItems.Clear();
    }
}
