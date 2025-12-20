using UnityEngine;
using UnityEngine.AI;

public class AgentController : Controller
{
    private IMoveable _moveable;
    private IRotatable _rotatable;
    private IAgentMoveable _agentMoveable;
    private ITargetPosition _targetPosition;

    public AgentController(NavMeshAgent agent, IAgentMoveable agentMoveable, IMoveable moveable, IRotatable rotatable, ITargetPosition targetPosition)
    {
        _rotatable = rotatable;
        _moveable = moveable;
        _agentMoveable = agentMoveable;
        _targetPosition = targetPosition;
    }

    protected override void UpdateLogic(float deltaTime)
    {
        bool isAvailablePath = _agentMoveable.isAvailablePath(_targetPosition.TargetPosition);

        if (isAvailablePath)
        {
            SetDirection(_moveable.CurrentVelocity);
            SetRotatiton(_moveable.CurrentVelocity);
        }
        else
        {
            SetDirection(Vector3.zero);
            SetRotatiton(Vector3.zero);
        }
    }

    public void SetDirection(Vector3 direction) => _moveable.SetDirection(direction);
    public void SetRotatiton(Vector3 direction) => _rotatable.SetRotation(direction);




}
