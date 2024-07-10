using Code.Runtime.Infrastructure.Settings;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource _sfxSource;
    private ISettingsService _settingsService;

    [Inject]
    private void Construct(ISettingsService settingsService) => _settingsService = settingsService;
    private void Awake()
    {
        _settingsService.SfxToggled += UpdateSfxState;
    }

    public void PlaySfx(AudioClip clip)
    {
        if(!_settingsService.SfxEnabled)
            return;
            
        _sfxSource.PlayOneShot(clip);
    }

    public void StopSfx() => _sfxSource.Stop();

    private void UpdateSfxState()
    {
        if (!_settingsService.SfxEnabled)
            StopSfx();
    }
}
