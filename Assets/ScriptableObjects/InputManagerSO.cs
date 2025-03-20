using System;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName = "InputManager")]
public class InputManagerSO : ScriptableObject
{
    Controls holeControls;
    public event Action OnDashLeft;
    public event Action OnDashRight;
    public event Action OnMomentum;
    public event Action OnPause;
    public event Action<Vector2> OnDirection;

    private void OnEnable()
    {
        holeControls = new Controls();
        holeControls.Base.Enable();
        holeControls.Menu.Enable();
        holeControls.Base.Direction.performed += Direction;
        holeControls.Base.DashLeft.started += DashLeft;
        holeControls.Base.DashRight.started += DashRight;
        holeControls.Base.Momentum.started += Momentum;
        holeControls.Base.Pause.started += Pause;
    }

    private void Momentum(InputAction.CallbackContext context)
    {
        OnMomentum?.Invoke();
    }

    private void DashRight(InputAction.CallbackContext context)
    {
        OnDashRight?.Invoke();
    }

    private void DashLeft(InputAction.CallbackContext context)
    {
        OnDashLeft?.Invoke();
    }

    private void Direction(InputAction.CallbackContext context)
    {
        OnDirection?.Invoke(context.ReadValue<Vector2>());
    }

    private void Pause(InputAction.CallbackContext context)
    {
        OnPause?.Invoke();
    }
}
