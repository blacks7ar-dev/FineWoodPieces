using ClayBuildPieces.Functions;
using UnityEngine;

namespace FineWoodPieces.Functions;

public static class ComponentsSetup
{
    public static void SetCollector(ZNetScene zNetScene)
    {
        if (!Helper.ZNetSceneAwake()) return;
        var component = zNetScene.GetPrefab("BCP_ClayCollector").GetComponent<ClayCollector>();
        component.m_name = "$bcp_claycollector";
        component.m_spawnPoint = Utils.FindChild(component.gameObject.transform, "spawnpoint");
        component.m_secPerUnit = Plugin._secPerUnit.Value;
        component.m_maxClay = Plugin._maxClay.Value;
        component.m_clayItem = zNetScene.GetPrefab("BFP_Clay").GetComponent<ItemDrop>();
        component.m_spawnEffect.m_effectPrefabs =
        [
            new EffectList.EffectData
            {
                m_prefab = PrefabsSetup._fineWoodBundle.LoadAsset<GameObject>("bfp_sfx_pickable_pick"),
                m_enabled = true,
                m_variant = -1
            },
            new EffectList.EffectData
            {
                m_prefab = PrefabsSetup._fineWoodBundle.LoadAsset<GameObject>("bfp_vfx_pickable_pick"),
                m_enabled = true,
                m_variant = -1
            }
        ];
        component.m_enabledObject = Utils.FindChild(component.gameObject.transform, "_enabled").gameObject;
        component.m_biome = Heightmap.Biome.Meadows | Heightmap.Biome.BlackForest | Heightmap.Biome.Swamp | Heightmap.Biome.Plains;
    }
    
    public static void SetClayStand(ZNetScene zNetScene)
    {
        if (!Helper.ZNetSceneAwake()) return;
        var component = zNetScene.GetPrefab("BFP_ClayArmorStand").GetComponent<ArmorStand>();
        component.m_supports =
        [
            new ArmorStand.ArmorStandSupport
            {
                m_items =
                [
                    zNetScene.GetPrefab("ArmorBronzeChest").GetComponent<ItemDrop>(),
                    zNetScene.GetPrefab("ArmorIronChest").GetComponent<ItemDrop>(),
                    zNetScene.GetPrefab("ArmorCarapaceChest").GetComponent<ItemDrop>(),
                    zNetScene.GetPrefab("ArmorMageChest").GetComponent<ItemDrop>()
                ],
                m_supports =
                [
                    Utils.FindChild(component.gameObject.transform, "ArmLeft").gameObject,
                    Utils.FindChild(component.gameObject.transform, "ArmRight").gameObject
                ]
            }
        ];
    }
    
    public static void SetClayLightPost(ZNetScene zNetScene)
    {
        if (!Helper.ZNetSceneAwake()) return;
        var component = zNetScene.GetPrefab("BFP_ClayLightPost").GetComponent<Fireplace>();
        component.m_fuelItem = zNetScene.GetPrefab("Coal").GetComponent<ItemDrop>();
        component.m_fireworkItemList =
        [
            new Fireplace.FireworkItem
            {
                m_fireworkItemCount = 1,
                m_fireworkItem = zNetScene.GetPrefab("Resin").GetComponent<ItemDrop>(),
                m_fireworksEffects = new EffectList
                {
                    m_effectPrefabs =
                    [
                        new EffectList.EffectData
                        {
                            m_prefab = zNetScene.GetPrefab("vfx_Firework_Rocket")
                        }
                    ]
                }
            }
        ];
    }
    
    public static void SetStoneLightPost(ZNetScene zNetScene)
    {
        if (!Helper.ZNetSceneAwake()) return;
        var firePlace = zNetScene.GetPrefab("BFP_StoneLightPost").GetComponent<Fireplace>();
        firePlace.m_fuelItem = zNetScene.GetPrefab("Coal").GetComponent<ItemDrop>();
        firePlace.m_fireworkItemList =
        [
            new Fireplace.FireworkItem
            {
                m_fireworkItemCount = 1,
                m_fireworkItem = zNetScene.GetPrefab("Resin").GetComponent<ItemDrop>(),
                m_fireworksEffects = new EffectList
                {
                    m_effectPrefabs =
                    [
                        new EffectList.EffectData
                        {
                            m_prefab = zNetScene.GetPrefab("vfx_Firework_Rocket")
                        }
                    ]
                }
            }
        ];
    }
    
    public static void SetTrapDoor(ZNetScene zNetScene)
    {
        if (!Helper.ZNetSceneAwake()) return;
        var trapDoor = zNetScene.GetPrefab("BFP_TrapDoor").GetComponent<TrapDoor>();
        trapDoor.m_name = "$bfp_trapdoor";
        trapDoor.m_checkGuardStone = true;
        trapDoor.m_openEffects.m_effectPrefabs =
        [
            new EffectList.EffectData
            {
                m_prefab = PrefabsSetup._fineWoodBundle.LoadAsset<GameObject>("bfp_sfx_door_open"),
                m_enabled = true,
                m_variant = -1
            }
        ];
        trapDoor.m_closeEffects.m_effectPrefabs =
        [
            new EffectList.EffectData
            {
                m_prefab = PrefabsSetup._fineWoodBundle.LoadAsset<GameObject>("bfp_sfx_door_close"),
                m_enabled = true,
                m_variant = -1
            }
        ];
    }
    
    public static void SetArmorStand(ZNetScene zNetScene)
    {
        if (!Helper.ZNetSceneAwake()) return;
        var armorStand = zNetScene.GetPrefab("BFP_ArmorStand").GetComponent<ArmorStand>();
        armorStand.m_supports =
        [
            new ArmorStand.ArmorStandSupport
            {
                m_items =
                [
                    zNetScene.GetPrefab("ArmorBronzeChest").GetComponent<ItemDrop>(),
                    zNetScene.GetPrefab("ArmorIronChest").GetComponent<ItemDrop>(),
                    zNetScene.GetPrefab("ArmorCarapaceChest").GetComponent<ItemDrop>(),
                    zNetScene.GetPrefab("ArmorMageChest").GetComponent<ItemDrop>()
                ],
                m_supports =
                [
                    Utils.FindChild(armorStand.gameObject.transform, "ArmLeft").gameObject,
                    Utils.FindChild(armorStand.gameObject.transform, "ArmRight").gameObject
                ]
            }
        ];
    }
    
    public static void SetWoodArmorStand(ZNetScene zNetScene)
    {
        if (!Helper.ZNetSceneAwake()) return;
        var armorStand = zNetScene.GetPrefab("BFP_WoodenArmorStand").GetComponent<ArmorStand>();
        armorStand.m_supports =
        [
            new ArmorStand.ArmorStandSupport
            {
                m_items =
                [
                    zNetScene.GetPrefab("ArmorBronzeChest").GetComponent<ItemDrop>(),
                    zNetScene.GetPrefab("ArmorIronChest").GetComponent<ItemDrop>(),
                    zNetScene.GetPrefab("ArmorCarapaceChest").GetComponent<ItemDrop>(),
                    zNetScene.GetPrefab("ArmorMageChest").GetComponent<ItemDrop>()
                ],
                m_supports =
                [
                    Utils.FindChild(armorStand.gameObject.transform, "ArmLeft").gameObject,
                    Utils.FindChild(armorStand.gameObject.transform, "ArmRight").gameObject
                ]
            }
        ];
    }
}