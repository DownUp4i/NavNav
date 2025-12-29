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
    private IJumpable _jumpable;

    public AgentJumpHandler(float speed, NavMeshAgent agent, MonoBehaviour coroutineRunner, AnimationCurve OffsetCurve)
    {
        _speed = speed;
        _agent = agent;
        _coroutineRunner = coroutineRunner;
        _yOffsetCurve = OffsetCurve;
    }

    public bool InProcess => _jumpProcess != null;

    public void Jump(OffMeshLinkData offMeshLinkData)
    {
        if (InProcess)
            return;

        _jumpProcess = _coroutineRunner.StartCoroutine(JumpProcess(offMeshLinkData));
    }

    public void Update(OffMeshLinkData offMeshLinkData)
    {
        Jump(offMeshLinkData);
    }

    private IEnumerator JumpProcess(OffMeshLinkData offMeshLinkData)
    {
        float duration = Vector3.Distance(offMeshLinkData.startPos, offMeshLinkData.endPos) / _speed;

        float progress = 0;

        while (progress < duration)
        {
            float yOffset = _yOffsetCurve.Evaluate(progress / duration);
            _agent.transform.position = Vector3.Lerp(offMeshLinkData.startPos, offMeshLinkData.endPos, progress / duration) + Vector3.up * yOffset;
            progress += Time.deltaTime;
            yield return null;
        }

        _agent.CompleteOffMeshLink();

        _jumpProcess = null;
    }
}
