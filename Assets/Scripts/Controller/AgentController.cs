using UnityEngine;
using UnityEngine.AI;

public class AgentController : Controller
{
    private IMoveable _moveable;
    private IRotatable _rotatable;

    private NavMeshAgent _agent;
    private NavMeshPath _path;
    private Character _character;

    public Vector3 CurrentVelocity => _agent.desiredVelocity;

    public AgentController(NavMeshAgent agent, Character character)
    {
        _agent = agent;
        _path = new NavMeshPath();
        _character = character;

        _agent.acceleration = 999f;

        _agent.updateRotation = false;
        _agent.updatePosition = false;
    }

    protected override void UpdateLogic(float deltaTime)
    {
        bool isAvailablePath = _agent.CalculatePath(_character.TargetPosition, _path);

        if (isAvailablePath)
            SetDestination(_character.TargetPosition);

        if (NavMeshUtils.GetPathLength(_path) < 0.05f)
            StopMove();
        else
            ResumeMove();
    }

    public void SetDestination(Vector3 direction) => _agent.SetDestination(direction);

    public void StopMove() => _agent.isStopped = true;
    public void ResumeMove() => _agent.isStopped = false;
}
