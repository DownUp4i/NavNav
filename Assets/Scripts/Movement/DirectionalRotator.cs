using UnityEngine;

public class DirectionalRotator
{
    private float _speed;
    private Transform _transform;

    public DirectionalRotator(float speed, Transform transform)
    {
        _speed = speed;
        _transform = transform;
    }

    public void Rotate(Vector3 direction)
    {
        if (direction.magnitude < 0.05f)
            return;

        Quaternion lookRotation = Quaternion.LookRotation(direction.normalized);

        float step = _speed * Time.deltaTime;

        _transform.rotation = Quaternion.RotateTowards(_transform.rotation, lookRotation, step);
    }
}
