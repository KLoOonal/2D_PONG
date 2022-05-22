using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class InputController : MonoBehaviour
{
    public UnityEvent onDoubleTap;
    public UnityEvent onOneTap;
    public UnityEvent onReleaseTap;
    public Vector2 GetTouchPosition() => touch_pos;
    public bool GetDoubleTabAction() => doubleTap;
    private Vector2 touch_pos;
    public bool doubleTap;
    void FixedUpdate()
    {
        if(Touchscreen.current != null){
        touch_pos = Touchscreen.current.position.ReadValue();
        }
    }

    public void OnTryOneTap(InputAction.CallbackContext context){
        switch (context.phase)
        {
            case InputActionPhase.Performed:
                onOneTap.Invoke();
                break;
             case InputActionPhase.Canceled:
                onReleaseTap.Invoke();
                break;
        }
    }

    public void OnTryMultiTap(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Performed:
                onDoubleTap.Invoke();
                break;

        }
    }
}

