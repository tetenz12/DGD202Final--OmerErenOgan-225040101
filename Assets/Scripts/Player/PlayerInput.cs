using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerMover))]
public class PlayerInput : MonoBehaviour
{
    private PlayerMover _playerMover;
    private PlayerInputActions _inputActions;
    private Vector2 _currentMoveInput;

    private void Awake()
    {
        _playerMover = GetComponent<PlayerMover>();
        _inputActions = new PlayerInputActions();
    }

    private void OnEnable()
    {
        _inputActions.Player.Enable();
        _inputActions.Player.Move.performed += OnMove;
        _inputActions.Player.Move.canceled += OnMove;
    }

    private void OnDisable()
    {
        _inputActions.Player.Move.performed -= OnMove;
        _inputActions.Player.Move.canceled -= OnMove;
        _inputActions.Player.Disable();
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        _currentMoveInput = context.ReadValue<Vector2>();
    }

    private void Update()
    {
        _playerMover.Move(_currentMoveInput);
    }
} 