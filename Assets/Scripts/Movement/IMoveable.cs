using UnityEngine;

public interface IMoveable
{
    Vector3 CurrentVelocity { get; }

    public void SetDirection(Vector3 input);
}
