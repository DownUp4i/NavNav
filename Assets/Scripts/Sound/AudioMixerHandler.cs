using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioMixerHandler : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioMixer;

    private const float OffVolumeValue = -80f;
    private const float OnVolumeValue = 0f;

    private const string MusicKey = "MusicVolume";
    private const string SoundsKey = "SoundsVolume";

    private bool _isMusicOn;
    private bool _isSoundsOn;

    public bool IsMusicOn => _isMusicOn;
    public bool IsSoundsOn => _isSoundsOn;

    private void Awake ()
    {
        _isMusicOn = true;
        _isSoundsOn = true;
    }

    private bool IsVolumeOn(string key) => _audioMixer.GetFloat(key, out float volume) && Mathf.Abs(volume - OnVolumeValue) <= 0.01f;

    private void OnVolume(string key) => _audioMixer.SetFloat(key, OnVolumeValue);
    private void OffVolume(string key) => _audioMixer.SetFloat(key, OffVolumeValue);

    public void SwitchMusicVolume()
    {
        if (IsVolumeOn(MusicKey))
        {
            _isMusicOn = false;
            OffVolume(MusicKey);
        }
        else
        {
            _isMusicOn = true;
            OnVolume(MusicKey);
        }
    }

    public void SwitchSoundsVolume()
    {
        if (IsVolumeOn(SoundsKey))
        {
            _isSoundsOn = false;
            OffVolume(SoundsKey);
        }
        else
        {
            _isSoundsOn = true;
            OnVolume(SoundsKey);
        }
    }
}
