using UnityEngine;

public abstract class InputController 
{
    public virtual Vector3 GetDirection {  get; protected set; }

    public abstract void UpdateLogic(float deltaTime);
}
