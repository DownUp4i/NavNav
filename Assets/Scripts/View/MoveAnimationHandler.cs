using UnityEngine;

public class MoveAnimationHandler : MonoBehaviour
{
    private readonly int IsRunningKey = Animator.StringToHash("IsRunning");
    private readonly int InJumpProcessKey = Animator.StringToHash("InJumpProcess");
    [SerializeField] private Animator _animator;
    [SerializeField] private AgentCharacter _character;

    private void Update()
    {
        _animator.SetBool(InJumpProcessKey, _character.InJumpProcess);

        if (_character.CurrentVelocity.magnitude > 0.05f && _character.InJumpProcess == false)
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
