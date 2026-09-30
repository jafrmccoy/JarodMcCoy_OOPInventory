using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class CameraTurn : MonoBehaviour
{
    [SerializeField] InputActionReference turnRight;
    [SerializeField] InputActionReference turnLeft;

    [SerializeField] private float _turnSpeed;

    private IEnumerator _turnCoroutine;

    private float _targetYAngle;
    private float _currentYangle;

    private bool _isTurning;
    public bool IsTurning => _isTurning;

    public static CameraTurn Instance;

    private void Start()
    {
        if (Instance != null)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        _currentYangle = transform.localEulerAngles.y;
        _targetYAngle = _currentYangle;
        _turnCoroutine = null;
    }

    private void Update()
    {
        if (turnRight.action.WasPressedThisFrame())
        {
            //turn right
            _targetYAngle += 90f;
            StartTurn();
        }
        if (turnLeft.action.WasPressedThisFrame())
        {
            //turn left
            _targetYAngle -= 90f;
            StartTurn();
        }
    }

    private void StartTurn()
    {
        if (_turnCoroutine != null)
        {
            StopCoroutine(_turnCoroutine);
        }
        _turnCoroutine = Turn();
        StartCoroutine(_turnCoroutine);
    }

    private IEnumerator Turn()
    {
        _isTurning = true;
        while (!Mathf.Approximately(_currentYangle, _targetYAngle))
        {
            float step = _turnSpeed * Time.deltaTime;

            _currentYangle = Mathf.Lerp(_currentYangle, _targetYAngle, step);

            transform.localRotation = Quaternion.Euler(transform.eulerAngles.x, _currentYangle, transform.localEulerAngles.z);

            yield return null;
        }

        _currentYangle = _targetYAngle;
        transform.localRotation = Quaternion.Euler(transform.eulerAngles.x, _targetYAngle, transform.localEulerAngles.z);
        _isTurning = false;
        _turnCoroutine = null;
    }
}
