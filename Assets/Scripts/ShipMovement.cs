using UnityEngine;
using UnityEngine.InputSystem;

public class ShipMovement : MonoBehaviour
{
    [Header("Input Action Asset")]
    [SerializeField] private InputActionAsset InputActions;

    private InputAction m_upAction;
    private InputAction m_leftAction;
    private InputAction m_rightAction;

    [HideInInspector] public bool IsMoveForward = false;
    [HideInInspector] public bool IsMoveLeft = false;
    [HideInInspector] public bool IsMoveRight = false;

    private void OnEnable()
    {
        InputActions.FindActionMap("Player").Enable();
    }

    private void OnDisable()
    {
        InputActions.FindActionMap("Player").Disable();
    }

    private void Awake()
    {
        m_upAction = InputSystem.actions.FindAction("Up");
        m_leftAction = InputSystem.actions.FindAction("Left");
        m_rightAction = InputSystem.actions.FindAction("Right");

        m_upAction.performed += OnPressUp;
        m_upAction.canceled += OnCancelUp;
        m_leftAction.performed += OnPressLeft;
        m_leftAction.canceled += OnCancelLeft;
        m_rightAction.performed += OnPressRight;
        m_rightAction.canceled += OnCancelRight;
    }

    private void OnPressUp(InputAction.CallbackContext context)
    {
        IsMoveForward = true;
    }

    private void OnCancelUp(InputAction.CallbackContext context)
    {
        IsMoveForward = false;
    }

    private void OnPressLeft(InputAction.CallbackContext context)
    {
        IsMoveLeft = true;
    }

    private void OnCancelLeft(InputAction.CallbackContext context)
    {
        IsMoveLeft = false;
    }

    private void OnPressRight(InputAction.CallbackContext context)
    {
        IsMoveRight = true;
    }

    private void OnCancelRight(InputAction.CallbackContext context)
    {
        IsMoveRight = false;
    }
}
