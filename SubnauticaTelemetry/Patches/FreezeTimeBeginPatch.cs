using HarmonyLib;
using UWE;

namespace SubnauticaTelemetry.Patches
{
    [HarmonyPatch(typeof(FreezeTime), nameof(FreezeTime.Begin))]
    class FreezeTimeBeginPatch
    {
        [HarmonyPostfix]
        public static void Postfix()
        {
            Main.dataProcessor.running = false;
            Main.dataProcessor.StopAllEvents();
        }
    }
}
