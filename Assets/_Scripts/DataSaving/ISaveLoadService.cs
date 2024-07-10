using System;
using Code.Runtime.Data.Settings;

namespace Code.Runtime.Infrastructure.Services.SaveLoad
{
    internal interface ISaveLoadService
    {
        event Action Updated;
        event Action Saved;
        void SaveAudioSettings(AudioSettings audioSettings);
        AudioSettings LoadAudioSettings();
    }
}