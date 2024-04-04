using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


namespace ReducedPower.Patches
{
    internal class PlanterInstancePatch
    {
        [HarmonyPatch(typeof(PlanterInstance), "SimUpdate")]
        [HarmonyPostfix]
        static void reducePower(PlanterInstance __instance) {
            Debug.Log("Setting power to 50");
            __instance.powerInfo.maxPowerConsumption = 50;
        }
    }
}
