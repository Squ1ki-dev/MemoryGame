using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Code.Runtime.Infrastructure.Settings
{
    internal interface ISettingsService
    {
        bool SfxEnabled { get; }
        void TurnOnSfx();
        void TurnOffSfx();
        event Action SfxToggled;
    }
}