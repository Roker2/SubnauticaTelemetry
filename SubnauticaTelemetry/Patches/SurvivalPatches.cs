using HarmonyLib;
using UnityEngine;

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

        [HarmonyPostfix]
        [HarmonyPatch("Eat")]
        public static void EatPostfix(GameObject useObj)
        {
            if (useObj != null)
            {
                Eatable component = useObj.GetComponent<Eatable>();
                if (component != null)
                {
                    if (component.GetFoodValue() != 0f || component.GetWaterValue() != 0f)
                    {
                        SubnauticaTelemetryPlugin.dataProcessor.ProcessEatAndDrink();
                    }
                }
            }
        }
    }
}
