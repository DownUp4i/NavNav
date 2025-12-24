using System.Collections;
using UnityEngine;

public class AudioMovementHandler : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSourceMovementFirst;
    [SerializeField] private AudioSource _audioSourceMovementSecond;
    [SerializeField] private AudioSource _audioSourceJump;
    [SerializeField] private AudioClip _clip;
    [SerializeField] private AgentCharacter _character;
    private readonly float TimeBetweenPlay = 0.5f;

    private Coroutine _audioMovementCoroutine;
    private Coroutine _audioJumpCoroutine;

    private void Update()
    {
        if (_character.InJumpProcess)
        {
            if (_audioJumpCoroutine == null)
            {
                _audioJumpCoroutine = StartCoroutine(AudioJumpProcess());
            }
        }
        else
        {
            if (_audioJumpCoroutine != null)
            {
                StopCoroutine(_audioJumpCoroutine);
                _audioJumpCoroutine = null;
            }
        }

        if (_character.CurrentVelocity.magnitude > 0.05f && _character.InJumpProcess == false)
        {
            if (_audioMovementCoroutine == null)
            {
                _audioMovementCoroutine = StartCoroutine(AudioMovementProcess());
            }
        }
        else
        {
            if (_audioMovementCoroutine != null)
            {
                StopCoroutine(_audioMovementCoroutine);
                _audioMovementCoroutine = null;
            }
        }



    }

    private IEnumerator AudioJumpProcess()
    {
        _audioSourceJump.PlayOneShot(_clip);

        yield return null;
    }

    private IEnumerator AudioMovementProcess()
    {
        while (true)
        {
            _audioSourceMovementFirst.Play();

            yield return new WaitForSeconds(TimeBetweenPlay);

            _audioSourceMovementSecond.Play();

            yield return new WaitForSeconds(TimeBetweenPlay);
        }
    }
}
