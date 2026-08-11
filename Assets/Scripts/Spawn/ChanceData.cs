using System;
using UnityEngine;

namespace Spawn
{
    [Serializable]
    internal struct ChanceData
    {
        [Min(0)] public int LeftState;
        [Min(0)] public int RightState;
        [Range(0f, 1f)] public float Value;
    }
}