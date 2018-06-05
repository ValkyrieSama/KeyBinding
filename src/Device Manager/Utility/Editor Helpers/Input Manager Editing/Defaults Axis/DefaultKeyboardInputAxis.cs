using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValhallaGames.Unity.DeviceDetection.Editor {

    internal static class DefaultKeyboardInputAxis {

        internal static InputAxis[] DefaultAxes = {
            Horizontal,
            Vertical,
            Fire1,
            Fire2,
            Fire3,
            Jump,
            Submit
        };

        internal static InputAxis Horizontal = new InputAxis {
            name = "Horizontal",
            negativeButton = "left",
            positiveButton = "right",
            altNegativeButton = "a",
            altPositiveButton = "d",
            gravity = 3f,
            dead = 0.001f,
            sensitivity = 3f,
            snap = true,
            type = AxisType.KeyOrMouseButton
        };

        internal static InputAxis Vertical = new InputAxis {
            name = "Vertical",
            negativeButton = "down",
            positiveButton = "up",
            altNegativeButton = "w",
            altPositiveButton = "s",
            gravity = 3f,
            dead = 0.001f,
            sensitivity = 3f,
            snap = true,
            type = AxisType.KeyOrMouseButton
        };

        internal static InputAxis Fire1 = new InputAxis {
            name = "Fire1",
            positiveButton = "left ctrl",
            altPositiveButton = "mouse 0",
            gravity = 1000f,
            dead = 0.001f,
            sensitivity = 1000f,
            type = AxisType.KeyOrMouseButton
        };

        internal static InputAxis Fire2 = new InputAxis {
            name = "Fire2",
            positiveButton = "left alt",
            altPositiveButton = "mouse 1",
            gravity = 1000f,
            dead = 0.001f,
            sensitivity = 1000f,
            type = AxisType.KeyOrMouseButton
        };

        internal static InputAxis Fire3 = new InputAxis {
            name = "Fire3",
            positiveButton = "left shift",
            altPositiveButton = "mouse 2",
            gravity = 1000f,
            dead = 0.001f,
            sensitivity = 1000f,
            type = AxisType.KeyOrMouseButton
        };

        internal static InputAxis Jump = new InputAxis {
            name = "Jump",
            positiveButton = "space",
            gravity = 1000f,
            dead = 0.001f,
            sensitivity = 1000f,
            type = AxisType.KeyOrMouseButton
        };

        internal static InputAxis Submit = new InputAxis {
            name = "Submit",
            positiveButton = "enter",
            altPositiveButton = "space",
            gravity = 1000f,
            dead = 0.001f,
            sensitivity = 1000f,
            type = AxisType.KeyOrMouseButton
        };
    }
}
