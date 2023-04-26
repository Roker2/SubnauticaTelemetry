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
