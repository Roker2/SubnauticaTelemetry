using HarmonyLib;
using QModManager.API.ModLoading;
using System.Reflection;
using SMLHelper.V2.Handlers;
using SubnauticaTeslasuit.Configuration;
using SubnauticaTeslasuit.Subnautica;
using SubnauticaTeslasuit.Mock;

namespace SubnauticaTeslasuit
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
            dataProcessor.AddForceFeedbackProcessor(new MockForceFeedbackProcessor());
        }
    }
}
