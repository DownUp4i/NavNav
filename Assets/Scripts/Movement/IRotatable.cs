using UnityEngine;

public interface IRotatable : ITransformPosition
{
    public void SetRotation(Vector3 input);
}
