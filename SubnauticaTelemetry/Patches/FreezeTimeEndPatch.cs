using HarmonyLib;
using UWE;

namespace SubnauticaTelemetry.Patches
{
    [HarmonyPatch(typeof(FreezeTime), nameof(FreezeTime.End))]
    class FreezeTimeEndPatch
    {
        [HarmonyPostfix]
        public static void Postfix()
        {
            Main.dataProcessor.Running = true;
        }
    }
}
