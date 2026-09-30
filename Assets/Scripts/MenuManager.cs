using UnityEngine;
using UnityEngine.InputSystem;

public class MenuManager : MonoBehaviour
{
    [SerializeField] InputActionReference _inventoryAction;

    [SerializeField] GameObject _inventoryMenuObject;

    private void Update()
    {
        if (_inventoryAction.action.WasPressedThisFrame())
        {
            _inventoryMenuObject.SetActive(!_inventoryMenuObject.activeInHierarchy);
        }
    }
}
