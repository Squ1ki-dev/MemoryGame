using System;
using Code.Runtime.Data;
using UnityEngine;
using AudioSettings = Code.Runtime.Data.Settings.AudioSettings;

namespace Code.Runtime.Infrastructure.Services.SaveLoad
{
    internal sealed class SaveLoadService : ISaveLoadService
    {
        private const string AudioSettingsKey = "AudioSettings";

        public event Action Updated;
        public event Action Saved;
        
        public void SaveAudioSettings(AudioSettings audioSettings)
        {
            PlayerPrefs.SetString(AudioSettingsKey, audioSettings.ToJson());
            PlayerPrefs.Save();
        }

        public AudioSettings LoadAudioSettings() =>
            PlayerPrefs.GetString(AudioSettingsKey).ToDeserialized<AudioSettings>()
            ?? new AudioSettings();
    }
}
