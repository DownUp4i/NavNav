using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private DamageAnimationHandler _damageAnimationHandler;

    private CharacterController _characterController;
    private PlayerHealth _playerHealth;
    private Camera _camera;

    private NavMeshAgent _agent;
    private NavMeshPath _navMeshPath;

    private Controller _mouseController;
    private Controller _inputPosition;

    private MoveDirection _direction;
    private MoveRotation _rotation;

    private IControllable _controllable;
    private IInputController _inputController;

    private float _pathLength;
    private bool _isPossibleWay;

    public Vector3 CurrentVelocity => _agent.desiredVelocity;
    public bool IsPossibleWay => _isPossibleWay;

    private void Awake()
    {
        _navMeshPath = new NavMeshPath();
        _agent = GetComponent<NavMeshAgent>();
        _playerHealth = GetComponent<PlayerHealth>();
        _characterController = GetComponent<CharacterController>();
        _camera = Camera.main;

        _controllable = new AgentController(_agent);
        _inputController = new InputRightMouseController();

        _direction = new MoveDirection(_movementSpeed, _characterController);
        _rotation = new MoveRotation(_rotationSpeed, transform);

        _mouseController = new MouseController(_camera, _controllable, _inputController);
        _inputPosition = new MousePositionController(_inputController);
    }

    private void Start()
    {
        _agent.acceleration = 999f;

        _agent.updateRotation = false;
        _agent.updatePosition = false;
    }

    private void Update()
    {
        _mouseController.UpdateLogic(Time.deltaTime);
        _inputPosition.UpdateLogic(Time.deltaTime);

        if (_agent.CalculatePath(_inputPosition.Direction, _navMeshPath))
            if (_playerHealth.IsDead == true || _damageAnimationHandler.IsAnimationRunning == true)
                _isPossibleWay = false;
            else
                _isPossibleWay = true;

        if (_isPossibleWay)
        {
            _rotation.SetInputDirection(_agent.desiredVelocity);
            _direction.DirectionTo(_agent.desiredVelocity);
            _agent.nextPosition = transform.position;
        }

        if (NavMeshUtils.GetPathLength(_navMeshPath) < 0.05f)
            _controllable.StopMove();
        else
            _controllable.ResumeMove();
    }
}
