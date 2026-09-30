using UnityEngine;
using UnityEngine.InputSystem;

public class InteractionMode : MonoBehaviour
{
    [SerializeField] InputActionReference _lookMode;
    [SerializeField] InputActionReference _useMode;

    [SerializeField] private Texture2D[] _cursorSprites;
    private Vector2 _hotSpot = Vector2.zero;

    public enum InteractionState
    {
        nothing,
        looking,
        pickingUp,
        usingOn,
        talking
    }
    public static InteractionState CurrentInteractionState;

    private void Start()
    {
        CurrentInteractionState = InteractionState.nothing;
    }

    private void Update()
    {
        if (_lookMode.action.WasPressedThisFrame())
        {
            if (CurrentInteractionState == InteractionState.looking)
            {
                CurrentInteractionState = InteractionState.nothing;
                SetCursor(-1);
            }
            else
            {
                CurrentInteractionState = InteractionState.looking;
                SetCursor(0);
            }
        }

        if (_useMode.action.WasPressedThisFrame())
        {
            if (CurrentInteractionState == InteractionState.pickingUp)
            {
                CurrentInteractionState = InteractionState.nothing;
                SetCursor(-1);
            }
            else
            {
                CurrentInteractionState = InteractionState.pickingUp;
                SetCursor(1);
            }
        }
    }

    private void SetCursor(int cursor)
    {
        if (cursor >= 0)
        {
            Cursor.SetCursor(_cursorSprites[cursor], _hotSpot, CursorMode.Auto);
        }
        else
        {
            Cursor.SetCursor(null, _hotSpot, CursorMode.Auto);
        }
    }
}
