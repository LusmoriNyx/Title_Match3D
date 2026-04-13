using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "Scriptable Objects/ItemData")]
public class ItemData : ScriptableObject
{
    [SerializeField] private ItemType itemType;
    public ItemType ItemType => itemType;

    public GameObject itemPrefab;
    public int spawnAmount = 2;
}
