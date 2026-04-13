using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour
{
    private Dictionary<ItemType, List<GameObject>> objectPools = new Dictionary<ItemType, List<GameObject>>();

    public static ObjectPoolManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void InitPool(List<ItemData> itemDataList)
    {
        foreach (var itemData in itemDataList)
        {
            if (!objectPools.ContainsKey(itemData.ItemType))
            {
                objectPools[itemData.ItemType] = new List<GameObject>();
            }
            for (int i = 0; i < itemData.spawnAmount; i++)
            {
                GameObject item = Instantiate(itemData.itemPrefab);
                item.SetActive(false);
                objectPools[itemData.ItemType].Add(item);
            }
        }
    }
    public GameObject GetObject(ItemType itemType)
    {
        foreach(var obj in objectPools[itemType])
        {
            if (!obj.activeInHierarchy)
            {
                obj.SetActive(true);
                return obj;
            }
        }
        return null;
    }
    public void ClearDictionary()
    {
        foreach (var pool in objectPools.Values)
        {
            foreach (var obj in pool)
            {
                Destroy(obj);
            }
        }
        objectPools.Clear();
    }
    public void ReturnObject(GameObject obj)
    {
        obj.SetActive(false);
    }
}
