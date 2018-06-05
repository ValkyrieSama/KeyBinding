using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValhallaGames.Unity.DeviceDetection.Editor {

    internal static class DefaultMouseInputAxis {

        internal static InputAxis[] DefaultAxes = {
            MouseX,
            MouseY,
            MouseScrollWheel
        };

        internal static InputAxis MouseX = new InputAxis {
            name = "Mouse X",
            gravity = 0f,
            dead = 0f,
            sensitivity = 0.1f,
            type = AxisType.MouseMovement,
            axis = 0
        };

        internal static InputAxis MouseY = new InputAxis {
            name = "Mouse Y",
            gravity = 0f,
            dead = 0f,
            sensitivity = 0.1f,
            type = AxisType.MouseMovement,
            axis = 1
        };

        internal static InputAxis MouseScrollWheel = new InputAxis {
            name = "Mouse ScrollWheel",
            gravity = 0f,
            dead = 0f,
            sensitivity = 0.1f,
            type = AxisType.MouseMovement,
            axis = 3
        };
    }
}
