using UnityEngine;

public class DirectionalMover 
{
    private AgentCharacter _character;
    private CharacterController _controller;

    public DirectionalMover(AgentCharacter character)
    {
        _character = character;
        _controller = _character.GetComponent<CharacterController>();
    }

    public void Move(Vector3 input, float speed)
    {
        _controller.Move(input.normalized * speed * Time.deltaTime);
    }
}
