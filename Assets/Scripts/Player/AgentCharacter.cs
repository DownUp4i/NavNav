using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GridBrushBase;

public class AgentCharacter : MonoBehaviour, IDamagable, IRotatable, IAgentMoveable, ITargetPosition, IHealable, IJumpable
{
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _jumpSpeed;

    [SerializeField] private DamageAnimationHandler _damageAnimationHandler;
    [SerializeField] private int _maxHealth;
    [SerializeField] private AnimationCurve _jumpCurve;

    private CharacterController _characterController;

    private NavMeshAgent _agent;
    private NavMeshPath _path;

    private DirectionalMover _mover;
    private DirectionalRotator _rotator;
    private AgentJumpHandler _agentJumpHandler;

    private CharacterHealth _health;

    private Vector3 _targetPosition;

    private Vector3 _moveDirection;
    private Vector3 _rotationDirection;

    public bool InJumpProcess => _agentJumpHandler.InProcess;

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

        _mover = new DirectionalMover(this);
        _rotator = new DirectionalRotator(_rotationSpeed, transform);
        _agentJumpHandler = new AgentJumpHandler(_jumpSpeed, _agent, this, _jumpCurve);

        _agent.acceleration = 999f;

        _agent.updateRotation = false;
        _agent.updatePosition = false;

        SetCurrentHealth(_maxHealth);
    }

    private void Update()
    {
        Debug.Log(IsTakedDamage + " IsTakedDamage");

        if (IsDead || CanMove() == false) return;

        if (NavMeshUtils.GetPathLength(_path) < 0.05f)
            StopMove();
        else
            ResumeMove();

        if (CanMove() && isAvailablePath(_targetPosition))
        {
            _agent.SetDestination(_targetPosition);
            Move();
            Rotate();

            if (IsOnNavMeshLink(out OffMeshLinkData offMeshLinkData))
                Jump(offMeshLinkData);
        }
    }

    private void LateUpdate()
    {
        SynchronizePosition(transform);
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

    public void SetDirection(Vector3 direction) => _moveDirection = direction;
    public void SetRotation(Vector3 direction) => _rotationDirection = direction;

    private void Move() => _mover.Move(_moveDirection, _movementSpeed);
    private void Rotate() => _rotator.Rotate(_rotationDirection);
    public void SynchronizePosition(Transform target) => _agent.nextPosition = target.position;

    public void SetCurrentHealth(int value) => _health.SetCurrentHealth(value);
    public void TakeDamage(int value) => _health.TakeDamage(value);
    public void Heal(int value) => _health.Heal(value);
    public void ResetTakeDamage() => _health.ResetTakeDamage();

    public void StopMove() => _agent.isStopped = true;
    public void ResumeMove() => _agent.isStopped = false;

    public void Jump(OffMeshLinkData offMeshLinkData) => _agentJumpHandler.Update(offMeshLinkData);

    public bool IsOnNavMeshLink(out OffMeshLinkData offMeshLinkData)
    {
        if (_agent.isOnOffMeshLink)
        {
            offMeshLinkData = _agent.currentOffMeshLinkData;
            return true;
        }

        offMeshLinkData = default(OffMeshLinkData);
        return false;
    }
}
