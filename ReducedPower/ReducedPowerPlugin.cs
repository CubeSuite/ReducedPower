using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using EquinoxsModUtils;
using HarmonyLib;
using ReducedPower.Patches;
using System;
using UnityEngine;

namespace ReducedPower
{
    [BepInPlugin(MyGUID, PluginName, VersionString)]
    public class ReducedPowerPlugin : BaseUnityPlugin
    {
        private const string MyGUID = "com.equinox.ReducedPower";
        private const string PluginName = "ReducedPower";
        private const string VersionString = "1.0.0";

        private static readonly Harmony Harmony = new Harmony(MyGUID);
        public static ManualLogSource Log = new ManualLogSource(PluginName);

        private void Awake() {
            Logger.LogInfo($"PluginName: {PluginName}, VersionString: {VersionString} is loading...");
            Harmony.PatchAll();

            ModUtils.GameDefinesLoaded += OnGameDefinesLoaded;

            Logger.LogInfo($"PluginName: {PluginName}, VersionString: {VersionString} is loaded.");
            Log = Logger;
        }

        private void OnGameDefinesLoaded(object sender, EventArgs e) {
            BuilderInfo planterInfo = (BuilderInfo)ModUtils.GetResourceInfoByName(ResourceNames.Planter);
            planterInfo.kWPowerConsumption = 12;

            BuilderInfo thresherInfo = (BuilderInfo)ModUtils.GetResourceInfoByName(ResourceNames.Thresher);
            thresherInfo.kWPowerConsumption = 50;
        }
    }
}
