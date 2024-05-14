using System.Collections.Generic;
using HarmonyLib;
using UnityEngine;

namespace FineWoodPieces.Functions;

[HarmonyPatch]
public class Patches
{
    private static readonly List<ZoneSystem.ZoneVegetation> _resourceList = [];
    
    [HarmonyPrefix]
    [HarmonyPatch(typeof(ClayCollector), nameof(ClayCollector.Awake))]
    private static void Awake_Prefix(ref float ___m_secPerUnit, ref int ___m_maxClay, ClayCollector __instance)
    {
        Plugin._secPerUnit.SettingChanged += delegate
        {
            __instance.m_secPerUnit = Plugin._secPerUnit.Value;
        };
        ___m_secPerUnit = Plugin._secPerUnit.Value;
        Plugin._maxClay.SettingChanged += delegate
        {
            __instance.m_maxClay = Plugin._maxClay.Value;
        };
        ___m_maxClay = Plugin._maxClay.Value;
    }

    [HarmonyPostfix]
    [HarmonyPatch(typeof(ClayCollector), nameof(ClayCollector.UpdateEffects))]
    private static void UpdateEffects_Postfix(ClayCollector __instance)
    {
        if (__instance == null || __instance.m_nview == null || !__instance.m_nview.IsValid()) return;
        if (!__instance.gameObject.name.StartsWith("BCP_Clay")) return;
        var anim = Utils.FindChild(__instance.gameObject.transform, "refinery_high");
        var anim2 = Utils.FindChild(__instance.gameObject.transform, "refinery_high_worn");
        var anim3 = Utils.FindChild(__instance.gameObject.transform, "refineryBroken");
        if (__instance.GetStatusText() == __instance.m_collectingText)
        {
            if (anim.gameObject.activeInHierarchy)
            {
                anim.gameObject.GetComponent<Animator>().speed = 1f;
            }
            else if (anim2.gameObject.activeInHierarchy)
            {
                anim2.gameObject.GetComponent<Animator>().speed = 1f;
            }
            else if (anim3.gameObject.activeInHierarchy)
            {
                anim3.gameObject.GetComponent<Animator>().speed = 1f;
            }
        }
        else
        {
            if (anim.gameObject.activeInHierarchy)
            {
                anim.gameObject.GetComponent<Animator>().speed = 0f;
            }
            else if (anim2.gameObject.activeInHierarchy)
            {
                anim2.gameObject.GetComponent<Animator>().speed = 0f;
            }
            else if (anim3.gameObject.activeInHierarchy)
            {
                anim3.gameObject.GetComponent<Animator>().speed = 0f;
            }
        }
    }

    [HarmonyPostfix]
    [HarmonyPatch(typeof(ZNetScene), nameof(ZNetScene.Awake))]
    private static void Awake_Postfix(ZNetScene __instance)
    {
        ComponentsSetup.SetCollector(__instance);
        ComponentsSetup.SetArmorStand(__instance);
        ComponentsSetup.SetClayStand(__instance);
        ComponentsSetup.SetTrapDoor(__instance);
        ComponentsSetup.SetStoneLightPost(__instance);
        ComponentsSetup.SetClayLightPost(__instance);
        ComponentsSetup.SetWoodArmorStand(__instance);
    }
    
    [HarmonyPrefix]
    [HarmonyPatch(typeof(ZoneSystem), nameof(ZoneSystem.ValidateVegetation))]
    private static void ValidateVegetation_Prefix(ZoneSystem __instance)
    {
        foreach (var resource in _resourceList)
        {
            __instance.m_vegetation.Remove(resource);
        }
        _resourceList.Clear();
        var pickable = new ZoneSystem.ZoneVegetation
        {
            m_enable = Plugin._enableClay.Value == Toggle.On,
            m_groupRadius = Plugin._clayGroupRadius.Value,
            m_groupSizeMin = Plugin._clayGroupSizeMin.Value,
            m_groupSizeMax = Plugin._clayGroupSizeMax.Value,
            m_max = Plugin._clayMax.Value,
            m_chanceToUseGroundTilt = 1,
            m_biome = Heightmap.Biome.Meadows | Heightmap.Biome.BlackForest | Heightmap.Biome.Swamp |
                      Heightmap.Biome.Plains | Heightmap.Biome.Mistlands,
            m_minAltitude = -0.5f,
            m_maxAltitude = 2f,
            m_maxTerrainDelta = 2f,
            m_prefab = PrefabsSetup._pickableClay
        };
        _resourceList.Add(pickable);
        var cluster = new ZoneSystem.ZoneVegetation
        {
            m_enable = Plugin._enableClayBig.Value == Toggle.On,
            m_groupRadius = Plugin._clayBigGroupRadius.Value,
            m_groupSizeMin = Plugin._clayBigGroupSizeMin.Value,
            m_groupSizeMax = Plugin._clayBigGroupSizeMax.Value,
            m_max = Plugin._clayBigMax.Value,
            m_chanceToUseGroundTilt = 1,
            m_biome = Heightmap.Biome.Meadows | Heightmap.Biome.BlackForest | Heightmap.Biome.Swamp |
                      Heightmap.Biome.Plains | Heightmap.Biome.Mistlands,
            m_minAltitude = -0.5f,
            m_maxAltitude = 2f,
            m_maxTerrainDelta = 2f,
            m_prefab = PrefabsSetup._clusterClay
        };
        _resourceList.Add(cluster);
        var reed = new ZoneSystem.ZoneVegetation
        {
            m_enable = Plugin._enableReed.Value == Toggle.On,
            m_groupRadius = Plugin._reedGroupRadius.Value,
            m_groupSizeMin = Plugin._reedGroupSizeMin.Value,
            m_groupSizeMax = Plugin._reedGroupSizeMax.Value,
            m_max = Plugin._reedMax.Value,
            m_chanceToUseGroundTilt = 1,
            m_biome = Heightmap.Biome.Meadows | Heightmap.Biome.BlackForest,
            m_minAltitude = -0.6f,
            m_maxAltitude = 1.8f,
            m_maxTerrainDelta = 2f,
            m_prefab = PrefabsSetup._pickableReed
        };
        _resourceList.Add(reed);
        foreach (var item in _resourceList)
        {
            __instance.m_vegetation.Add(item);
        }
    }
}