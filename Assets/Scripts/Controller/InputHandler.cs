using UnityEngine;
using UnityEngine.AI;

public class InputHandler : MonoBehaviour
{
    [SerializeField] private AgentCharacter _character;

    private AgentController _agentController;
    private MouseController _mouseController;

    public bool IsRightMouseDown => _mouseController.IsButtonDown;

    private void Awake()
    {
        _mouseController = new MouseController(Camera.main);
        _mouseController.OnEnable();

        _agentController = new AgentController(_character.GetComponent<NavMeshAgent>(),_character, _character, _character, _character);
        _agentController.OnEnable();
    }

    private void Update()
    {
        _mouseController.Update(Time.deltaTime);
        _agentController.Update(Time.deltaTime);

        _character.isAvailablePath(_mouseController.GetPosition());
    }
}
