using UnityEngine;

public interface IMoveable : ITransformPosition, ITargetPosition
{
    Vector3 CurrentVelocity { get; }

    public void SetDirection(Vector3 input);
}
