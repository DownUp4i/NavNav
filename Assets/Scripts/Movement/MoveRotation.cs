using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class MoveRotation 
{
    private float _speed;
    private Transform _transform;

    public MoveRotation(float speed, Transform transform)
    {
        _speed = speed;
        _transform = transform;
    }

    public void SetInputDirection(Vector3 input)
    {
        if (input.magnitude < 0.05f)
            return;

        Quaternion lookRotation = Quaternion.LookRotation(input);

        float step = _speed * Time.deltaTime;

        _transform.rotation = Quaternion.RotateTowards(_transform.rotation, lookRotation, step);
    }


}
