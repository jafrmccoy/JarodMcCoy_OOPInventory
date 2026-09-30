using UnityEngine;

public class Weapon : Item
{
    [SerializeField] private string _weaponType;

    public override void UseItem()
    {
        Debug.Log("You tried to use the weapon, " + Name + "!");
    }
    
    public override void PickupItem()
    {
        Debug.Log("You tried to grab the weapon, " + Name + "!");

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
        Debug.Log("You tried to look at the weapon, " + Name + "!");
    }

    public override Color GetGlowColor()
    {

        if (!IsEdgeWeapon())
        {
            string largestPrinciple = "";
            int largestPrincipleCount = 0;
            foreach (var pair in Principles)
            {
                if (pair.Key != "Edge" && pair.Value > largestPrincipleCount)
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
        else
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

    private bool IsEdgeWeapon()
    {
        return (_weaponType == "Sword");
    }
}
