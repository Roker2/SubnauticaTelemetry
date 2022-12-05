using HarmonyLib;
using QModManager.API.ModLoading;
using System.Reflection;
using SMLHelper.V2.Handlers;
using SubnauticaTeslasuit.Configuration;

namespace SubnauticaTeslasuit
{
    [QModCore]
    public class Main
    {
        internal static Config Config { get; } = OptionsPanelHandler.RegisterModOptions<Config>();

        [QModPatch]
        public static void Load()
        {
            var assembly = Assembly.GetExecutingAssembly();
            new Harmony($"Roker2_{assembly.GetName().Name}").PatchAll(assembly);
        }
    }
}
