using HarmonyLib;
using UnityEngine;

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
                Main.dataProcessor.ProcessPlayerDepth(playerDepth);
            }

            Main.dataProcessor.ProcessOxygenLevel(__instance.GetOxygenAvailable());
        }
    }
}
