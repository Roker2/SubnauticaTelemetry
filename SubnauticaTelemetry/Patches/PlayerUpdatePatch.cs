using HarmonyLib;
using UnityEngine;

namespace SubnauticaTelemetry.Patches
{
    [HarmonyPatch(typeof(Player), nameof(Player.Update))]
    class PlayerUpdatePatch
    {
        [HarmonyPostfix]
        public static void Postfix(Player __instance)
        {
            if (Player.MotorMode.Dive == __instance.motorMode)
            {
                float playerDepth = Ocean.main.GetDepthOf(Player.main.gameObject);
                Main.dataProcessor.ProcessPlayerDepth(playerDepth);
            }

            Main.dataProcessor.ProcessOxygenLevel(__instance.GetOxygenAvailable());
        }
    }
}
