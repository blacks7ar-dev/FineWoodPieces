using BepInEx.Logging;

namespace FineWoodPieces.Functions;

public static class Logging
{
    private static readonly ManualLogSource FLogger = Logger.CreateLogSource(Plugin.modName);

    public static void LogDebug(string debug)
    {
        FLogger.LogDebug(debug);
    }

    public static void LogInfo(string info)
    {
        FLogger.LogInfo(info);
    }

    public static void LogWarning(string warning)
    {
        FLogger.LogWarning(warning);
    }

    public static void LogError(string error)
    {
        FLogger.LogError(error);
    }
}