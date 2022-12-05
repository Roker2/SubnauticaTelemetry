using HarmonyLib;
using QModManager.API.ModLoading;
using System.Reflection;

namespace SubnauticaTeslasuit
{
    [QModCore]
    public class Main
    {
        [QModPatch]
        public static void Load()
        {
            var assembly = Assembly.GetExecutingAssembly();
            new Harmony($"Roker2_{assembly.GetName().Name}").PatchAll(assembly);
        }
    }
}
