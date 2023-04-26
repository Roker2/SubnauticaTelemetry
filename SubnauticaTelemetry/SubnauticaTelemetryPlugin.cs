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
using BepInEx;
using SMLHelper.V2.Handlers;
using SubnauticaTelemetry.Configuration;
using SubnauticaTelemetry.Subnautica;
using SubnauticaTelemetry.ForceFeedback;
using BepInEx.Logging;

namespace SubnauticaTelemetry
{
    [BepInPlugin(PluginGUID, PluginName, PluginVersion)]
    public class SubnauticaTelemetryPlugin : BaseUnityPlugin
    {
        private const string PluginGUID = "by.roker2.subnauticatelemetrylibrary";
        private const string PluginName = "Subnautica Telemetry Library";
        private const string PluginVersion = "1.0.2";

        internal static ManualLogSource Log;

        internal static Config Config { get; } = OptionsPanelHandler.RegisterModOptions<Config>();

        internal static DataProcessor dataProcessor = new DataProcessor();

        private void Start()
        {
            new Harmony(PluginGUID).PatchAll();
            Log = Logger;
        }

        /// <summary>
        /// Add FF processor for receiving FF events 
        /// </summary>
        /// <param name="processor"></param>
        public static void AddForceFeedbackProcessor(IForceFeedbackProcessor processor)
        {
            dataProcessor.AddForceFeedbackProcessor(processor);
        }
    }
}
