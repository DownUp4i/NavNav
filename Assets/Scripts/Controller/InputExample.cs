using UnityEngine;
using UnityEngine.AI;

public class InputExample : MonoBehaviour
{
    [SerializeField] private Character _character;
    private IMoveable _moveable;
    private IRotatable _rotatable;

    private AgentController _agentController;
    private MouseController _mouseController;

    public bool IsRightMouseDown => _mouseController.IsButtonDown;

    private void Awake()
    {
        _moveable = _character.GetComponent<IMoveable>();
        _rotatable = _character.GetComponent<IRotatable>();

        _mouseController = new MouseController(Camera.main);
        _mouseController.OnEnable();

        _agentController = new AgentController(_character.GetComponent<NavMeshAgent>(), _character);
        _agentController.OnEnable();
    }

    private void Update()
    {
        _mouseController.Update(Time.deltaTime);
        _agentController.Update(Time.deltaTime);

        _character.IsPossibleWay(_mouseController.GetPosition());

        _moveable.SetDirection(_agentController.CurrentVelocity);
        _rotatable.SetRotation(_agentController.CurrentVelocity);
    }
}
