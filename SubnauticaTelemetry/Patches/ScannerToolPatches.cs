using HarmonyLib;

namespace SubnauticaTelemetry.Patches
{
    [HarmonyPatch(typeof(ScannerTool))]
    internal class ScannerToolPatches
    {
        private static bool isPlayerBeingScanned = false;

        [HarmonyPostfix]
        [HarmonyPatch("Scan")]
        public static void ScanPostfix(ScannerTool __instance, PDAScanner.Result __result)
        {
            PDAScanner.ScanTarget scanTarget = PDAScanner.scanTarget;
            if (!scanTarget.isValid)
                return;
            if (scanTarget.isPlayer && __result == PDAScanner.Result.Scan)
            {
                SubnauticaTelemetryPlugin.dataProcessor.ProcessSelfScanning();
            }
        }
    }
}
