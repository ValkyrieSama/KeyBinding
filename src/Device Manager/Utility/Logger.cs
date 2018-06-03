namespace ValhallaGames.Unity.DeviceDetection {

    public class Logger {
        
        public delegate void LogMessageHandler(LogMessage message);

        public static event LogMessageHandler OnLogMessage;

        public static void LogInfo(string text) {
            if (OnLogMessage == null) return;
            OnLogMessage(new LogMessage { Text = text, Type = LogMessageType.Info });
        }

        public static void LogWarning(string text) {
            if (OnLogMessage == null) return;
            OnLogMessage(new LogMessage { Text = text, Type = LogMessageType.Warning });
        }

        public static void LogError(string text) {
            if (OnLogMessage == null) return;
            OnLogMessage(new LogMessage { Text = text, Type = LogMessageType.Error });
        }

    }

    public struct LogMessage {

        public string Text;
        public LogMessageType Type;

    }

    public enum LogMessageType {
        Info,
        Warning,
        Error
    }

}