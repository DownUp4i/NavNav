using UnityEngine;
using UnityEngine.AI;

public class MouseController : Controller
{
    private Camera _camera;

    private Vector3 _hitPoint;
    public Vector3 HitPoint => _hitPoint;
    public bool IsButtonDown { get; private set; }

    public MouseController(Camera camera)
    {
        _camera = camera;
    }

    protected override void UpdateLogic(float deltaTime)
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

        Physics.Raycast(ray, out RaycastHit hit);

        if (Input.GetMouseButtonDown(1))
            _hitPoint = hit.point;

        IsButtonDown = Input.GetMouseButtonDown(1);
    }
}
