using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _rotationSpeed;

    private CharacterController _characterController;
    private Camera _camera;

    private NavMeshAgent _agent;
    private NavMeshPath _navMeshPath;

    private InputController _mouseController;
    private InputController _inputPosition;

    private MoveDirection _direction;
    private MoveRotation _rotation;

    private IControllable _controllable;

    private float _pathLength;
    private bool _isPossibleWay;

    public Vector3 CurrentVelocity => _agent.desiredVelocity;
    public bool IsPossibleWay => _isPossibleWay;

    private void Awake()
    {
        _navMeshPath = new NavMeshPath();
        _agent = GetComponent<NavMeshAgent>();
        _characterController = GetComponent<CharacterController>();
        _camera = Camera.main;

        _controllable = new AgentController(_agent);

        _direction = new MoveDirection(_movementSpeed, _characterController);
        _rotation = new MoveRotation(_rotationSpeed, transform);

        _mouseController = new InputMouseController(_camera, _controllable);
        _inputPosition = new InputMousePositionController();
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

        if (_agent.CalculatePath(_inputPosition.GetDirection, _navMeshPath))
            _isPossibleWay = true;
        else
            _isPossibleWay = false;

        if (_isPossibleWay)
        {
            _rotation.SetInputDirection(_agent.desiredVelocity);
            _direction.DirectionTo(_agent.desiredVelocity);
            _agent.nextPosition = transform.position;
        }

        if (NavMeshUtils.GetPathLength(_navMeshPath) < 0.1f)
            _controllable.StopMove();
        else
            _controllable.ResumeMove();
    }
}
