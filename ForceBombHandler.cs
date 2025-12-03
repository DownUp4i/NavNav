using UnityEngine;

public class ForceBombHandler
{
    private float _force;
    private Vector3 _targetPosition;
    private Vector3 _bombPosition;

    private Vector3 _direction;

    public ForceBombHandler (float force, Vector3 target, Vector3 bomb)
    {
        _force = force;
        _targetPosition = target;
        _bombPosition = bomb;
    }


    public void SetForceDirection()
    {
        _direction = (_bombPosition - _targetPosition) * _force;
    }
}
