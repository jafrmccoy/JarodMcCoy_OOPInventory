using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private Dictionary<Item, int> _inventory = new Dictionary<Item, int>();
    public Dictionary<Item, int> Inventory { get { return _inventory; } }

    [SerializeField] private int _inventorySize = 20;

    public static InventoryManager Instance;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    /// <summary>
    /// Adds a single copy of the given item to the player's inventory.
    /// </summary>
    /// <param name="item">The item to be added.</param>
    /// <returns>True if the item was successfully added to the inventory, else false.</returns>
    public bool AddItemToInventory(Item item)
    {
        //Check if Inventory full
        if (!WouldOverfillInventory(item))
        {
            if (_inventory.TryGetValue(item, out int count))
            {
                _inventory[item] = count + 1;
                return true;
            }
            else
            {
                _inventory[item] = 1;
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// Removes a single copy of the given item from the player's inventory.
    /// </summary>
    /// <param name="item">The item to be removed.</param>
    /// <returns>True if the item was successfully removed from the inventory, else false.</returns>
    public bool RemoveItemFromIventory(Item item)
    {
        if (_inventory.TryGetValue(item, out int count) && count > 0)
        {
            _inventory[item] = count - 1;
            return true;
        }

        return false;
    }

    /// <summary>
    /// Checks if the player inventory contains at least one copy of the given item.
    /// </summary>
    /// <param name="item">The item to be looked for.</param>
    /// <returns>True if the inventory contains the item, else false.</returns>
    public bool HasItem(Item item)
    {
        if (_inventory.TryGetValue(item, out int count) && count > 0) return true;

        return false;
    }

    /// <summary>
    /// Checks if the player inventory contains a given number of copies of the given item.
    /// </summary>
    /// <param name="item">The item to be looked for.</param>
    /// <param name="quantity">The number of copies to be looked for.</param>
    /// <returns>True if the inventory contains the given item in the given number, else false.</returns>
    public bool HasItemOfQuantity(Item item, int quantity)
    {
        if (_inventory.TryGetValue(item, out int count) && count >= quantity) return true;

        return false;
    }

    /// <summary>
    /// Checks if the player's inventory is full (or overfull).
    /// </summary>
    /// <returns>True if the player's inventory is full or overfull, else false.</returns>
    private bool CheckInventoryFull()
    {
        int slotsFilled = 0;

        foreach (var itemPair in _inventory)
        {
            slotsFilled += itemPair.Key.Size * itemPair.Value;
        }

        if (slotsFilled >= _inventorySize) return true;
        return false;
    }

    /// <summary>
    /// Checks if adding the given item would overfill the player's inventory.
    /// </summary>
    /// <param name="itemToAdd">The item to be added.</param>
    /// <returns>True if the inventory would be overfilled, else false.</returns>
    private bool WouldOverfillInventory(Item itemToAdd)
    {
        int slotsFilled = 0;

        foreach (var itemPair in _inventory)
        {
            slotsFilled += itemPair.Key.Size * itemPair.Value;
        }

        if (itemToAdd.Size + slotsFilled > _inventorySize) return true;

        return false;
    }
}
