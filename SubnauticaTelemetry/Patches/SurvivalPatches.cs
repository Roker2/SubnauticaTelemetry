using HarmonyLib;

namespace SubnauticaTelemetry.Patches
{
    [HarmonyPatch(typeof(Survival))]
    internal class SurvivalPatches
    {
        [HarmonyPostfix]
        [HarmonyPatch("UpdateHunger")]
        public static void UpdateHungerPostfix(Survival __instance)
        {
            if (GameModeUtils.RequiresSurvival() && !__instance.freezeStats)
            {
                SubnauticaTelemetryPlugin.dataProcessor.ProcessFoodLevel(__instance.food);
                SubnauticaTelemetryPlugin.dataProcessor.ProcessWaterLevel(__instance.water);
            }
        }
    }
}
