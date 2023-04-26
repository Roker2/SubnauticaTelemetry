/*
* This file is part of SubnauticaTelemetry
* Copyright (C) 2023 - Roker2
*
* This program is free software: you can redistribute it and/or modify
* it under the terms of the GNU General Public License as published by
* the Free Software Foundation, either version 3 of the License, or
* (at your option) any later version.
*
* This program is distributed in the hope that it will be useful,
* but WITHOUT ANY WARRANTY; without even the implied warranty of
* MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
* GNU General Public License for more details.
*
* You should have received a copy of the GNU General Public License
* along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

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
