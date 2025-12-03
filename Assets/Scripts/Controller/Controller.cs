using UnityEngine;

public abstract class Controller 
{
    public virtual Vector3 Direction {  get; protected set; }

    public abstract void UpdateLogic(float deltaTime);
}
