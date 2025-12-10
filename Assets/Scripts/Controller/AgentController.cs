using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.TextCore.Text;

public class AgentController : Controller
{
    private NavMeshAgent _agent;
    private NavMeshPath _path;
    private Character _character;

    public Vector3 CurrentVelocity => _agent.desiredVelocity;
    public Vector3 MouseHitPoint => _character.MouseHitPoint;

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
        bool isAvailablePath = CheckPath(MouseHitPoint, _path);

        if (isAvailablePath)
            SetDestination(MouseHitPoint);

        if (NavMeshUtils.GetPathLength(_path) < 0.05f)
            StopMove();
        else
            ResumeMove();
    }

    public bool CheckPath(Vector3 mouseHitPoint, NavMeshPath _navMeshPath)
    => _agent.CalculatePath(mouseHitPoint, _navMeshPath);

    public void SetDestination(Vector3 direction) => _agent.SetDestination(direction);
    public void SynchronizePosition(Transform target) => _agent.nextPosition = target.position;

    public void StopMove() => _agent.isStopped = true;
    public void ResumeMove() => _agent.isStopped = false;
}
