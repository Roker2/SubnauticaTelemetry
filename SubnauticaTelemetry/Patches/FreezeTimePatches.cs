using HarmonyLib;
using UWE;

namespace SubnauticaTelemetry.Patches
{
    [HarmonyPatch(typeof(FreezeTime))]
    internal class FreezeTimePatches
    {
        [HarmonyPostfix]
        [HarmonyPatch("Begin")]
        public static void BeginPostfix()
        {
            SubnauticaTelemetryPlugin.dataProcessor.Running = false;
            SubnauticaTelemetryPlugin.dataProcessor.StopAllEvents();
        }

        [HarmonyPostfix]
        [HarmonyPatch("End")]
        public static void EndPostfix()
        {
            SubnauticaTelemetryPlugin.dataProcessor.Running = true;
        }
    }
}
