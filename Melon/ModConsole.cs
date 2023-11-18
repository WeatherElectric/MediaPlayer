namespace MediaPlayer.Melon;

internal static class ModConsole
{
    private static MelonLogger.Instance _logger;
    public static void Setup(MelonLogger.Instance loggerInstance)
    {
        _logger = loggerInstance;
    }
        
    #region Msg
    public static void Msg(object obj, int loggingMode = 0)
    {
        var msg = loggingMode == 1 ? $"[DEBUG] {obj}" : obj.ToString();
        var txtcolor = loggingMode == 1 ? ConsoleColor.Yellow : ConsoleColor.Gray;
        if (Preferences.loggingMode.Value >= loggingMode)
            _logger.Msg(txtcolor, msg);
    }
        
    public static void Msg(string txt, int loggingMode = 0)
    {
        var msg = loggingMode == 1 ? $"[DEBUG] {txt}" : txt;
        var txtcolor = loggingMode == 1 ? ConsoleColor.Yellow : ConsoleColor.Gray;
        if (Preferences.loggingMode.Value >= loggingMode)
            _logger.Msg(txtcolor, msg);
    }
        
    public static void Msg(ConsoleColor txtcolor, object obj, int loggingMode = 0)
    {
        var msg = loggingMode == 1 ? $"[DEBUG] {obj}" : obj.ToString();
        if (Preferences.loggingMode.Value >= loggingMode)
            _logger.Msg(txtcolor, msg);
    }
        
    public static void Msg(ConsoleColor txtcolor, string txt, int loggingMode = 0)
    {
        var msg = loggingMode == 1 ? $"[DEBUG] {txt}" : txt;
        if (Preferences.loggingMode.Value >= loggingMode)
            _logger.Msg(txtcolor, msg);
    }

    public static void Msg(string txt, int loggingMode = 0, params object[] args)
    {
        var msg = loggingMode == 1 ? $"[DEBUG] {txt}" : txt;
        var txtcolor = loggingMode == 1 ? ConsoleColor.Yellow : ConsoleColor.Gray;
        if (Preferences.loggingMode.Value >= loggingMode)
            _logger.Msg(txtcolor, msg, args);
    }

    public static void Msg(ConsoleColor txtcolor, string txt, int loggingMode = 0, params object[] args)
    {
        var msg = loggingMode == 1 ? $"[DEBUG] {txt}" : txt;
        if (Preferences.loggingMode.Value >= loggingMode)
            _logger.Msg(txtcolor, msg, args);
    }
    #endregion
    #region Error
    public static void Error(object obj, int loggingMode = 0)
    {
        var msg = loggingMode == 1 ? $"[DEBUG] {obj}" : obj.ToString();
        if (Preferences.loggingMode.Value >= loggingMode)
            _logger.Error(msg);
    }

    public static void Error(string txt, int loggingMode = 0)
    {
        var msg = loggingMode == 1 ? $"[DEBUG] {txt}" : txt;
        if (Preferences.loggingMode.Value >= loggingMode)
            _logger.Error(msg);
    }

    public static void Error(string txt, int loggingMode = 0, params object[] args)
    {
        var msg = loggingMode == 1 ? $"[DEBUG] {txt}" : txt;
        if (Preferences.loggingMode.Value >= loggingMode)
            _logger.Error(msg, args);
    }
    #endregion
    #region Warning
    public static void Warning(object obj, int loggingMode = 0)
    {
        var msg = loggingMode == 1 ? $"[DEBUG] {obj}" : obj.ToString();
        if (Preferences.loggingMode.Value >= loggingMode)
            _logger.Warning(msg);
    }

    public static void Warning(string txt, int loggingMode = 0)
    {
        var msg = loggingMode == 1 ? $"[DEBUG] {txt}" : txt;
        if (Preferences.loggingMode.Value >= loggingMode)
            _logger.Warning(msg);
    }

    public static void Warning(string txt, int loggingMode = 0, params object[] args)
    {
        var msg = loggingMode == 1 ? $"[DEBUG] {txt}" : txt;
        if (Preferences.loggingMode.Value >= loggingMode)
            _logger.Warning(msg, args);
    }
    #endregion
}