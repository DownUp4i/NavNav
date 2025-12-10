using UnityEngine;
using UnityEngine.AI;

public class InputExample : MonoBehaviour
{
    [SerializeField] private Character _character;

    private Controller _controller;

    private void Awake()
    {
        _controller = new AgentController(_character.GetComponent<NavMeshAgent>(), _character);
        _controller.OnEnable();
    }

    private void Update()
    {
        _controller.Update(Time.deltaTime);
    }
}
