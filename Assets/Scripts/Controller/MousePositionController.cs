using UnityEngine;

public class MousePositionController : Controller
{
    private Vector3 _hit;

    private IInputController _inputController;

    public MousePositionController(IInputController inputController)
    {
        _inputController = inputController;
    }

    public override Vector3 Direction { get { return _hit; } }

    public override void UpdateLogic(float deltaTime)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        Physics.Raycast(ray, out RaycastHit hit);

        if (_inputController.IsInputDown())
            _hit = hit.point;
    }
}
