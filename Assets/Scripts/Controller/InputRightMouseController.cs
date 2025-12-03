using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputRightMouseController : IInputController
{
    public bool IsInputDown() => Input.GetMouseButtonDown(1);
    public bool IsInputHold() => Input.GetMouseButton(1);
    public bool IsInputUp() => Input.GetMouseButtonUp(1); 
}
