using System;
using Cinemachine.Utility;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Character : MonoBehaviour, IDamagable
{
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private DamageAnimationHandler _damageAnimationHandler;
    [SerializeField] private int _maxHealth;

    private Camera _camera;

    private AgentController _agentController;
    private MouseController _mouseController;
    private CharacterController _characterController;

    private NavMeshAgent _agent;
    private NavMeshPath _path;

    private MoveDirection _direction;
    private MoveRotation _rotation;

    private CharacterHealth _health;
    private CharacterMovement _characterMovement;

    public Vector3 CurrentVelocity => _agentController.CurrentVelocity;
    public Vector3 MouseHitPoint => _mouseController.HitPoint;
    public bool IsPossibleWay => _agentController.CheckPath(MouseHitPoint, _path);

    public int CurrentHealth => _health.CurrentHealth;
    public int MaxHealth => _health.MaxHealth;
    public bool IsTakedDamage => _health.IsTakedDamage;
    public bool IsDead => _health.IsDead;

    private void Awake()
    {
        _camera = Camera.main;
        _agent = GetComponent<NavMeshAgent>();
        _characterController = GetComponent<CharacterController>();
        _path = new NavMeshPath();

        _health = new CharacterHealth(_maxHealth);
        _direction = new MoveDirection(_movementSpeed, _characterController);
        _rotation = new MoveRotation(_rotationSpeed, transform);
        _characterMovement = new CharacterMovement(_direction, _rotation);

        _agentController = new AgentController(_agent, this);
        _mouseController = new MouseController(_camera);

        SetCurrentHealth();
        _mouseController.OnEnable();
    }

    private void Update()
    {
        _mouseController.Update(Time.deltaTime);

        if (CanMove() && IsPossibleWay)
        {
            SetDirection(_agentController.CurrentVelocity);
            SetRotation(_agentController.CurrentVelocity);
            SynchronizePosition(transform);
        }
    }

    public bool CheckPath() => _agentController.CheckPath(MouseHitPoint, _path);
    public bool CanMove() => _damageAnimationHandler.IsAnimationRunning == false;

    public void SetDirection(Vector3 direction) => _characterMovement.SetDirectionTo(direction);
    public void SetRotation(Vector3 direction) => _characterMovement.SetInputDirection(direction);
    public void SynchronizePosition(Transform target) => _agentController.SynchronizePosition(target);
    public bool IsRightMouseDown() => _mouseController.IsButtonDown;

    public void SetCurrentHealth() => _health.SetCurrentHealth();
    public void TakeDamage(int value) => _health.TakeDamage(value);
    public void ResetTakeDamage() => _health.IsTakedDamage = false;
}
