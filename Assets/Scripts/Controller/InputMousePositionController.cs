using UnityEngine;

public class InputMousePositionController : InputController
{
    private Vector3 _hit;

    public override Vector3 GetDirection { get { return _hit; } }

    public override void UpdateLogic(float deltaTime)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        Physics.Raycast(ray, out RaycastHit hit);

        if (Input.GetMouseButtonDown(1))
            _hit = hit.point;
    }
}
