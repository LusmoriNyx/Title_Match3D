using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "Scriptable Objects/ItemData")]
public class ItemData : ScriptableObject
{
    [SerializeField] private ItemType itemType;
    public GameObject itemPrefab;
    private int spawnAmount = 2;
}
