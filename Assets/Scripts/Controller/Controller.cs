using UnityEngine;

public abstract class Controller
{
    private bool _isEnable;

    public void OnEnable() => _isEnable = true;
    public void OnDisable() => _isEnable = false;

    public void Update(float deltaTime)
    {
        if (_isEnable == false)
            return;

        UpdateLogic(deltaTime);
    }

    protected abstract void UpdateLogic(float deltaTime);
}
