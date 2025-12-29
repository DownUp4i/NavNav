using UnityEngine;

public class DamageAnimationHandler : MonoBehaviour
{
    [SerializeField] private AgentCharacter _character;

    private readonly int IsDeadKey = Animator.StringToHash("IsDead");
    private readonly int TakeDamageKey = Animator.StringToHash("TakeDamage");

    private Animator _animator;

    private bool _isAnimationRunning = true;

    public bool IsAnimationRunning => _isAnimationRunning;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _isAnimationRunning = false;
    }

    private void Update()
    {
        Debug.Log(_character.IsTakedDamage + " _character.IsTakedDamage");
        Debug.Log(_isAnimationRunning + " _isAnimationRunning");

        if (_character.IsTakedDamage == true)
            TakeDamageStart();

        if (_character.IsDead == true)
            StartDead();
    }

    public void OnAnimationEnd()
    {
        _isAnimationRunning = false;
        _character.ResetTakeDamage();
    }


    private void TakeDamageStart()
    {
        _isAnimationRunning = true;
        _animator.SetTrigger(TakeDamageKey);
        _character.ResetTakeDamage();
    }

    private void StartDead()
    {
        _animator.SetBool(IsDeadKey, true);
    }

}
