using UnityEngine;
using UnityEngine.AI;

public class AgentCharacter : MonoBehaviour, IDamagable, IRotatable, IAgentMoveable, ITargetPosition
{
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private DamageAnimationHandler _damageAnimationHandler;
    [SerializeField] private int _maxHealth;

    private CharacterController _characterController;

    private NavMeshAgent _agent;
    private NavMeshPath _path;

    private DirectionalMover _moveDirection;
    private DirectionalRotator _moveRotation;

    private CharacterHealth _health;

    private Vector3 _targetPosition;
    private Vector3 _direction;

    public Vector3 CurrentVelocity => _agent.desiredVelocity;
    public Vector3 Position => transform.position;
    public Vector3 TargetPosition => _targetPosition;

    public int CurrentHealth => _health.CurrentHealth;
    public int MaxHealth => _health.MaxHealth;
    public bool IsTakedDamage => _health.IsTakedDamage;
    public bool IsDead => _health.IsDead;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _characterController = GetComponent<CharacterController>();
        _path = new NavMeshPath();

        _health = new CharacterHealth(_maxHealth);

        _moveDirection = new DirectionalMover(this);
        _moveRotation = new DirectionalRotator(_rotationSpeed, transform);

        _agent.acceleration = 999f;

        _agent.updateRotation = false;
        _agent.updatePosition = false;

        SetCurrentHealth();
    }

    private void Update()
    {
        _agent.SetDestination(_targetPosition);

        if (CanMove() && isAvailablePath(_targetPosition))
        {
            Move();
            Rotate();
            SynchronizePosition(transform);
        }

        if (NavMeshUtils.GetPathLength(_path) < 0.05f)
            StopMove();
        else
            ResumeMove();
    }

    public bool isAvailablePath(Vector3 position)
    {
        _targetPosition = position;

        if (_agent.CalculatePath(position, _path))
            return true;
        else
            return false;
    }

    public bool CanMove() => _damageAnimationHandler.IsAnimationRunning == false;

    public void SetDirection(Vector3 direction) => _direction = direction;
    public void SetRotation(Vector3 direction) => _direction = direction;

    private void Move() => _moveDirection.Move(_direction, _movementSpeed);
    private void Rotate() => _moveRotation.Rotate(_direction);
    public void SynchronizePosition(Transform target) => _agent.nextPosition = target.position;

    public void SetCurrentHealth() => _health.SetCurrentHealth();
    public void TakeDamage(int value) => _health.TakeDamage(value);
    public void ResetTakeDamage() => _health.IsTakedDamage = false;

    public void StopMove() => _agent.isStopped = true;
    public void ResumeMove() => _agent.isStopped = false;
}
