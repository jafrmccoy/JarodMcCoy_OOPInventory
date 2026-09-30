using UnityEngine;

public class Consumable : Item
{
    [SerializeField] private int _uses;

    public override void UseItem()
    {
        Debug.Log("You tried to use the consumable, " + Name + "!");
        if (_uses > 0)
        {
            _uses--;
            Debug.Log(_uses + " uses remaining.");
        }
        else
        {
            InventoryManager.Instance.RemoveItemFromIventory(this);
        }
        
    }

    public override void PickupItem()
    {
        Debug.Log("You tried to grab the consumable, " + Name + "!");

        if (InventoryManager.Instance.AddItemToInventory(this))
        {
            Debug.Log("Success!");
            gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("Failure!");
        }
    }

    public override void LookItem()
    {
        Debug.Log("You tried to look at the consumable, " + Name + "!");
    }
    public override Color GetGlowColor()
    {
        string largestPrinciple = "";
        int largestPrincipleCount = 0;
        foreach (var pair in Principles)
        {
            if (pair.Value > largestPrincipleCount)
            {
                largestPrinciple = pair.Key;
                largestPrincipleCount = pair.Value;
            }
        }

        if (largestPrinciple == "")
        {
            return Color.white;
        }

        return PrinciplesColorDictionary.PrincipleColors[largestPrinciple];
    }
}
