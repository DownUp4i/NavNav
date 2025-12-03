using UnityEngine;

public class DamageAnimationHandler : MonoBehaviour
{
    [SerializeField] private PlayerHealth _playerHealth;

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
        if (_playerHealth.IsTakedDamage == true)
            TakeDamageStart();
        
        if (_playerHealth.IsDead == true)
            StartDead();
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
