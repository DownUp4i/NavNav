using System.Collections.Generic;
using UnityEngine;

public class AudioInteractHandler : MonoBehaviour
{
    [SerializeField] private AudioClip _clip;
    [SerializeField] private Transform _followTarget;
    [SerializeField] private List<Bomb> _bombs = new List<Bomb>();
    [SerializeField] private AudioSource _audioSourceBomb;

    private void Update()
    {
        foreach (Bomb bomb in _bombs)
        {
            if (bomb != null && bomb.SoundPlayed)
            {
                _audioSourceBomb.PlayOneShot(_clip);
            }
        }
    }
}
