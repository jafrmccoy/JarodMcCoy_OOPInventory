using UnityEngine;

public class ItemUI : MonoBehaviour
{
    private Item _itemInSlot;

    public void AddToItemUI(Item item)
    {
        _itemInSlot = item;
    }

    public void TryUseItem()
    {
        if (_itemInSlot != null)
        {
            _itemInSlot.UseItem();
        }
    }
}
