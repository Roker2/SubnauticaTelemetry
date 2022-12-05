using HarmonyLib;
using System.IO;
using UnityEngine;

namespace SubnauticaTeslasuit.Patches
{
    [HarmonyPatch(typeof(Player), nameof(Player.Update))]
    class PlayerUpdatePatch
    {
        [HarmonyPostfix]
        public static void Postfix(Player __instance)
        {
            if (Player.MotorMode.Dive == __instance.motorMode)
            {
                float playerDepth = Ocean.main.GetDepthOf(Player.main.gameObject);
                using (StreamWriter writetext = new StreamWriter("log.txt", true))
                {
                    writetext.WriteLine(playerDepth.ToString());
                }
            }
            else
            {
                using (StreamWriter writetext = new StreamWriter("log.txt", true))
                {
                    writetext.WriteLine("player is not in water");
                }
            }
        }
    }
}
