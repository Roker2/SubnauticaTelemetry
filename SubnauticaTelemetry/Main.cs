using HarmonyLib;
using QModManager.API.ModLoading;
using System.Reflection;
using SMLHelper.V2.Handlers;
using SubnauticaTelemetry.Configuration;
using SubnauticaTelemetry.Subnautica;
using SubnauticaTelemetry.ForceFeedback;

namespace SubnauticaTelemetry
{
    [QModCore]
    public class Main
    {
        internal static Config Config { get; } = OptionsPanelHandler.RegisterModOptions<Config>();

        internal static DataProcessor dataProcessor = new DataProcessor();

        [QModPatch]
        public static void Load()
        {
            var assembly = Assembly.GetExecutingAssembly();
            new Harmony($"Roker2_{assembly.GetName().Name}").PatchAll(assembly);
        }

        public static void AddForceFeedbackProcessor(IForceFeedbackProcessor processor)
        {
            dataProcessor.AddForceFeedbackProcessor(processor);
        }
    }
}
