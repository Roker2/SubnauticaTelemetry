using HarmonyLib;
using BepInEx;
using SMLHelper.V2.Handlers;
using SubnauticaTelemetry.Configuration;
using SubnauticaTelemetry.Subnautica;
using SubnauticaTelemetry.ForceFeedback;

namespace SubnauticaTelemetry
{
    [BepInPlugin(PluginGUID, PluginName, PluginVersion)]
    public class Main : BaseUnityPlugin
    {
        private const string PluginGUID = "by.roker2.subnauticatelemetrylibrary";
        private const string PluginName = "Subnautica Telemetry Library";
        private const string PluginVersion = "0.1.0";

        internal static Config Config { get; } = OptionsPanelHandler.RegisterModOptions<Config>();

        internal static DataProcessor dataProcessor = new DataProcessor();

        private void Start()
        {
            new Harmony(PluginGUID).PatchAll();
        }

        public static void AddForceFeedbackProcessor(IForceFeedbackProcessor processor)
        {
            dataProcessor.AddForceFeedbackProcessor(processor);
        }
    }
}
