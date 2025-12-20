using UnityEngine;

public class MoveAnimationHandler : MonoBehaviour
{
    private readonly int IsRunningKey = Animator.StringToHash("IsRunning");
    [SerializeField] private Animator _animator;
    [SerializeField] private AgentCharacter _character;

    private void Update()
    {
        if (_character.CurrentVelocity.magnitude > 0.05f)
            StartRunning();
        else
            StopRuning();
    }

    private void StartRunning()
    {
        _animator.SetBool(IsRunningKey, true);
    }

    private void StopRuning()
    {
        _animator.SetBool(IsRunningKey, false);
    }
}
