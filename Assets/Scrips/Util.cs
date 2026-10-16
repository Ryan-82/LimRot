using UnityEngine;
using UnityEngine.InputSystem;

public static class GlobalUtils {
    public static Transform player;
}

public class InputSwitch {
    InputAction inputAction = null;
    bool toggle = true;

    public InputSwitch(string inputActionName) {
        inputAction = InputSystem.actions.FindAction(inputActionName);
    }

    public bool IsPressed()
    {
        if (toggle && inputAction.IsPressed())
        {
            toggle = false;
            return true;
        }
        else if (!inputAction.IsPressed())
        {
            toggle = true;
        }
        return false;
    }
}
