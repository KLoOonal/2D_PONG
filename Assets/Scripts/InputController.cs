using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    public Vector2 GetTouchPosition() => touch_pos;
    private Vector2 touch_pos;
    void Update()
    {
        touch_pos = Touchscreen.current.position.ReadValue();
    }

    public void OnTryMultiTap(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Performed:
                break;
        }
    }
}

