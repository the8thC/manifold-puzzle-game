using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class CommonSceneData {
    public static bool SwitchingLevels = false;
    public static TimeSpan PreviousPlaytime;
    public static Vector2 PlayerRotation;

    public static bool LoadingGame = false;
    public static Vector3 PlayerPosition;
}
