using UnityEngine;
using UnityEngine.AI;

public class InputMouseController : InputController
{
    private Camera _camera;
    private InputController _positionController;

    private readonly int RightMouseInput = 1;
    private IControllable _controllable;

    public InputMouseController(Camera camera, IControllable controllable)
    {
        _camera = camera;
        _controllable = controllable;
        _positionController = new InputMousePositionController();
    }

    public override void UpdateLogic(float deltaTime)
    {
        _positionController.UpdateLogic(deltaTime);

        if (Input.GetMouseButtonDown(RightMouseInput))
        {
            _controllable.Controll(_positionController.GetDirection);
        }
    }
}
