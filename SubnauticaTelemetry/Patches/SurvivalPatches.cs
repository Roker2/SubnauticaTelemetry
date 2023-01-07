using HarmonyLib;

namespace SubnauticaTelemetry.Patches
{
    [HarmonyPatch(typeof(Survival))]
    internal class SurvivalPatches
    {
        /*[HarmonyPostfix]
        [HarmonyPatch("UpdateWarningSounds")]
        public static void UpdateWarningSoundsPostfix([HarmonyArgument(1)] float statVal, [HarmonyArgument(2)] float prevStatVal,
            [HarmonyArgument(3)] float lowThreshold, [HarmonyArgument(4)] float criticalThreshold)
        {
            int warningLevel = -1;
            if (statVal <= 0f && prevStatVal > 0f)
            {
                warningLevel = 2;
            }
            else if (statVal < criticalThreshold && prevStatVal >= criticalThreshold)
            {
                warningLevel = 1;
            }
            else if (statVal < lowThreshold && prevStatVal >= lowThreshold)
            {
                warningLevel = 0;
            }
            if (warningLevel == -1)
                return;

        }*/
        private static float prevFoodVal;
        private static float prevWaterVal;

        [HarmonyPrefix]
        [HarmonyPatch("UpdateStats")]
        public static void UpdateStatsPrefix(Survival __instance)
        {
            prevFoodVal = __instance.food;
            prevWaterVal = __instance.water;
        }

        [HarmonyPostfix]
        [HarmonyPatch("UpdateStats")]
        public static void UpdateStatsPostfix(Survival __instance, [HarmonyArgument(0)] float timePassed)
        {
            if (timePassed > 1E-45f)
            {
                Main.dataProcessor.ProcessFoodLevel(__instance.food, prevFoodVal);
                Main.dataProcessor.ProcessWaterLevel(__instance.water, prevWaterVal);
            }
        }
    }
}
