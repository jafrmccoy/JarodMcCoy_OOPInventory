using UnityEngine;

public class Armor : Item
{
    public override void UseItem()
    {
        Debug.Log("You tried to use the armor, " + Name + "!");
    }

    public override void PickupItem()
    {
        Debug.Log("You tried to grab the armor, " + Name + "!");
    }

    public override void LookItem()
    {
        Debug.Log("You tried to look at the armor, " + Name + "!");
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