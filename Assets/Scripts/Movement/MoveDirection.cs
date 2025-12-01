using UnityEngine;

public class MoveDirection
{
    private CharacterController _controller;
    private float _speed;

    public MoveDirection(float speed, CharacterController controller)
    {
        _speed = speed;
        _controller = controller;
    }

    public void DirectionTo(Vector3 input)
    {
        _controller.Move(input.normalized * _speed * Time.deltaTime);
    }
}
