using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class MoveRotation
{
    private IRotatable _rotatable;
    public MoveRotation(IRotatable rotatable)
    {
        _rotatable = rotatable;
    }

    public void SetRotation(Vector3 input, float speed, Transform transform)
    {
        if (input.magnitude < 0.05f)
            return;

        Quaternion lookRotation = Quaternion.LookRotation(input);

        float step = speed * Time.deltaTime;

        transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, step);

        _rotatable.SetRotation(input);
    }
}
