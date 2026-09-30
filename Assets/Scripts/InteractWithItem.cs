using UnityEngine;
using UnityEngine.InputSystem;

public class InteractWithItem : MonoBehaviour
{
    private InteractionMode.InteractionState _currentInteractionState => InteractionMode.CurrentInteractionState;
    private Camera _mainCamera;
    private void Start()
    {
        _mainCamera = Camera.main;
    }

    private void Update()
    {
        Vector2 mousePosition = Mouse.current.position.ReadValue();

        Ray ray = _mainCamera.ScreenPointToRay(mousePosition);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, Mathf.Infinity) && Mouse.current.leftButton.wasPressedThisFrame)
        {
            Item item = hitInfo.collider.gameObject.GetComponent<Item>();
            if (item != null)
            {
                switch (_currentInteractionState)
                {
                    default:
                    case InteractionMode.InteractionState.nothing:
                        break;
                    case InteractionMode.InteractionState.looking:
                        //get flavor text
                        item.LookItem();
                        break;
                    case InteractionMode.InteractionState.pickingUp:
                        //try to use
                        item.PickupItem();
                        break;
                    case InteractionMode.InteractionState.usingOn:
                        break;
                    case InteractionMode.InteractionState.talking:
                        break;
                }
            }
        }
    }
}
