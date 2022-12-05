using HarmonyLib;

namespace SubnauticaTeslasuit.Patches
{
    [HarmonyPatch(typeof(Player), nameof(Player.Update))]
    class PlayerUpdatePatch
    {
        [HarmonyPostfix]
        public static void Postfix()
        {
            float playerDepth = Ocean.main.GetDepthOf(Player.main.gameObject);
        }
    }
}
