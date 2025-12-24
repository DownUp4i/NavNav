using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class AgentJumpHandler
{
    private float _speed;
    private NavMeshAgent _agent;

    private MonoBehaviour _coroutineRunner;
    private Coroutine _jumpProcess;
    private AnimationCurve _yOffsetCurve;

    public AgentJumpHandler(float speed, NavMeshAgent agent, MonoBehaviour coroutineRunner, AnimationCurve OffsetCurve)
    {
        _speed = speed;
        _agent = agent;
        _coroutineRunner = coroutineRunner;
        _yOffsetCurve = OffsetCurve;
    }

    public bool InProcess => _jumpProcess != null;

    public void Jump(OffMeshLinkData offMeshLinkData, Vector3 endJumpPosition)
    {
        if (InProcess)
            return;

        _jumpProcess = _coroutineRunner.StartCoroutine(JumpProcess(offMeshLinkData, endJumpPosition));
    }

    private IEnumerator JumpProcess(OffMeshLinkData offMeshLinkData, Vector3 endJumpPosition)
    {
        float duration = Vector3.Distance(offMeshLinkData.startPos, endJumpPosition) / _speed;

        float progress = 0;

        while (progress < duration)
        {
            float yOffset = _yOffsetCurve.Evaluate(progress / duration);
            _agent.transform.position = Vector3.Lerp(offMeshLinkData.startPos, endJumpPosition, progress / duration) + Vector3.up * yOffset;
            progress += Time.deltaTime;
            yield return null;
        }

        _agent.CompleteOffMeshLink();

        _jumpProcess = null;
    }
}
