using UnityEngine;
using UnityEngine.AI;

public class Character : MonoBehaviour, IDamagable, IRotatable, IMoveable
{
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private DamageAnimationHandler _damageAnimationHandler;
    [SerializeField] private int _maxHealth;

    private CharacterController _characterController;

    private NavMeshAgent _agent;
    private NavMeshPath _path;

    private MoveDirection _moveDirection;
    private MoveRotation _moveRotation;

    private CharacterHealth _health;

    private Vector3 _targetPosition;
    private Vector3 _direction;

    public Vector3 CurrentVelocity => _agent.desiredVelocity;

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

        _moveDirection = new MoveDirection(this);
        _moveRotation = new MoveRotation(this);

        SetCurrentHealth();
    }

    private void Update()
    {
        if (CanMove() && IsPossibleWay(_targetPosition))
        {
            Move();
            Rotate();
            SynchronizePosition(transform);
        }
    }

    public bool IsPossibleWay(Vector3 position)
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
    private void Rotate() => _moveRotation.SetRotation(_direction.normalized, _rotationSpeed, transform);

    public void SynchronizePosition(Transform target) => _agent.nextPosition = target.position;

    public void SetCurrentHealth() => _health.SetCurrentHealth();
    public void TakeDamage(int value) => _health.TakeDamage(value);
    public void ResetTakeDamage() => _health.IsTakedDamage = false;
}
