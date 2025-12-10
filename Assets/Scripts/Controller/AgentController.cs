using UnityEngine;
using UnityEngine.AI;

public class AgentController : IControllable
{
    private NavMeshAgent _agent;

<<<<<<< Updated upstream
    public AgentController(NavMeshAgent agent)
=======
    public Vector3 MouseHitPoint => _character.MouseHitPoint;

    public AgentController(NavMeshAgent agent, Character character)
>>>>>>> Stashed changes
    {
        _agent = agent;
    }

    public void Controll(Vector3 direction)
    {
<<<<<<< Updated upstream
        _agent.SetDestination(direction);
    }

    public void StopMove()
    {
        _agent.isStopped = true;
    }

    public void ResumeMove()
    {
        _agent.isStopped = false;
    }
=======
        bool isAvailablePath = _character.CheckPath(MouseHitPoint, _path);

        if (isAvailablePath)
            SetDestination(MouseHitPoint);

        if (NavMeshUtils.GetPathLength(_path) < 0.05f)
            StopMove();
        else
            ResumeMove();
    }

    public void SetDestination(Vector3 direction) => _agent.SetDestination(direction);
    public void StopMove() => _agent.isStopped = true;
    public void ResumeMove() => _agent.isStopped = false;
>>>>>>> Stashed changes
}
