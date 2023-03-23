using HarmonyLib;

namespace SubnauticaTelemetry.Patches
{
    [HarmonyPatch(typeof(Player))]
    class PlayerPatches
    {
        [HarmonyPostfix]
        [HarmonyPatch("Update")]
        public static void UpdatePostfix(Player __instance)
        {
            if (Player.MotorMode.Dive == __instance.motorMode)
            {
                float playerDepth = __instance.GetDepth();
                SubnauticaTelemetryPlugin.dataProcessor.ProcessPlayerDepth(playerDepth);
            }

            SubnauticaTelemetryPlugin.dataProcessor.ProcessOxygenLevel(__instance.GetOxygenAvailable());
        }

        [HarmonyPostfix]
        [HarmonyPatch("OnTakeDamage")]
        public static void OnTakeDamagePostfix(Player __instance, DamageInfo damageInfo)
        {
            SubnauticaTelemetryPlugin.dataProcessor.ProcessDamage(damageInfo);
        }
    }
}
