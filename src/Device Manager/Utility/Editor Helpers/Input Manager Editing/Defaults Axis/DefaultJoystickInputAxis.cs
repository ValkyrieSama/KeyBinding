using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValhallaGames.Unity.DeviceDetection.Editor {

    internal static class DefaultJoystickInputAxis {

        internal static InputAxis[] DefaultAxes = {
            Horizontal,
            Vertical,
            Fire1,
            Fire2,
            Fire3,
            Jump,
            Submit,
            Cancel
        };

        internal static InputAxis Horizontal = new InputAxis {
            name = "Horizontal",
            gravity = 0f,
            dead = 0.19f,
            sensitivity = 1f,
            type = AxisType.JoystickAxis,
            axis = 0
        };

        internal static InputAxis Vertical = new InputAxis {
            name = "Vertical",
            gravity = 0f,
            dead = 0.19f,
            sensitivity = 1f,
            invert = true,
            type = AxisType.JoystickAxis,
            axis = 1
        };

        internal static InputAxis Fire1 = new InputAxis {
            name = "Fire1",
            positiveButton = "joystick button 0",
            gravity = 1000f,
            dead = 0.001f,
            sensitivity = 1000f,
            type = AxisType.KeyOrMouseButton
        };

        internal static InputAxis Fire2 = new InputAxis {
            name = "Fire2",
            positiveButton = "joystick button 1",
            gravity = 1000f,
            dead = 0.001f,
            sensitivity = 1000f,
            type = AxisType.KeyOrMouseButton
        };

        internal static InputAxis Fire3 = new InputAxis {
            name = "Fire3",
            positiveButton = "joystick button 2",
            gravity = 1000f,
            dead = 0.001f,
            sensitivity = 1000f,
            type = AxisType.KeyOrMouseButton
        };

        internal static InputAxis Jump = new InputAxis {
            name = "Jump",
            positiveButton = "joystick button 3",
            gravity = 1000f,
            dead = 0.001f,
            sensitivity = 1000f,
            type = AxisType.KeyOrMouseButton
        };

        internal static InputAxis Submit = new InputAxis {
            name = "Submit",
            positiveButton = "return",
            altPositiveButton = "joystick button 0",
            gravity = 1000f,
            dead = 0.001f,
            sensitivity = 1000f,
            type = AxisType.KeyOrMouseButton
        };

        internal static InputAxis Cancel = new InputAxis {
            name = "Cancel",
            positiveButton = "escape",
            altPositiveButton = "joystick button 1",
            gravity = 1000f,
            dead = 0.001f,
            sensitivity = 1000f,
            type = AxisType.KeyOrMouseButton
        };

    }
}
