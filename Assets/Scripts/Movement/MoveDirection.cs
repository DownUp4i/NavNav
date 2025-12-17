using UnityEngine;

public class MoveDirection 
{
    private Character _character;
    private CharacterController _controller;

    public MoveDirection(Character character)
    {
        _character = character;
        _controller = _character.GetComponent<CharacterController>();
    }

    public void Move(Vector3 input, float speed)
    {
        _controller.Move(input.normalized * speed * Time.deltaTime);
    }
}
