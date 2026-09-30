using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    [SerializeField] private string _name;
    public string Name { get { return _name; } }

    [TextArea(5, 10)]
    [SerializeField] private string _flavor;

    public string Flavor { get { return _flavor; } }

    //principles are a lore thing
    [SerializeField] private Dictionary<string, int> _principles;
    public Dictionary<string, int> Principles { get { return _principles; } }

    [SerializeField] private int _size = 1;
    public int Size { get { return _size; } }

    [SerializeField] private Sprite _sprite;
    public Sprite Sprite { get { return _sprite; } }

    /// <summary>
    /// Attempts to use the item.
    /// </summary>
    public abstract void UseItem();

    /// <summary>
    /// Attempts to put the item into the player's inventory.
    /// </summary>
    public abstract void PickupItem();

    /// <summary>
    /// Looks at the item.
    /// </summary>
    public abstract void LookItem();

    /// <summary>
    /// Gets the color for items that glow when hovered over.
    /// </summary>
    /// <returns></returns>
    public abstract Color GetGlowColor();
}
