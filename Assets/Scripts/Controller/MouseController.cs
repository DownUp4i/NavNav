using UnityEngine;
using UnityEngine.AI;

public class MouseController : Controller
{
    private Camera _camera;
    private Controller _positionController;

    private IControllable _controllable;
    private IInputController _inputController;

    public MouseController(Camera camera, IControllable controllable, IInputController inputController)
    {
        _camera = camera;
        _controllable = controllable;
        _inputController = inputController;

        _positionController = new MousePositionController(_inputController);
    }

    public override void UpdateLogic(float deltaTime)
    {
        _positionController.UpdateLogic(deltaTime);

        if (_inputController.IsInputDown())
        {
            _controllable.Controll(_positionController.Direction);
        }
    }
}
