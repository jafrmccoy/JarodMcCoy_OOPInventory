using UnityEngine;

public class SetPiece : Item
{
    public override void UseItem()
    {
        Debug.Log("You tried to use the set piece, " + Name + "! (stupid lol)");
    }

    public override void PickupItem()
    {
        Debug.Log("You tried to grab the set piece, " + Name + "!");
    }

    public override void LookItem()
    {
        Debug.Log("You tried to look at the set piece, " + Name + "!");
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