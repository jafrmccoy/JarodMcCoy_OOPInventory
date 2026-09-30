using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryReader : MonoBehaviour
{
    [SerializeField] private GameObject _inventoryItemPrefab;
    [SerializeField] private Vector3 _topRightItemPosition;
    [SerializeField] private float _newColumnDistance = 106f;
    [SerializeField] private float _newRowDistance = 106f;

    private Dictionary<Item, int> _inventory;

    private List<GameObject> _createdSlots = new List<GameObject>();

    private void OnEnable()
    {
        _inventory = InventoryManager.Instance.Inventory;
        PopulateInventoryPanel();
    }

    /// <summary>
    /// Creates copies of the prefab for each item in inventory.
    /// </summary>
    private void PopulateInventoryPanel()
    {
        List<Item> rawInventory = new List<Item>();
        
        foreach (var pair in _inventory)
        {
            if (pair.Value > 0)
            {
                for (int i = 0; i < pair.Value; i++)
                {
                    rawInventory.Add(pair.Key);
                }
            }
        }


        Vector3 placementPosition = _topRightItemPosition;

        for (int i = 0; i < rawInventory.Count; i++)
        {
            placementPosition.x += (i * _newRowDistance);
            placementPosition.y -= (i * _newColumnDistance);

            GameObject newItemSlot = Object.Instantiate(_inventoryItemPrefab, transform);
            newItemSlot.transform.localPosition = placementPosition;

            Transform newItemTransform = newItemSlot.transform;
            Image newItemImage = null;
            foreach (Transform child in newItemTransform)
            {
                newItemImage = child.GetComponent<Image>();
            }
            newItemImage.sprite = rawInventory[i].Sprite;
        }
    }
}
