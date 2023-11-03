using System;
using MelonLoader;

namespace MediaPlayer.Melon
{
    internal static class ModConsole
    {
        private static MelonLogger.Instance logger;


        public static void Setup(MelonLogger.Instance loggerInstance)
        {
            logger = loggerInstance;
        }

        public static void Msg(object obj, LoggingMode loggingMode = LoggingMode.NORMAL)
        {
            var msg = loggingMode == LoggingMode.DEBUG ? $"[DEBUG] {obj}" : obj.ToString();
            var txtcolor = loggingMode == LoggingMode.DEBUG ? ConsoleColor.Yellow : ConsoleColor.Gray;
            if (Preferences.LoggingMode >= loggingMode)
                logger.Msg(txtcolor, msg);
        }

        public static void Msg(string txt, LoggingMode loggingMode = LoggingMode.NORMAL)
        {
            var msg = loggingMode == LoggingMode.DEBUG ? $"[DEBUG] {txt}" : txt;
            var txtcolor = loggingMode == LoggingMode.DEBUG ? ConsoleColor.Yellow : ConsoleColor.Gray;
            if (Preferences.LoggingMode >= loggingMode)
                logger.Msg(txtcolor, msg);
        }

        public static void Msg(ConsoleColor txtcolor, object obj, LoggingMode loggingMode = LoggingMode.NORMAL)
        {
            var msg = loggingMode == LoggingMode.DEBUG ? $"[DEBUG] {obj}" : obj.ToString();
            if (Preferences.LoggingMode >= loggingMode)
                logger.Msg(txtcolor, msg);
        }

        public static void Msg(ConsoleColor txtcolor, string txt, LoggingMode loggingMode = LoggingMode.NORMAL)
        {
            var msg = loggingMode == LoggingMode.DEBUG ? $"[DEBUG] {txt}" : txt;
            if (Preferences.LoggingMode >= loggingMode)
                logger.Msg(txtcolor, msg);
        }

        public static void Msg(string txt, LoggingMode loggingMode = LoggingMode.NORMAL, params object[] args)
        {
            var msg = loggingMode == LoggingMode.DEBUG ? $"[DEBUG] {txt}" : txt;
            var txtcolor = loggingMode == LoggingMode.DEBUG ? ConsoleColor.Yellow : ConsoleColor.Gray;
            if (Preferences.LoggingMode >= loggingMode)
                logger.Msg(txtcolor, msg, args);
        }

        public static void Msg(ConsoleColor txtcolor, string txt, LoggingMode loggingMode = LoggingMode.NORMAL, params object[] args)
        {
            var msg = loggingMode == LoggingMode.DEBUG ? $"[DEBUG] {txt}" : txt;
            if (Preferences.LoggingMode >= loggingMode)
                logger.Msg(txtcolor, msg, args);
        }

        public static void Error(object obj, LoggingMode loggingMode = LoggingMode.NORMAL)
        {
            var msg = loggingMode == LoggingMode.DEBUG ? $"[DEBUG] {obj}" : obj.ToString();
            if (Preferences.LoggingMode >= loggingMode)
                logger.Error(msg);
        }

        public static void Error(string txt, LoggingMode loggingMode = LoggingMode.NORMAL)
        {
            var msg = loggingMode == LoggingMode.DEBUG ? $"[DEBUG] {txt}" : txt;
            if (Preferences.LoggingMode >= loggingMode)
                logger.Error(msg);
        }

        public static void Error(string txt, LoggingMode loggingMode = LoggingMode.NORMAL, params object[] args)
        {
            var msg = loggingMode == LoggingMode.DEBUG ? $"[DEBUG] {txt}" : txt;
            if (Preferences.LoggingMode >= loggingMode)
                logger.Error(msg, args);
        }

        public static void Warning(object obj, LoggingMode loggingMode = LoggingMode.NORMAL)
        {
            var msg = loggingMode == LoggingMode.DEBUG ? $"[DEBUG] {obj}" : obj.ToString();
            if (Preferences.LoggingMode >= loggingMode)
                logger.Warning(msg);
        }

        public static void Warning(string txt, LoggingMode loggingMode = LoggingMode.NORMAL)
        {
            var msg = loggingMode == LoggingMode.DEBUG ? $"[DEBUG] {txt}" : txt;
            if (Preferences.LoggingMode >= loggingMode)
                logger.Warning(msg);
        }

        public static void Warning(string txt, LoggingMode loggingMode = LoggingMode.NORMAL, params object[] args)
        {
            var msg = loggingMode == LoggingMode.DEBUG ? $"[DEBUG] {txt}" : txt;
            if (Preferences.LoggingMode >= loggingMode)
                logger.Warning(msg, args);
        }
    }
}

internal enum LoggingMode
{
    NORMAL,
    DEBUG
}