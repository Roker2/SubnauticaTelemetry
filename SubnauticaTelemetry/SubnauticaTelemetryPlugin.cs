using HarmonyLib;
using BepInEx;
using SMLHelper.V2.Handlers;
using SubnauticaTelemetry.Configuration;
using SubnauticaTelemetry.Subnautica;
using SubnauticaTelemetry.ForceFeedback;

namespace SubnauticaTelemetry
{
    [BepInPlugin(PluginGUID, PluginName, PluginVersion)]
    public class SubnauticaTelemetryPlugin : BaseUnityPlugin
    {
        private const string PluginGUID = "by.roker2.subnauticatelemetrylibrary";
        private const string PluginName = "Subnautica Telemetry Library";
        private const string PluginVersion = "1.0.0";

        internal static Config Config { get; } = OptionsPanelHandler.RegisterModOptions<Config>();

        internal static DataProcessor dataProcessor = new DataProcessor();

        private void Start()
        {
            new Harmony(PluginGUID).PatchAll();
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
