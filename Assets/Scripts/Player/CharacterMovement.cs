using UnityEngine;
using UnityEngine.AI;

public class CharacterMovement
{
    private MoveDirection _direction;
    private MoveRotation _rotation;

    public CharacterMovement(MoveDirection direction, MoveRotation rotation)
    {
        _direction = direction;
        _rotation = rotation;
    }

    public void SetDirectionTo (Vector3 direction) => _direction.DirectionTo(direction);
    public void SetInputDirection (Vector3 direction) => _rotation.SetInputDirection(direction);
}
