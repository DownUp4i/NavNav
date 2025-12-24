using UnityEngine;
using UnityEngine.UI;

public class AudioMixerUI : MonoBehaviour
{
    [SerializeField] private AudioMixerHandler _audioHandler;

    [SerializeField] private Button _musicButton;
    [SerializeField] private Button _soundsButton;

    [SerializeField] private Sprite _audioImageOn;
    [SerializeField] private Sprite _audioImageOff;

    private void Update()
    {
        if (_audioHandler.IsMusicOn)
            _musicButton.image.sprite = _audioImageOn;
        else
            _musicButton.image.sprite = _audioImageOff;

        if (_audioHandler.IsSoundsOn)
            _soundsButton.image.sprite = _audioImageOn;
        else
            _soundsButton.image.sprite = _audioImageOff;
    }
}
