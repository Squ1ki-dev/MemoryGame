using System.Collections.Generic;
using UnityEngine;

namespace Code.Runtime.Infrastructure.Services.SaveLoad
{
    public interface ISaveLoadRegistry
    {
        void RegisterAllComponents(GameObject gameObject);
        void UnregisterAllComponents(GameObject gameObject);
    }
}
