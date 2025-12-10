using UnityEngine;

public class DamageAnimationHandler : MonoBehaviour
{
    [SerializeField] private Character _character;

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
        if (_character.IsTakedDamage == true)
        {
            TakeDamageStart();
        }

        if (_character.IsDead == true)
            StartDead();
    }

    private void LateUpdate()
    {
        _character.ResetTakeDamage();
    }

    public void OnAnimationStart() => _isAnimationRunning = true;
    public void OnAnimationEnd() => _isAnimationRunning = false;


    private void TakeDamageStart()
    {
        _animator.SetTrigger(TakeDamageKey);
    }

    private void StartDead()
    {
        _animator.SetBool(IsDeadKey, true);
    }

}
