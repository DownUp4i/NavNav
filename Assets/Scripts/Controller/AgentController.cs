using UnityEngine;
using UnityEngine.AI;

public class AgentController : IControllable
{
    private NavMeshAgent _agent;

    public AgentController(NavMeshAgent agent)
    {
        _agent = agent;
    }

    public void Controll(Vector3 direction)
    {
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
}
