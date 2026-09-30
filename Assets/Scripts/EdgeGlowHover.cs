using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Outline))]
public class EdgeGlowHover : MonoBehaviour
{
    private Outline _outline;
    [SerializeField] private float _outlineWidth = 5f;
    [SerializeField] private float _outlineGrowthSpeed = 20f;
    private Camera _mainCamera;
    private Collider _collider;
    private bool _isHovering;

    private Coroutine _glowCoroutine;

    private void Start()
    {
        _mainCamera = Camera.main;
        _collider = GetComponent<Collider>();
        _isHovering = false;
        _outline = gameObject.GetComponent<Outline>();
        _outline.OutlineWidth = 0;

        Item item = GetComponent<Item>();

        if (item != null)
        {
            _outline.OutlineColor = item.GetGlowColor();
        }
        else
        {
            _outline.OutlineColor = Color.white;
        }

    }

    private void Update()
    {
        Vector2 mousePosition = Mouse.current.position.ReadValue();

        Ray ray = _mainCamera.ScreenPointToRay(mousePosition);

        if (_collider.Raycast(ray, out RaycastHit hit, Mathf.Infinity))
        {
            if (!_isHovering)
            {
                _isHovering = true;

                if (_glowCoroutine != null)
                {
                    StopCoroutine(_glowCoroutine);
                }
            }

            OnHoverStay();
        }
        else
        {
            if (_isHovering)
            {
                _isHovering = false;
                OnHoverExit();
            }
        }
    }

    private void OnHoverStay()
    {
        if (_outline.OutlineWidth < _outlineWidth)
        {
            _outline.OutlineWidth += _outlineGrowthSpeed * Time.deltaTime;
        }
    }

    private void OnHoverExit()
    {
        if (_glowCoroutine != null)
        {
            StopCoroutine(_glowCoroutine);
        }

        _glowCoroutine = StartCoroutine(StopGlow());
    }

    private IEnumerator StopGlow()
    {
        while (_outline.OutlineWidth > 0f)
        {
            _outline.OutlineWidth -= _outlineGrowthSpeed * Time.deltaTime;
            yield return null;
        }
    }
}
