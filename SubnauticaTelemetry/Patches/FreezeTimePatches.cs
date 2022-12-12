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
            Main.dataProcessor.Running = false;
            Main.dataProcessor.StopAllEvents();
        }

        [HarmonyPostfix]
        [HarmonyPatch("End")]
        public static void EndPostfix()
        {
            Main.dataProcessor.Running = true;
        }
    }
}
