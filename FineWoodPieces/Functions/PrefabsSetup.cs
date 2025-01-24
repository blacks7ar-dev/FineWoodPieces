using ItemManager;
using PieceManager;
using UnityEngine;
using CraftingTable = PieceManager.CraftingTable;

namespace FineWoodPieces.Functions;

public static class PrefabsSetup
{
    public static AssetBundle _fineWoodBundle;
    private const string _clayMat = "BFP_Clay";
    private const string _customHammer = "BFP_FineHammer";
    private const string _strawMat = "BFP_Straw";
    private const string _fineWoodMat = "FineWood";
    private const string _bronzeNailsMat = "BronzeNails";
    private const string _beechMat = "BeechSeeds";
    public static GameObject _pickableClay;
    public static GameObject _clusterClay;
    // public static GameObject _clayPit1;
    // public static GameObject _clayPit2;
    public static GameObject _pickableReed;

    public static void Init()
    {
        _fineWoodBundle = PiecePrefabManager.RegisterAssetBundle("finewoodbundle");
        Others();
        HardPieces();
        Misc();
        Furniture();
        WoodPieces();
        Effects();
    }

    private static void Others()
    {
        Item item = new(_fineWoodBundle, "BFP_FineHammer");
        item.Crafting.Add(ItemManager.CraftingTable.Forge, 1);
        item.RequiredItems.Add("Bronze", 2);
        item.RequiredItems.Add("RoundLog", 1);
        item.RequiredUpgradeItems.Add("Bronze", 1);
        item.RequiredUpgradeItems.Add("RoundLog", 1);
        item.Configurable = Configurability.Full;

        Item item2 = new(_fineWoodBundle, "BFP_Clay")
        {
            Configurable = Configurability.Disabled
        };
        ShaderReplacer.Replace(item2.Prefab);

        Item item3 = new(_fineWoodBundle, "BFP_Straw")
        {
            Configurable = Configurability.Disabled
        };
        ShaderReplacer.Replace(item3.Prefab);

        BuildPiece piece = new(_fineWoodBundle, "BFP_FineHammerRepair");
        piece.Crafting.Set(CraftingTable.None);
        piece.Category.Set(BuildPieceCategory.All);
        piece.Tool.Add(_customHammer);
        piece.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = true };

        BuildPiece piece2 = new(_fineWoodBundle, "BCP_ClayCollector");
        piece2.Crafting.Set(CraftingTable.Workbench);
        piece2.Category.Set("CollectorSeries");
        piece2.RequiredItems.Add("SurtlingCore", 5, true);
        piece2.RequiredItems.Add("Bronze", 12, true);
        piece2.RequiredItems.Add("RoundLog", 15, true);
        piece2.RequiredItems.Add("Stone", 22, true);
        piece.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        if (!piece2.Prefab.GetComponent<ClayCollector>())
        {
            piece2.Prefab.AddComponent<ClayCollector>();
        }
        ShaderReplacer.Replace(piece2.Prefab);

        _pickableClay = PiecePrefabManager.RegisterPrefab(_fineWoodBundle, "BFP_Pickable_Clay");
        ShaderReplacer.Replace(_pickableClay);
        _clusterClay = PiecePrefabManager.RegisterPrefab(_fineWoodBundle, "BFP_Pickable_ClayBig");
        ShaderReplacer.Replace(_clusterClay);
        _pickableReed = PiecePrefabManager.RegisterPrefab(_fineWoodBundle, "BFP_Pickable_Reed");
        ShaderReplacer.Replace(_pickableReed);
        // _clayPit1 = PiecePrefabManager.RegisterPrefab(_fineWoodBundle, "BCP_ClayPit");
        // ShaderReplacer.Replace(_clayPit1);
        // _clayPit2 = PiecePrefabManager.RegisterPrefab(_fineWoodBundle, "BCP_ClayPit1");
        // ShaderReplacer.Replace(_clayPit2);
    }

    private static void Furniture()
    {
        BuildPiece piece = new(_fineWoodBundle, "BFP_ArmorStand");
        piece.Crafting.Set(CraftingTable.Workbench);
        piece.Category.Set(BuildPieceCategory.Furniture);
        piece.Tool.Add(_customHammer);
        piece.RequiredItems.Add(_fineWoodMat, 12, true);
        piece.RequiredItems.Add(_bronzeNailsMat, 6, true);
        piece.RequiredItems.Add("LeatherScraps", 4, true);
        piece.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece.Prefab);

        BuildPiece piece2 = new(_fineWoodBundle, "BFP_Bench1");
        piece2.Crafting.Set(CraftingTable.Workbench);
        piece2.Category.Set(BuildPieceCategory.Furniture);
        piece2.Tool.Add(_customHammer);
        piece2.RequiredItems.Add(_fineWoodMat, 16, true);
        piece2.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece2.Prefab);

        BuildPiece piece3 = new(_fineWoodBundle, "BFP_Bench2");
        piece3.Crafting.Set(CraftingTable.Workbench);
        piece3.Category.Set(BuildPieceCategory.Furniture);
        piece3.Tool.Add(_customHammer);
        piece3.RequiredItems.Add(_fineWoodMat, 24, true);
        piece3.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece3.Prefab);

        BuildPiece piece4 = new(_fineWoodBundle, "BFP_Bench3");
        piece4.Crafting.Set(CraftingTable.Workbench);
        piece4.Category.Set(BuildPieceCategory.Furniture);
        piece4.Tool.Add(_customHammer);
        piece4.RequiredItems.Add(_fineWoodMat, 12, true);
        piece4.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece4.Prefab);

        BuildPiece piece5 = new(_fineWoodBundle, "BFP_Bench4");
        piece5.Crafting.Set(CraftingTable.Workbench);
        piece5.Category.Set(BuildPieceCategory.Furniture);
        piece5.Tool.Add(_customHammer);
        piece5.RequiredItems.Add("Stone", 24, true);
        piece5.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece5.Prefab);

        BuildPiece piece6 = new(_fineWoodBundle, "BFP_Bench5");
        piece6.Crafting.Set(CraftingTable.Workbench);
        piece6.Category.Set(BuildPieceCategory.Furniture);
        piece6.Tool.Add(_customHammer);
        piece6.RequiredItems.Add(_fineWoodMat, 12, true);
        piece6.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece6.Prefab);

        BuildPiece piece7 = new(_fineWoodBundle, "BFP_Bench6");
        piece7.Crafting.Set(CraftingTable.Workbench);
        piece7.Category.Set(BuildPieceCategory.Furniture);
        piece7.Tool.Add(_customHammer);
        piece7.RequiredItems.Add(_fineWoodMat, 18, true);
        piece7.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece7.Prefab);

        BuildPiece piece8 = new(_fineWoodBundle, "BFP_Bench7");
        piece8.Crafting.Set(CraftingTable.Workbench);
        piece8.Category.Set(BuildPieceCategory.Furniture);
        piece8.Tool.Add(_customHammer);
        piece8.RequiredItems.Add(_fineWoodMat, 8, true);
        piece8.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece8.Prefab);

        BuildPiece piece9 = new(_fineWoodBundle, "BFP_Bench8");
        piece9.Crafting.Set(CraftingTable.Workbench);
        piece9.Category.Set(BuildPieceCategory.Furniture);
        piece9.Tool.Add(_customHammer);
        piece9.RequiredItems.Add(_fineWoodMat, 6, true);
        piece9.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece9.Prefab);

        BuildPiece piece10 = new(_fineWoodBundle, "BFP_Bench9");
        piece10.Crafting.Set(CraftingTable.Workbench);
        piece10.Category.Set(BuildPieceCategory.Furniture);
        piece10.Tool.Add(_customHammer);
        piece10.RequiredItems.Add(_fineWoodMat, 12, true);
        piece10.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece10.Prefab);

        BuildPiece piece11 = new(_fineWoodBundle, "BFP_BronzeFrameChest");
        piece11.Crafting.Set(CraftingTable.Workbench);
        piece11.Category.Set(BuildPieceCategory.Furniture);
        piece11.Tool.Add(_customHammer);
        piece11.RequiredItems.Add(_fineWoodMat, 8, true);
        piece11.RequiredItems.Add("Bronze", 4, true);
        piece11.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece11.Prefab);

        BuildPiece piece12 = new(_fineWoodBundle, "BFP_Cabinet1");
        piece12.Crafting.Set(CraftingTable.Workbench);
        piece12.Category.Set(BuildPieceCategory.Furniture);
        piece12.Tool.Add(_customHammer);
        piece12.RequiredItems.Add(_fineWoodMat, 42, true);
        piece12.RequiredItems.Add(_bronzeNailsMat, 12, true);
        piece12.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece12.Prefab);

        BuildPiece piece13 = new(_fineWoodBundle, "BFP_Cabinet2");
        piece13.Crafting.Set(CraftingTable.Workbench);
        piece13.Category.Set(BuildPieceCategory.Furniture);
        piece13.Tool.Add(_customHammer);
        piece13.RequiredItems.Add(_fineWoodMat, 42, true);
        piece13.RequiredItems.Add(_bronzeNailsMat, 12, true);
        piece13.RequiredItems.Add("Crystal", 2, true);
        piece13.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece13.Prefab);

        BuildPiece piece14 = new(_fineWoodBundle, "BFP_Cabinet3");
        piece14.Crafting.Set(CraftingTable.Workbench);
        piece14.Category.Set(BuildPieceCategory.Furniture);
        piece14.Tool.Add(_customHammer);
        piece14.RequiredItems.Add(_fineWoodMat, 21, true);
        piece14.RequiredItems.Add(_bronzeNailsMat, 6, true);
        piece14.RequiredItems.Add("Crystal", 1, true);
        piece14.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece14.Prefab);

        BuildPiece piece15 = new(_fineWoodBundle, "BFP_Cabinet4");
        piece15.Crafting.Set(CraftingTable.Workbench);
        piece15.Category.Set(BuildPieceCategory.Furniture);
        piece15.Tool.Add(_customHammer);
        piece15.RequiredItems.Add(_fineWoodMat, 36, true);
        piece15.RequiredItems.Add(_bronzeNailsMat, 16, true);
        piece15.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece15.Prefab);

        BuildPiece piece16 = new(_fineWoodBundle, "BFP_Cabinet5");
        piece16.Crafting.Set(CraftingTable.Workbench);
        piece16.Category.Set(BuildPieceCategory.Furniture);
        piece16.Tool.Add(_customHammer);
        piece16.RequiredItems.Add(_fineWoodMat, 36, true);
        piece16.RequiredItems.Add(_bronzeNailsMat, 16, true);
        piece16.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece16.Prefab);

        BuildPiece piece17 = new(_fineWoodBundle, "BFP_Cabinet7");
        piece17.Crafting.Set(CraftingTable.Workbench);
        piece17.Category.Set(BuildPieceCategory.Furniture);
        piece17.Tool.Add(_customHammer);
        piece17.RequiredItems.Add(_fineWoodMat, 16, true);
        piece17.RequiredItems.Add(_bronzeNailsMat, 8, true);
        piece17.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece17.Prefab);

        BuildPiece piece18 = new(_fineWoodBundle, "BFP_ClayArmorStand");
        piece18.Crafting.Set(CraftingTable.Workbench);
        piece18.Category.Set(BuildPieceCategory.Furniture);
        piece18.Tool.Add(_customHammer);
        piece18.RequiredItems.Add(_clayMat, 24, true);
        piece18.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece18.Prefab);

        BuildPiece piece19 = new(_fineWoodBundle, "BFP_ClayChest");
        piece19.Crafting.Set(CraftingTable.Workbench);
        piece19.Category.Set(BuildPieceCategory.Furniture);
        piece19.Tool.Add(_customHammer);
        piece19.RequiredItems.Add(_clayMat, 10, true);
        piece19.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece19.Prefab);

        BuildPiece piece20 = new(_fineWoodBundle, "BFP_Cupboard");
        piece20.Crafting.Set(CraftingTable.Workbench);
        piece20.Category.Set(BuildPieceCategory.Furniture);
        piece20.Tool.Add(_customHammer);
        piece20.RequiredItems.Add(_fineWoodMat, 12, true);
        piece20.RequiredItems.Add("RoundLog", 2, true);
        piece20.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece20.Prefab);

        BuildPiece piece21 = new(_fineWoodBundle, "BFP_FineWoodBasket");
        piece21.Crafting.Set(CraftingTable.Workbench);
        piece21.Category.Set(BuildPieceCategory.Furniture);
        piece21.Tool.Add(_customHammer);
        piece21.RequiredItems.Add(_fineWoodMat, 4, true);
        piece21.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };

        BuildPiece piece22 = new(_fineWoodBundle, "BFP_FineWoodBed1");
        piece22.Crafting.Set(CraftingTable.Workbench);
        piece22.Category.Set(BuildPieceCategory.Furniture);
        piece22.Tool.Add(_customHammer);
        piece22.RequiredItems.Add(_fineWoodMat, 12, true);
        piece22.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece22.Prefab);

        BuildPiece piece23 = new(_fineWoodBundle, "BFP_FineWoodBed2");
        piece23.Crafting.Set(CraftingTable.Workbench);
        piece23.Category.Set(BuildPieceCategory.Furniture);
        piece23.Tool.Add(_customHammer);
        piece23.RequiredItems.Add(_fineWoodMat, 18, true);
        piece23.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece23.Prefab);

        BuildPiece piece24 = new(_fineWoodBundle, "BFP_FineWoodChair1");
        piece24.Crafting.Set(CraftingTable.Workbench);
        piece24.Category.Set(BuildPieceCategory.Furniture);
        piece24.Tool.Add(_customHammer);
        piece24.RequiredItems.Add(_fineWoodMat, 8, true);
        piece24.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece24.Prefab);

        BuildPiece piece25 = new(_fineWoodBundle, "BFP_FineWoodChair2");
        piece25.Crafting.Set(CraftingTable.Workbench);
        piece25.Category.Set(BuildPieceCategory.Furniture);
        piece25.Tool.Add(_customHammer);
        piece25.RequiredItems.Add(_fineWoodMat, 8, true);
        piece25.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece25.Prefab);

        BuildPiece piece26 = new(_fineWoodBundle, "BFP_FineWoodChair3");
        piece26.Crafting.Set(CraftingTable.Workbench);
        piece26.Category.Set(BuildPieceCategory.Furniture);
        piece26.Tool.Add(_customHammer);
        piece26.RequiredItems.Add(_fineWoodMat, 8, true);
        piece26.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece26.Prefab);

        BuildPiece piece27 = new(_fineWoodBundle, "BFP_FineWoodChair4");
        piece27.Crafting.Set(CraftingTable.Workbench);
        piece27.Category.Set(BuildPieceCategory.Furniture);
        piece27.Tool.Tools.Add(_customHammer);
        piece27.RequiredItems.Add(_fineWoodMat, 8, true);
        piece27.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece27.Prefab);

        BuildPiece piece28 = new(_fineWoodBundle, "BFP_FineWoodChair5");
        piece28.Crafting.Set(CraftingTable.Workbench);
        piece28.Category.Set(BuildPieceCategory.Furniture);
        piece28.Tool.Add(_customHammer);
        piece28.RequiredItems.Add(_fineWoodMat, 8, true);
        piece28.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece28.Prefab);

        BuildPiece piece29 = new(_fineWoodBundle, "BFP_FineWoodChair6");
        piece29.Crafting.Set(CraftingTable.Workbench);
        piece29.Category.Set(BuildPieceCategory.Furniture);
        piece29.Tool.Add(_customHammer);
        piece29.RequiredItems.Add(_fineWoodMat, 14, true);
        piece29.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece29.Prefab);

        BuildPiece piece30 = new(_fineWoodBundle, "BFP_FineWoodChair7");
        piece30.Crafting.Set(CraftingTable.Workbench);
        piece30.Category.Set(BuildPieceCategory.Furniture);
        piece30.Tool.Add(_customHammer);
        piece30.RequiredItems.Add(_fineWoodMat, 14, true);
        piece30.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece30.Prefab);

        BuildPiece piece31 = new(_fineWoodBundle, "BFP_FineWoodDrawer1");
        piece31.Crafting.Set(CraftingTable.Workbench);
        piece31.Category.Set(BuildPieceCategory.Furniture);
        piece31.Tool.Add(_customHammer);
        piece31.RequiredItems.Add(_fineWoodMat, 22, true);
        piece31.RequiredItems.Add(_bronzeNailsMat, 8, true);
        piece31.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece31.Prefab);

        BuildPiece piece32 = new(_fineWoodBundle, "BFP_FineWoodDrawer2");
        piece32.Crafting.Set(CraftingTable.Workbench);
        piece32.Category.Set(BuildPieceCategory.Furniture);
        piece32.Tool.Add(_customHammer);
        piece32.RequiredItems.Add(_fineWoodMat, 22, true);
        piece32.RequiredItems.Add(_bronzeNailsMat, 8, true);
        piece32.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece32.Prefab);

        BuildPiece piece33 = new(_fineWoodBundle, "BFP_FineWoodDrawer3");
        piece33.Crafting.Set(CraftingTable.Workbench);
        piece33.Category.Set(BuildPieceCategory.Furniture);
        piece33.Tool.Add(_customHammer);
        piece33.RequiredItems.Add(_fineWoodMat, 22, true);
        piece33.RequiredItems.Add(_bronzeNailsMat, 8, true);
        piece33.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece33.Prefab);

        BuildPiece piece34 = new(_fineWoodBundle, "BFP_FineWoodDrawer4");
        piece34.Crafting.Set(CraftingTable.Workbench);
        piece34.Category.Set(BuildPieceCategory.Furniture);
        piece34.Tool.Add(_customHammer);
        piece34.RequiredItems.Add(_fineWoodMat, 22, true);
        piece34.RequiredItems.Add(_bronzeNailsMat, 8, true);
        piece34.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece34.Prefab);

        BuildPiece piece35 = new(_fineWoodBundle, "BFP_FineWoodDrawer5");
        piece35.Crafting.Set(CraftingTable.Workbench);
        piece35.Category.Set(BuildPieceCategory.Furniture);
        piece35.Tool.Add(_customHammer);
        piece35.RequiredItems.Add(_fineWoodMat, 22, true);
        piece35.RequiredItems.Add(_bronzeNailsMat, 8, true);
        piece35.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece35.Prefab);

        BuildPiece piece36 = new(_fineWoodBundle, "BFP_FineWoodStool");
        piece36.Crafting.Set(CraftingTable.Workbench);
        piece36.Category.Set(BuildPieceCategory.Furniture);
        piece36.Tool.Add(_customHammer);
        piece36.RequiredItems.Add(_fineWoodMat, 6, true);
        piece36.RequiredItems.Add(_bronzeNailsMat, 4, true);
        piece36.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece36.Prefab);

        BuildPiece piece37 = new(_fineWoodBundle, "BFP_FineWoodTable1");
        piece37.Crafting.Set(CraftingTable.Workbench);
        piece37.Category.Set(BuildPieceCategory.Furniture);
        piece37.Tool.Add(_customHammer);
        piece37.RequiredItems.Add(_fineWoodMat, 14, true);
        piece37.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece37.Prefab);

        BuildPiece piece38 = new(_fineWoodBundle, "BFP_FineWoodTable2");
        piece38.Crafting.Set(CraftingTable.Workbench);
        piece38.Category.Set(BuildPieceCategory.Furniture);
        piece38.Tool.Add(_customHammer);
        piece38.RequiredItems.Add(_fineWoodMat, 14, true);
        piece38.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece38.Prefab);

        BuildPiece piece39 = new(_fineWoodBundle, "BFP_FineWoodTable3");
        piece39.Crafting.Set(CraftingTable.Workbench);
        piece39.Category.Set(BuildPieceCategory.Furniture);
        piece39.Tool.Add(_customHammer);
        piece39.RequiredItems.Add(_fineWoodMat, 14, true);
        piece39.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece39.Prefab);

        BuildPiece piece40 = new(_fineWoodBundle, "BFP_FineWoodTable4");
        piece40.Crafting.Set(CraftingTable.Workbench);
        piece40.Category.Set(BuildPieceCategory.Furniture);
        piece40.Tool.Add(_customHammer);
        piece40.RequiredItems.Add(_fineWoodMat, 14, true);
        piece40.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece40.Prefab);

        BuildPiece piece41 = new(_fineWoodBundle, "BFP_FineWoodTable5");
        piece41.Crafting.Set(CraftingTable.Workbench);
        piece41.Category.Set(BuildPieceCategory.Furniture);
        piece41.Tool.Add(_customHammer);
        piece41.RequiredItems.Add(_fineWoodMat, 14, true);
        piece41.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece41.Prefab);

        BuildPiece piece42 = new(_fineWoodBundle, "BFP_FineWoodTable6");
        piece42.Crafting.Set(CraftingTable.Workbench);
        piece42.Category.Set(BuildPieceCategory.Furniture);
        piece42.Tool.Add(_customHammer);
        piece42.RequiredItems.Add(_fineWoodMat, 14, true);
        piece42.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece42.Prefab);

        BuildPiece piece43 = new(_fineWoodBundle, "BFP_FineWoodTable7");
        piece43.Crafting.Set(CraftingTable.Workbench);
        piece43.Category.Set(BuildPieceCategory.Furniture);
        piece43.Tool.Add(_customHammer);
        piece43.RequiredItems.Add(_fineWoodMat, 14, true);
        piece43.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece43.Prefab);

        BuildPiece piece44 = new(_fineWoodBundle, "BFP_FineWoodTable8");
        piece44.Crafting.Set(CraftingTable.Workbench);
        piece44.Category.Set(BuildPieceCategory.Furniture);
        piece44.Tool.Add(_customHammer);
        piece44.RequiredItems.Add(_fineWoodMat, 14, true);
        piece44.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece44.Prefab);

        BuildPiece piece45 = new(_fineWoodBundle, "BFP_FineWoodTable9");
        piece45.Crafting.Set(CraftingTable.Workbench);
        piece45.Category.Set(BuildPieceCategory.Furniture);
        piece45.Tool.Add(_customHammer);
        piece45.RequiredItems.Add(_fineWoodMat, 14, true);
        piece45.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece45.Prefab);

        BuildPiece piece46 = new(_fineWoodBundle, "BFP_LeatherBed");
        piece46.Crafting.Set(CraftingTable.Workbench);
        piece46.Category.Set(BuildPieceCategory.Furniture);
        piece46.Tool.Add(_customHammer);
        piece46.RequiredItems.Add(_fineWoodMat, 14, true);
        piece46.RequiredItems.Add("LeatherScraps", 10, true);
        piece46.RequiredItems.Add("DeerHide", 12, true);
        piece46.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece46.Prefab);

        BuildPiece piece47 = new(_fineWoodBundle, "BFP_LogChair");
        piece47.Crafting.Set(CraftingTable.Workbench);
        piece47.Category.Set(BuildPieceCategory.Furniture);
        piece47.Tool.Add(_customHammer);
        piece47.RequiredItems.Add(_fineWoodMat, 6, true);
        piece47.RequiredItems.Add("RoundLog", 1, true);
        piece47.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece47.Prefab);

        BuildPiece piece48 = new(_fineWoodBundle, "BFP_LongCrate");
        piece48.Crafting.Set(CraftingTable.Workbench);
        piece48.Category.Set(BuildPieceCategory.Furniture);
        piece48.Tool.Add(_customHammer);
        piece48.RequiredItems.Add(_fineWoodMat, 12, true);
        piece48.RequiredItems.Add("Bronze", 4, true);
        piece48.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece48.Prefab);

        BuildPiece piece49 = new(_fineWoodBundle, "BFP_LoxBed");
        piece49.Crafting.Set(CraftingTable.Workbench);
        piece49.Category.Set(BuildPieceCategory.Furniture);
        piece49.Tool.Add(_customHammer);
        piece49.RequiredItems.Add(_fineWoodMat, 18, true);
        piece49.RequiredItems.Add("LinenThread", 10, true);
        piece49.RequiredItems.Add("LoxPelt", 8, true);
        piece49.RequiredItems.Add("WolfPelt", 4, true);
        piece49.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece49.Prefab);

        BuildPiece piece50 = new(_fineWoodBundle, "BFP_LoxDoubleBed");
        piece50.Crafting.Set(CraftingTable.Workbench);
        piece50.Category.Set(BuildPieceCategory.Furniture);
        piece50.Tool.Add(_customHammer);
        piece50.RequiredItems.Add(_fineWoodMat, 26, true);
        piece50.RequiredItems.Add("LinenThread", 22, true);
        piece50.RequiredItems.Add("LoxPelt", 16, true);
        piece50.RequiredItems.Add("WolfPelt", 8, true);
        piece50.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece50.Prefab);

        BuildPiece piece51 = new(_fineWoodBundle, "BFP_MiniStool1");
        piece51.Crafting.Set(CraftingTable.Workbench);
        piece51.Category.Set(BuildPieceCategory.Furniture);
        piece51.Tool.Add(_customHammer);
        piece51.RequiredItems.Add(_fineWoodMat, 6, true);
        piece51.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece51.Prefab);

        BuildPiece piece52 = new(_fineWoodBundle, "BFP_MiniStool2");
        piece52.Crafting.Set(CraftingTable.Workbench);
        piece52.Category.Set(BuildPieceCategory.Furniture);
        piece52.Tool.Add(_customHammer);
        piece52.RequiredItems.Add(_fineWoodMat, 6, true);
        piece52.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece52.Prefab);

        BuildPiece piece53 = new(_fineWoodBundle, "BFP_MiniTable1");
        piece53.Crafting.Set(CraftingTable.Workbench);
        piece53.Category.Set(BuildPieceCategory.Furniture);
        piece53.Tool.Add(_customHammer);
        piece53.RequiredItems.Add(_fineWoodMat, 28, true);
        piece53.RequiredItems.Add("Crystal", 3, true);
        piece53.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece53.Prefab);

        BuildPiece piece54 = new(_fineWoodBundle, "BFP_MiniTable2");
        piece54.Crafting.Set(CraftingTable.Workbench);
        piece54.Category.Set(BuildPieceCategory.Furniture);
        piece54.Tool.Add(_customHammer);
        piece54.RequiredItems.Add(_fineWoodMat, 22, true);
        piece54.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece54.Prefab);

        BuildPiece piece55 = new(_fineWoodBundle, "BFP_MiniTable4");
        piece55.Crafting.Set(CraftingTable.Workbench);
        piece55.Category.Set(BuildPieceCategory.Furniture);
        piece55.Tool.Add(_customHammer);
        piece55.RequiredItems.Add(_fineWoodMat, 16, true);
        piece55.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece55.Prefab);

        BuildPiece piece56 = new(_fineWoodBundle, "BFP_PoolChair");
        piece56.Crafting.Set(CraftingTable.Workbench);
        piece56.Category.Set(BuildPieceCategory.Furniture);
        piece56.Tool.Add(_customHammer);
        piece56.RequiredItems.Add(_fineWoodMat, 18, true);
        piece56.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece56.Prefab);

        BuildPiece piece57 = new(_fineWoodBundle, "BFP_Stool1");
        piece57.Crafting.Set(CraftingTable.Workbench);
        piece57.Category.Set(BuildPieceCategory.Furniture);
        piece57.Tool.Add(_customHammer);
        piece57.RequiredItems.Add(_fineWoodMat, 14, true);
        piece57.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece57.Prefab);

        BuildPiece piece58 = new(_fineWoodBundle, "BFP_Stool2");
        piece58.Crafting.Set(CraftingTable.Workbench);
        piece58.Category.Set(BuildPieceCategory.Furniture);
        piece58.Tool.Add(_customHammer);
        piece58.RequiredItems.Add(_fineWoodMat, 14, true);
        piece58.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece58.Prefab);

        BuildPiece piece59 = new(_fineWoodBundle, "BFP_WoodenArmorStand");
        piece59.Crafting.Set(CraftingTable.Workbench);
        piece59.Category.Set(BuildPieceCategory.Furniture);
        piece59.Tool.Add(_customHammer);
        piece59.RequiredItems.Add(_fineWoodMat, 16, true);
        piece59.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece59.Prefab);
    }

    private static void HardPieces()
    {
        BuildPiece piece = new(_fineWoodBundle, "BCP_Clay2_Roof45");
        piece.Crafting.Set(CraftingTable.Workbench);
        piece.Category.Set(BuildPieceCategory.BuildingStonecutter);
        piece.Tool.Add(_customHammer);
        piece.RequiredItems.Add(_clayMat, 6, true);
        piece.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece.Prefab);

        BuildPiece piece2 = new(_fineWoodBundle, "BCP_Clay2_Roof45_Corner");
        piece2.Crafting.Set(CraftingTable.Workbench);
        piece2.Category.Set(BuildPieceCategory.BuildingStonecutter);
        piece2.Tool.Add(_customHammer);
        piece2.RequiredItems.Add(_clayMat, 6, true);
        piece2.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece2.Prefab);

        BuildPiece piece3 = new(_fineWoodBundle, "BCP_Clay2_Roof45_Corner2");
        piece3.Crafting.Set(CraftingTable.Workbench);
        piece3.Category.Set(BuildPieceCategory.BuildingStonecutter);
        piece3.Tool.Add(_customHammer);
        piece3.RequiredItems.Add(_clayMat, 6, true);
        piece3.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece3.Prefab);

        BuildPiece piece4 = new(_fineWoodBundle, "BCP_Clay2_Roof45Arch");
        piece4.Crafting.Set(CraftingTable.Workbench);
        piece4.Category.Set(BuildPieceCategory.BuildingStonecutter);
        piece4.Tool.Add(_customHammer);
        piece4.RequiredItems.Add(_clayMat, 6, true);
        piece4.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece4.Prefab);

        BuildPiece piece5 = new(_fineWoodBundle, "BCP_Clay2_Roof45Arch_Corner");
        piece5.Crafting.Set(CraftingTable.Workbench);
        piece5.Category.Set(BuildPieceCategory.BuildingStonecutter);
        piece5.Tool.Add(_customHammer);
        piece5.RequiredItems.Add(_clayMat, 6, true);
        piece5.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece5.Prefab);

        BuildPiece piece6 = new(_fineWoodBundle, "BCP_Clay2_Roof45Arch_Corner2");
        piece6.Crafting.Set(CraftingTable.Workbench);
        piece6.Category.Set(BuildPieceCategory.BuildingStonecutter);
        piece6.Tool.Add(_customHammer);
        piece6.RequiredItems.Add(_clayMat, 6, true);
        piece6.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece6.Prefab);

        BuildPiece piece7 = new(_fineWoodBundle, "BCP_ClayArch_Big");
        piece7.Crafting.Set(CraftingTable.Workbench);
        piece7.Category.Set(BuildPieceCategory.BuildingStonecutter);
        piece7.Tool.Add(_customHammer);
        piece7.RequiredItems.Add(_clayMat, 4, true);
        piece7.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece7.Prefab);

        BuildPiece piece8 = new(_fineWoodBundle, "BCP_ClayArch_Bottom");
        piece8.Crafting.Set(CraftingTable.Workbench);
        piece8.Category.Set(BuildPieceCategory.BuildingStonecutter);
        piece8.Tool.Add(_customHammer);
        piece8.RequiredItems.Add(_clayMat, 4, true);
        piece8.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece8.Prefab);

        BuildPiece piece9 = new(_fineWoodBundle, "BCP_ClayArch_Top");
        piece9.Crafting.Set(CraftingTable.Workbench);
        piece9.Category.Set(BuildPieceCategory.BuildingStonecutter);
        piece9.Tool.Add(_customHammer);
        piece9.RequiredItems.Add(_clayMat, 4, true);
        piece9.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece9.Prefab);

        BuildPiece piece10 = new(_fineWoodBundle, "BCP_ClayBeam1m");
        piece10.Crafting.Set(CraftingTable.Workbench);
        piece10.Category.Set(BuildPieceCategory.BuildingStonecutter);
        piece10.Tool.Add(_customHammer);
        piece10.RequiredItems.Add(_clayMat, 1, true);
        piece10.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece10.Prefab);

        BuildPiece piece11 = new(_fineWoodBundle, "BCP_ClayBeam2m");
        piece11.Crafting.Set(CraftingTable.Workbench);
        piece11.Category.Set(BuildPieceCategory.BuildingStonecutter);
        piece11.Tool.Add(_customHammer);
        piece11.RequiredItems.Add(_clayMat, 2, true);
        piece11.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece11.Prefab);

        BuildPiece piece12 = new(_fineWoodBundle, "BCP_ClayDeco_Floor");
        piece12.Crafting.Set(CraftingTable.Workbench);
        piece12.Category.Set(BuildPieceCategory.BuildingStonecutter);
        piece12.Tool.Add(_customHammer);
        piece12.RequiredItems.Add(_clayMat, 6, true);
        piece12.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece12.Prefab);

        BuildPiece piece13 = new(_fineWoodBundle, "BCP_ClayDecoWall_2x2");
        piece13.Crafting.Set(CraftingTable.Workbench);
        piece13.Category.Set(BuildPieceCategory.BuildingStonecutter);
        piece13.Tool.Add(_customHammer);
        piece13.RequiredItems.Add(_clayMat, 6, true);
        piece13.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece13.Prefab);

        BuildPiece piece14 = new(_fineWoodBundle, "BCP_ClayDecoWall_Divider");
        piece14.Crafting.Set(CraftingTable.Workbench);
        piece14.Category.Set(BuildPieceCategory.BuildingStonecutter);
        piece14.Tool.Add(_customHammer);
        piece14.RequiredItems.Add(_clayMat, 4, true);
        piece14.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece14.Prefab);

        BuildPiece piece15 = new(_fineWoodBundle, "BCP_ClayDecoWall_Tree");
        piece15.Crafting.Set(CraftingTable.Workbench);
        piece15.Category.Set(BuildPieceCategory.BuildingStonecutter);
        piece15.Tool.Add(_customHammer);
        piece15.RequiredItems.Add(_clayMat, 4, true);
        piece15.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece15.Prefab);

        BuildPiece piece16 = new(_fineWoodBundle, "BCP_ClayFloor_1x1");
        piece16.Crafting.Set(CraftingTable.Workbench);
        piece16.Category.Set(BuildPieceCategory.BuildingStonecutter);
        piece16.Tool.Add(_customHammer);
        piece16.RequiredItems.Add(_clayMat, 2, true);
        piece16.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece16.Prefab);

        BuildPiece piece17 = new(_fineWoodBundle, "BCP_ClayFloor_2x2");
        piece17.Crafting.Set(CraftingTable.Workbench);
        piece17.Category.Set(BuildPieceCategory.BuildingStonecutter);
        piece17.Tool.Add(_customHammer);
        piece17.RequiredItems.Add(_clayMat, 4, true);
        piece17.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece17.Prefab);

        BuildPiece piece18 = new(_fineWoodBundle, "BCP_ClayHalfWall_1x2");
        piece18.Crafting.Set(CraftingTable.Workbench);
        piece18.Category.Set(BuildPieceCategory.BuildingStonecutter);
        piece18.Tool.Add(_customHammer);
        piece18.RequiredItems.Add(_clayMat, 2, true);
        piece18.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece18.Prefab);

        BuildPiece piece19 = new(_fineWoodBundle, "BCP_ClayLadder");
        piece19.Crafting.Set(CraftingTable.Workbench);
        piece19.Category.Set(BuildPieceCategory.BuildingStonecutter);
        piece19.Tool.Add(_customHammer);
        piece19.RequiredItems.Add(_clayMat, 6, true);
        piece19.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece19.Prefab);

        BuildPiece piece20 = new(_fineWoodBundle, "BCP_ClayPillarArch");
        piece20.Crafting.Set(CraftingTable.Workbench);
        piece20.Category.Set(BuildPieceCategory.BuildingStonecutter);
        piece20.Tool.Add(_customHammer);
        piece20.RequiredItems.Add(_clayMat, 6, true);
        piece20.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece20.Prefab);

        BuildPiece piece21 = new(_fineWoodBundle, "BCP_ClayPillarArch_Small");
        piece21.Crafting.Set(CraftingTable.Workbench);
        piece21.Category.Set(BuildPieceCategory.BuildingStonecutter);
        piece21.Tool.Add(_customHammer);
        piece21.RequiredItems.Add(_clayMat, 4, true);
        piece21.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece21.Prefab);

        BuildPiece piece22 = new(_fineWoodBundle, "BCP_ClayPillarBase_Medium");
        piece22.Crafting.Set(CraftingTable.Workbench);
        piece22.Category.Set(BuildPieceCategory.BuildingStonecutter);
        piece22.Tool.Add(_customHammer);
        piece22.RequiredItems.Add(_clayMat, 5, true);
        piece22.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece22.Prefab);

        BuildPiece piece23 = new(_fineWoodBundle, "BCP_ClayPillarBase_Small");
        piece23.Crafting.Set(CraftingTable.Workbench);
        piece23.Category.Set(BuildPieceCategory.BuildingStonecutter);
        piece23.Tool.Add(_customHammer);
        piece23.RequiredItems.Add(_clayMat, 4, true);
        piece23.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece23.Prefab);

        BuildPiece piece24 = new(_fineWoodBundle, "BCP_ClayPillarBase_Tapered");
        piece24.Crafting.Set(CraftingTable.Workbench);
        piece24.Category.Set(BuildPieceCategory.BuildingStonecutter);
        piece24.Tool.Add(_customHammer);
        piece24.RequiredItems.Add(_clayMat, 6, true);
        piece24.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece24.Prefab);

        BuildPiece piece25 = new(_fineWoodBundle, "BCP_ClayPillarBase_TaperedInverted");
        piece25.Crafting.Set(CraftingTable.Workbench);
        piece25.Category.Set(BuildPieceCategory.BuildingStonecutter);
        piece25.Tool.Add(_customHammer);
        piece25.RequiredItems.Add(_clayMat, 6, true);
        piece25.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece25.Prefab);

        BuildPiece piece26 = new(_fineWoodBundle, "BCP_ClayPillarBeam_Medium");
        piece26.Crafting.Set(CraftingTable.Workbench);
        piece26.Category.Set(BuildPieceCategory.BuildingStonecutter);
        piece26.Tool.Add(_customHammer);
        piece26.RequiredItems.Add(_clayMat, 6, true);
        piece26.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece26.Prefab);

        BuildPiece piece27 = new(_fineWoodBundle, "BCP_ClayPillarBeam_Small");
        piece27.Crafting.Set(CraftingTable.Workbench);
        piece27.Category.Set(BuildPieceCategory.BuildingStonecutter);
        piece27.Tool.Add(_customHammer);
        piece27.RequiredItems.Add(_clayMat, 4, true);
        piece27.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece27.Prefab);

        BuildPiece piece28 = new(_fineWoodBundle, "BCP_ClayPole1m");
        piece28.Crafting.Set(CraftingTable.Workbench);
        piece28.Category.Set(BuildPieceCategory.BuildingStonecutter);
        piece28.Tool.Add(_customHammer);
        piece28.RequiredItems.Add(_clayMat, 1, true);
        piece28.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece28.Prefab);

        BuildPiece piece29 = new(_fineWoodBundle, "BCP_ClayPole_2m");
        piece29.Crafting.Set(CraftingTable.Workbench);
        piece29.Category.Set(BuildPieceCategory.BuildingStonecutter);
        piece29.Tool.Add(_customHammer);
        piece29.RequiredItems.Add(_clayMat, 2, true);
        piece29.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece29.Prefab);

        BuildPiece piece30 = new(_fineWoodBundle, "BCP_ClayQuarterWall_1x1");
        piece30.Crafting.Set(CraftingTable.Workbench);
        piece30.Category.Set(BuildPieceCategory.BuildingStonecutter);
        piece30.Tool.Add(_customHammer);
        piece30.RequiredItems.Add(_clayMat, 1, true);
        piece30.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece30.Prefab);

        BuildPiece piece31 = new(_fineWoodBundle, "BCP_ClayRoundDoor");
        piece31.Crafting.Set(CraftingTable.Workbench);
        piece31.Category.Set(BuildPieceCategory.BuildingStonecutter);
        piece31.Tool.Add(_customHammer);
        piece31.RequiredItems.Add(_clayMat, 12, true);
        piece31.RequiredItems.Add("Copper", 8, true);
        piece31.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece31.Prefab);

        BuildPiece piece32 = new(_fineWoodBundle, "BCP_ClayStair2");
        piece32.Crafting.Set(CraftingTable.Workbench);
        piece32.Category.Set(BuildPieceCategory.BuildingStonecutter);
        piece32.Tool.Add(_customHammer);
        piece32.RequiredItems.Add(_clayMat, 6, true);
        piece32.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece32.Prefab);

        BuildPiece piece33 = new(_fineWoodBundle, "BCP_ClayWall1x2");
        piece33.Crafting.Set(CraftingTable.Workbench);
        piece33.Category.Set(BuildPieceCategory.BuildingStonecutter);
        piece33.Tool.Add(_customHammer);
        piece33.RequiredItems.Add(_clayMat, 3, true);
        piece33.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece33.Prefab);

        BuildPiece piece34 = new(_fineWoodBundle, "BCP_ClayWall2x2");
        piece34.Crafting.Set(CraftingTable.Workbench);
        piece34.Category.Set(BuildPieceCategory.BuildingStonecutter);
        piece34.Tool.Add(_customHammer);
        piece34.RequiredItems.Add(_clayMat, 4, true);
        piece34.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece34.Prefab);

        BuildPiece piece35 = new(_fineWoodBundle, "BCP_ClayWall4x2");
        piece35.Crafting.Set(CraftingTable.Workbench);
        piece35.Category.Set(BuildPieceCategory.BuildingStonecutter);
        piece35.Tool.Add(_customHammer);
        piece35.RequiredItems.Add(_clayMat, 6, true);
        piece35.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece35.Prefab);

        BuildPiece piece36 = new(_fineWoodBundle, "BCP_ClayWall_2x2");
        piece36.Crafting.Set(CraftingTable.Workbench);
        piece36.Category.Set(BuildPieceCategory.BuildingStonecutter);
        piece36.Tool.Add(_customHammer);
        piece36.RequiredItems.Add(_clayMat, 4, true);
        piece36.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece36.Prefab);

        BuildPiece piece37 = new(_fineWoodBundle, "BCP_ClayWall_Arch");
        piece37.Crafting.Set(CraftingTable.Workbench);
        piece37.Category.Set(BuildPieceCategory.BuildingStonecutter);
        piece37.Tool.Add(_customHammer);
        piece37.RequiredItems.Add(_clayMat, 3, true);
        piece37.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece37.Prefab);

        BuildPiece piece38 = new(_fineWoodBundle, "BCP_ClayWall_Arch2");
        piece38.Crafting.Set(CraftingTable.Workbench);
        piece38.Category.Set(BuildPieceCategory.BuildingStonecutter);
        piece38.Tool.Add(_customHammer);
        piece38.RequiredItems.Add(_clayMat, 3, true);
        piece38.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece38.Prefab);

        BuildPiece piece39 = new(_fineWoodBundle, "BCP_ClayWall_ArchInverted");
        piece39.Crafting.Set(CraftingTable.Workbench);
        piece39.Category.Set(BuildPieceCategory.BuildingStonecutter);
        piece39.Tool.Add(_customHammer);
        piece39.RequiredItems.Add(_clayMat, 3, true);
        piece39.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece39.Prefab);

        BuildPiece piece40 = new(_fineWoodBundle, "BCP_ClayWall_Beam26");
        piece40.Crafting.Set(CraftingTable.Workbench);
        piece40.Category.Set(BuildPieceCategory.BuildingStonecutter);
        piece40.Tool.Add(_customHammer);
        piece40.RequiredItems.Add(_clayMat, 2, true);
        piece40.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece40.Prefab);

        BuildPiece piece41 = new(_fineWoodBundle, "BCP_ClayWall_Beam26Alt");
        piece41.Crafting.Set(CraftingTable.Workbench);
        piece41.Category.Set(BuildPieceCategory.BuildingStonecutter);
        piece41.Tool.Add(_customHammer);
        piece41.RequiredItems.Add(_clayMat, 2, true);
        piece41.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece41.Prefab);

        BuildPiece piece42 = new(_fineWoodBundle, "BCP_ClayWall_Beam45");
        piece42.Crafting.Set(CraftingTable.Workbench);
        piece42.Category.Set(BuildPieceCategory.BuildingStonecutter);
        piece42.Tool.Add(_customHammer);
        piece42.RequiredItems.Add(_clayMat, 2, true);
        piece42.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece42.Prefab);

        BuildPiece piece43 = new(_fineWoodBundle, "BCP_ClayWall_Beam45Alt");
        piece43.Crafting.Set(CraftingTable.Workbench);
        piece43.Category.Set(BuildPieceCategory.BuildingStonecutter);
        piece43.Tool.Add(_customHammer);
        piece43.RequiredItems.Add(_clayMat, 2, true);
        piece43.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece43.Prefab);

        BuildPiece piece44 = new(_fineWoodBundle, "BCP_ClayWall_Cross26");
        piece44.Crafting.Set(CraftingTable.Workbench);
        piece44.Category.Set(BuildPieceCategory.BuildingStonecutter);
        piece44.Tool.Add(_customHammer);
        piece44.RequiredItems.Add(_clayMat, 3, true);
        piece44.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece44.Prefab);

        BuildPiece piece45 = new(_fineWoodBundle, "BCP_ClayWall_Cross26Alt");
        piece45.Crafting.Set(CraftingTable.Workbench);
        piece45.Category.Set(BuildPieceCategory.BuildingStonecutter);
        piece45.Tool.Add(_customHammer);
        piece45.RequiredItems.Add(_clayMat, 3, true);
        piece45.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece45.Prefab);

        BuildPiece piece46 = new(_fineWoodBundle, "BCP_ClayWall_Cross45");
        piece46.Crafting.Set(CraftingTable.Workbench);
        piece46.Category.Set(BuildPieceCategory.BuildingStonecutter);
        piece46.Tool.Add(_customHammer);
        piece46.RequiredItems.Add(_clayMat, 3, true);
        piece46.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece46.Prefab);

        BuildPiece piece47 = new(_fineWoodBundle, "BCP_ClayWall_Cross45Alt");
        piece47.Crafting.Set(CraftingTable.Workbench);
        piece47.Category.Set(BuildPieceCategory.BuildingStonecutter);
        piece47.Tool.Add(_customHammer);
        piece47.RequiredItems.Add(_clayMat, 3, true);
        piece47.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece47.Prefab);

        BuildPiece piece48 = new(_fineWoodBundle, "BCP_ClayWall_Roof26");
        piece48.Crafting.Set(CraftingTable.Workbench);
        piece48.Category.Set(BuildPieceCategory.BuildingStonecutter);
        piece48.Tool.Add(_customHammer);
        piece48.RequiredItems.Add(_clayMat, 2, true);
        piece48.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece48.Prefab);

        BuildPiece piece49 = new(_fineWoodBundle, "BCP_ClayWall_Roof26UpsideDown");
        piece49.Crafting.Set(CraftingTable.Workbench);
        piece49.Category.Set(BuildPieceCategory.BuildingStonecutter);
        piece49.Tool.Add(_customHammer);
        piece49.RequiredItems.Add(_clayMat, 2, true);
        piece49.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece49.Prefab);

        BuildPiece piece50 = new(_fineWoodBundle, "BCP_ClayWall_Roof45");
        piece50.Crafting.Set(CraftingTable.Workbench);
        piece50.Category.Set(BuildPieceCategory.BuildingStonecutter);
        piece50.Tool.Add(_customHammer);
        piece50.RequiredItems.Add(_clayMat, 2, true);
        piece50.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece50.Prefab);

        BuildPiece piece51 = new(_fineWoodBundle, "BCP_ClayWall_Roof45UpsideDown");
        piece51.Crafting.Set(CraftingTable.Workbench);
        piece51.Category.Set(BuildPieceCategory.BuildingStonecutter);
        piece51.Tool.Add(_customHammer);
        piece51.RequiredItems.Add(_clayMat, 2, true);
        piece51.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece51.Prefab);

        BuildPiece piece52 = new(_fineWoodBundle, "BCP_ClayWindow2x2");
        piece52.Crafting.Set(CraftingTable.Workbench);
        piece52.Category.Set(BuildPieceCategory.BuildingStonecutter);
        piece52.Tool.Add(_customHammer);
        piece52.RequiredItems.Add(_clayMat, 4, true);
        piece52.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece52.Prefab);

        BuildPiece piece53 = new(_fineWoodBundle, "BCP_ClayWindow4x2");
        piece53.Crafting.Set(CraftingTable.Workbench);
        piece53.Category.Set(BuildPieceCategory.BuildingStonecutter);
        piece53.Tool.Add(_customHammer);
        piece53.RequiredItems.Add(_clayMat, 8, true);
        piece53.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece53.Prefab);

        BuildPiece piece54 = new(_fineWoodBundle, "BFP_ClayArch");
        piece54.Crafting.Set(CraftingTable.Workbench);
        piece54.Category.Set(BuildPieceCategory.BuildingStonecutter);
        piece54.Tool.Add(_customHammer);
        piece54.RequiredItems.Add(_clayMat, 4, true);
        piece54.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece54.Prefab);

        BuildPiece piece55 = new(_fineWoodBundle, "BFP_ClayArch2");
        piece55.Crafting.Set(CraftingTable.Workbench);
        piece55.Category.Set(BuildPieceCategory.BuildingStonecutter);
        piece55.Tool.Add(_customHammer);
        piece55.RequiredItems.Add(_clayMat, 4, true);
        piece55.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece55.Prefab);

        BuildPiece piece56 = new(_fineWoodBundle, "BFP_ClayBase1");
        piece56.Crafting.Set(CraftingTable.Workbench);
        piece56.Category.Set(BuildPieceCategory.BuildingStonecutter);
        piece56.Tool.Add(_customHammer);
        piece56.RequiredItems.Add(_clayMat, 3, true);
        piece56.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece56.Prefab);

        BuildPiece piece57 = new(_fineWoodBundle, "BFP_ClayBase2");
        piece57.Crafting.Set(CraftingTable.Workbench);
        piece57.Category.Set(BuildPieceCategory.BuildingStonecutter);
        piece57.Tool.Add(_customHammer);
        piece57.RequiredItems.Add(_clayMat, 3, true);
        piece57.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece57.Prefab);

        BuildPiece piece58 = new(_fineWoodBundle, "BFP_ClayBaseCorner");
        piece58.Crafting.Set(CraftingTable.Workbench);
        piece58.Category.Set(BuildPieceCategory.BuildingStonecutter);
        piece58.Tool.Add(_customHammer);
        piece58.RequiredItems.Add(_clayMat, 3, true);
        piece58.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece58.Prefab);

        BuildPiece piece59 = new(_fineWoodBundle, "BFP_ClayBlock1x1");
        piece59.Crafting.Set(CraftingTable.Workbench);
        piece59.Category.Set(BuildPieceCategory.BuildingStonecutter);
        piece59.Tool.Add(_customHammer);
        piece59.RequiredItems.Add(_clayMat, 2, true);
        piece59.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece59.Prefab);

        BuildPiece piece60 = new(_fineWoodBundle, "BFP_ClayBlock2x1x1");
        piece60.Crafting.Set(CraftingTable.Workbench);
        piece60.Category.Set(BuildPieceCategory.BuildingStonecutter);
        piece60.Tool.Add(_customHammer);
        piece60.RequiredItems.Add(_clayMat, 2, true);
        piece60.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece60.Prefab);

        BuildPiece piece61 = new(_fineWoodBundle, "BFP_ClayBlock2x2_Enforced");
        piece61.Crafting.Set(CraftingTable.Workbench);
        piece61.Category.Set(BuildPieceCategory.BuildingStonecutter);
        piece61.Tool.Add(_customHammer);
        piece61.RequiredItems.Add(_clayMat, 4, true);
        piece61.RequiredItems.Add("Copper", 2, true);
        piece61.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece61.Prefab);

        BuildPiece piece62 = new(_fineWoodBundle, "BFP_ClayBlock2x2x1");
        piece62.Crafting.Set(CraftingTable.Workbench);
        piece62.Category.Set(BuildPieceCategory.BuildingStonecutter);
        piece62.Tool.Add(_customHammer);
        piece62.RequiredItems.Add(_clayMat, 6, true);
        piece62.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece62.Prefab);

        BuildPiece piece63 = new(_fineWoodBundle, "BFP_ClayBlock2x2x2");
        piece63.Crafting.Set(CraftingTable.Workbench);
        piece63.Category.Set(BuildPieceCategory.BuildingStonecutter);
        piece63.Tool.Add(_customHammer);
        piece63.RequiredItems.Add(_clayMat, 4, true);
        piece63.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece63.Prefab);

        BuildPiece piece64 = new(_fineWoodBundle, "BFP_ClayBlock_OutCorner");
        piece64.Crafting.Set(CraftingTable.Workbench);
        piece64.Category.Set(BuildPieceCategory.BuildingStonecutter);
        piece64.Tool.Add(_customHammer);
        piece64.RequiredItems.Add(_clayMat, 3, true);
        piece64.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece64.Prefab);

        BuildPiece piece65 = new(_fineWoodBundle, "BFP_ClayBlock_SlopeInverted1x2");
        piece65.Crafting.Set(CraftingTable.Workbench);
        piece65.Category.Set(BuildPieceCategory.BuildingStonecutter);
        piece65.Tool.Add(_customHammer);
        piece65.RequiredItems.Add(_clayMat, 2, true);
        piece65.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece65.Prefab);

        BuildPiece piece66 = new(_fineWoodBundle, "BFP_ClayBlockOut1");
        piece66.Crafting.Set(CraftingTable.Workbench);
        piece66.Category.Set(BuildPieceCategory.BuildingStonecutter);
        piece66.Tool.Add(_customHammer);
        piece66.RequiredItems.Add(_clayMat, 3, true);
        piece66.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece66.Prefab);

        BuildPiece piece67 = new(_fineWoodBundle, "BFP_ClayBlockOut2");
        piece67.Crafting.Set(CraftingTable.Workbench);
        piece67.Category.Set(BuildPieceCategory.BuildingStonecutter);
        piece67.Tool.Add(_customHammer);
        piece67.RequiredItems.Add(_clayMat, 3, true);
        piece67.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece67.Prefab);

        BuildPiece piece68 = new(_fineWoodBundle, "BFP_ClayBlockSlope1x2");
        piece68.Crafting.Set(CraftingTable.Workbench);
        piece68.Category.Set(BuildPieceCategory.BuildingStonecutter);
        piece68.Tool.Add(_customHammer);
        piece68.RequiredItems.Add(_clayMat, 2, true);
        piece68.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece68.Prefab);

        BuildPiece piece69 = new(_fineWoodBundle, "BFP_ClayColumn1");
        piece69.Crafting.Set(CraftingTable.Workbench);
        piece69.Category.Set(BuildPieceCategory.BuildingStonecutter);
        piece69.Tool.Add(_customHammer);
        piece69.RequiredItems.Add(_clayMat, 3, true);
        piece69.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece69.Prefab);

        BuildPiece piece70 = new(_fineWoodBundle, "BFP_ClayColumn2");
        piece70.Crafting.Set(CraftingTable.Workbench);
        piece70.Category.Set(BuildPieceCategory.BuildingStonecutter);
        piece70.Tool.Add(_customHammer);
        piece70.RequiredItems.Add(_clayMat, 5, true);
        piece70.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece70.Prefab);

        BuildPiece piece71 = new(_fineWoodBundle, "BFP_ClayFloor");
        piece71.Crafting.Set(CraftingTable.Workbench);
        piece71.Category.Set(BuildPieceCategory.BuildingStonecutter);
        piece71.Tool.Add(_customHammer);
        piece71.RequiredItems.Add(_clayMat, 4, true);
        piece71.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece71.Prefab);

        BuildPiece piece72 = new(_fineWoodBundle, "BFP_ClayFloorLarge");
        piece72.Crafting.Set(CraftingTable.Workbench);
        piece72.Category.Set(BuildPieceCategory.BuildingStonecutter);
        piece72.Tool.Add(_customHammer);
        piece72.RequiredItems.Add(_clayMat, 8, true);
        piece72.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece72.Prefab);

        BuildPiece piece73 = new(_fineWoodBundle, "BFP_ClayFloorTriangle");
        piece73.Crafting.Set(CraftingTable.Workbench);
        piece73.Category.Set(BuildPieceCategory.BuildingStonecutter);
        piece73.Tool.Add(_customHammer);
        piece73.RequiredItems.Add(_clayMat, 3, true);
        piece73.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece73.Prefab);

        BuildPiece piece74 = new(_fineWoodBundle, "BFP_ClayHead1");
        piece74.Crafting.Set(CraftingTable.Workbench);
        piece74.Category.Set(BuildPieceCategory.BuildingStonecutter);
        piece74.Tool.Add(_customHammer);
        piece74.RequiredItems.Add(_clayMat, 4, true);
        piece74.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece74.Prefab);

        BuildPiece piece75 = new(_fineWoodBundle, "BFP_ClayHead2");
        piece75.Crafting.Set(CraftingTable.Workbench);
        piece75.Category.Set(BuildPieceCategory.BuildingStonecutter);
        piece75.Tool.Add(_customHammer);
        piece75.RequiredItems.Add(_clayMat, 4, true);
        piece75.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece75.Prefab);

        BuildPiece piece76 = new(_fineWoodBundle, "BFP_ClayPillar");
        piece76.Crafting.Set(CraftingTable.Workbench);
        piece76.Category.Set(BuildPieceCategory.BuildingStonecutter);
        piece76.Tool.Add(_customHammer);
        piece76.RequiredItems.Add(_clayMat, 8, true);
        piece76.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece76.Prefab);

        BuildPiece piece77 = new(_fineWoodBundle, "BFP_ClayRoof26");
        piece77.Crafting.Set(CraftingTable.Workbench);
        piece77.Category.Set(BuildPieceCategory.BuildingStonecutter);
        piece77.Tool.Add(_customHammer);
        piece77.RequiredItems.Add(_clayMat, 6, true);
        piece77.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece77.Prefab);

        BuildPiece piece78 = new(_fineWoodBundle, "BFP_ClayRoof45");
        piece78.Crafting.Set(CraftingTable.Workbench);
        piece78.Category.Set(BuildPieceCategory.BuildingStonecutter);
        piece78.Tool.Add(_customHammer);
        piece78.RequiredItems.Add(_clayMat, 6, true);
        piece78.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece78.Prefab);

        BuildPiece piece79 = new(_fineWoodBundle, "BFP_ClayRoofICorner26");
        piece79.Crafting.Set(CraftingTable.Workbench);
        piece79.Category.Set(BuildPieceCategory.BuildingStonecutter);
        piece79.Tool.Add(_customHammer);
        piece79.RequiredItems.Add(_clayMat, 6, true);
        piece79.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece79.Prefab);

        BuildPiece piece80 = new(_fineWoodBundle, "BFP_ClayRoofICorner45");
        piece80.Crafting.Set(CraftingTable.Workbench);
        piece80.Category.Set(BuildPieceCategory.BuildingStonecutter);
        piece80.Tool.Add(_customHammer);
        piece80.RequiredItems.Add(_clayMat, 6, true);
        piece80.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece80.Prefab);

        BuildPiece piece81 = new(_fineWoodBundle, "BFP_ClayRoofOCorner26");
        piece81.Crafting.Set(CraftingTable.Workbench);
        piece81.Category.Set(BuildPieceCategory.BuildingStonecutter);
        piece81.Tool.Add(_customHammer);
        piece81.RequiredItems.Add(_clayMat, 6, true);
        piece81.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece81.Prefab);

        BuildPiece piece82 = new(_fineWoodBundle, "BFP_ClayRoofOCorner45");
        piece82.Crafting.Set(CraftingTable.Workbench);
        piece82.Category.Set(BuildPieceCategory.BuildingStonecutter);
        piece82.Tool.Add(_customHammer);
        piece82.RequiredItems.Add(_clayMat, 6, true);
        piece82.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece82.Prefab);

        BuildPiece piece83 = new(_fineWoodBundle, "BFP_ClayRoofTop26");
        piece83.Crafting.Set(CraftingTable.Workbench);
        piece83.Category.Set(BuildPieceCategory.BuildingStonecutter);
        piece83.Tool.Add(_customHammer);
        piece83.RequiredItems.Add(_clayMat, 4, true);
        piece83.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece83.Prefab);

        BuildPiece piece84 = new(_fineWoodBundle, "BFP_ClayRoofTop45");
        piece84.Crafting.Set(CraftingTable.Workbench);
        piece84.Category.Set(BuildPieceCategory.BuildingStonecutter);
        piece84.Tool.Add(_customHammer);
        piece84.RequiredItems.Add(_clayMat, 4, true);
        piece84.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece84.Prefab);

        BuildPiece piece85 = new(_fineWoodBundle, "BFP_ClayStair");
        piece85.Crafting.Set(CraftingTable.Workbench);
        piece85.Category.Set(BuildPieceCategory.BuildingStonecutter);
        piece85.Tool.Add(_customHammer);
        piece85.RequiredItems.Add(_clayMat, 4, true);
        piece85.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece85.Prefab);

        BuildPiece piece86 = new(_fineWoodBundle, "BFP_ClayTileFloor1x1");
        piece86.Crafting.Set(CraftingTable.Workbench);
        piece86.Category.Set(BuildPieceCategory.BuildingStonecutter);
        piece86.Tool.Add(_customHammer);
        piece86.RequiredItems.Add(_clayMat, 1, true);
        piece86.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece86.Prefab);

        BuildPiece piece87 = new(_fineWoodBundle, "BFP_ClayTileFloor2x2");
        piece87.Crafting.Set(CraftingTable.Workbench);
        piece87.Category.Set(BuildPieceCategory.BuildingStonecutter);
        piece87.Tool.Add(_customHammer);
        piece87.RequiredItems.Add(_clayMat, 4, true);
        piece87.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece87.Prefab);

        BuildPiece piece88 = new(_fineWoodBundle, "BFP_ClayTileWall1x1");
        piece88.Crafting.Set(CraftingTable.Workbench);
        piece88.Category.Set(BuildPieceCategory.BuildingStonecutter);
        piece88.Tool.Add(_customHammer);
        piece88.RequiredItems.Add(_clayMat, 1, true);
        piece88.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece88.Prefab);

        BuildPiece piece89 = new(_fineWoodBundle, "BFP_ClayTileWall2x2");
        piece89.Crafting.Set(CraftingTable.Workbench);
        piece89.Category.Set(BuildPieceCategory.BuildingStonecutter);
        piece89.Tool.Add(_customHammer);
        piece89.RequiredItems.Add(_clayMat, 4, true);
        piece89.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece89.Prefab);

        BuildPiece piece90 = new(_fineWoodBundle, "BFP_ClayTileWall2x4");
        piece90.Crafting.Set(CraftingTable.Workbench);
        piece90.Category.Set(BuildPieceCategory.BuildingStonecutter);
        piece90.Tool.Add(_customHammer);
        piece90.RequiredItems.Add(_clayMat, 6, true);
        piece90.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece90.Prefab);

        BuildPiece piece91 = new(_fineWoodBundle, "BFP_ClayTip");
        piece91.Crafting.Set(CraftingTable.Workbench);
        piece91.Category.Set(BuildPieceCategory.BuildingStonecutter);
        piece91.Tool.Add(_customHammer);
        piece91.RequiredItems.Add(_clayMat, 2, true);
        piece91.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece91.Prefab);

        BuildPiece piece92 = new(_fineWoodBundle, "BFP_StoneRoof26");
        piece92.Crafting.Set(CraftingTable.Workbench);
        piece92.Category.Set(BuildPieceCategory.BuildingStonecutter);
        piece92.RequiredItems.Add("Stone", 6, true);
        piece92.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece92.Prefab);

        BuildPiece piece93 = new(_fineWoodBundle, "BFP_StoneRoof45");
        piece93.Crafting.Set(CraftingTable.Workbench);
        piece93.Category.Set(BuildPieceCategory.BuildingStonecutter);
        piece93.RequiredItems.Add("Stone", 6, true);
        piece93.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece93.Prefab);

        BuildPiece piece94 = new(_fineWoodBundle, "BFP_StoneRoofICorner26");
        piece94.Crafting.Set(CraftingTable.Workbench);
        piece94.Category.Set(BuildPieceCategory.BuildingStonecutter);
        piece94.RequiredItems.Add("Stone", 6, true);
        piece94.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece94.Prefab);

        BuildPiece piece95 = new(_fineWoodBundle, "BFP_StoneRoofICorner45");
        piece95.Crafting.Set(CraftingTable.Workbench);
        piece95.Category.Set(BuildPieceCategory.BuildingStonecutter);
        piece95.RequiredItems.Add("Stone", 6, true);
        piece95.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece95.Prefab);

        BuildPiece piece96 = new(_fineWoodBundle, "BFP_StoneRoofOCorner26");
        piece96.Crafting.Set(CraftingTable.Workbench);
        piece96.Category.Set(BuildPieceCategory.BuildingStonecutter);
        piece96.RequiredItems.Add("Stone", 6, true);
        piece96.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece96.Prefab);

        BuildPiece piece97 = new(_fineWoodBundle, "BFP_StoneRoofOCorner45");
        piece97.Crafting.Set(CraftingTable.Workbench);
        piece97.Category.Set(BuildPieceCategory.BuildingStonecutter);
        piece97.RequiredItems.Add("Stone", 6, true);
        piece97.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece97.Prefab);

        BuildPiece piece98 = new(_fineWoodBundle, "BFP_StoneRoofTop26");
        piece98.Crafting.Set(CraftingTable.Workbench);
        piece98.Category.Set(BuildPieceCategory.BuildingStonecutter);
        piece98.RequiredItems.Add("Stone", 4, true);
        piece98.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece97.Prefab);

        BuildPiece piece99 = new(_fineWoodBundle, "BFP_StoneRoofTop45");
        piece99.Crafting.Set(CraftingTable.Workbench);
        piece99.Category.Set(BuildPieceCategory.BuildingStonecutter);
        piece99.RequiredItems.Add("Stone", 4, true);
        piece99.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece99.Prefab);
    }

    private static void Misc()
    {
        BuildPiece piece = new(_fineWoodBundle, "BFP_BarrelClutter");
        piece.Crafting.Set(CraftingTable.Workbench);
        piece.Category.Set(BuildPieceCategory.Misc);
        piece.Tool.Add(_customHammer);
        piece.RequiredItems.Add(_fineWoodMat, 10, true);
        piece.RequiredItems.Add("Bronze", 4, true);
        piece.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece.Prefab);

        BuildPiece piece2 = new(_fineWoodBundle, "BFP_Candle1");
        piece2.Crafting.Set(CraftingTable.Workbench);
        piece2.Category.Set(BuildPieceCategory.Misc);
        piece2.Tool.Add(_customHammer);
        piece2.RequiredItems.Add("Tin", 2, true);
        piece2.RequiredItems.Add("Honey", 1, true);
        piece2.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };

        BuildPiece piece3 = new(_fineWoodBundle, "BFP_ClayCorgi");
        piece3.Crafting.Set(CraftingTable.Workbench);
        piece3.Category.Set(BuildPieceCategory.Misc);
        piece3.Tool.Add(_customHammer);
        piece3.RequiredItems.Add(_clayMat, 6, true);
        piece3.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece3.Prefab);

        BuildPiece piece4 = new(_fineWoodBundle, "BFP_ClayDeer");
        piece4.Crafting.Set(CraftingTable.Workbench);
        piece4.Category.Set(BuildPieceCategory.Misc);
        piece4.Tool.Add(_customHammer);
        piece4.RequiredItems.Add(_clayMat, 8, true);
        piece4.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece4.Prefab);

        BuildPiece piece5 = new(_fineWoodBundle, "BFP_ClayHare");
        piece5.Crafting.Set(CraftingTable.Workbench);
        piece5.Category.Set(BuildPieceCategory.Misc);
        piece5.Tool.Add(_customHammer);
        piece5.RequiredItems.Add(_clayMat, 6, true);
        piece5.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece5.Prefab);

        BuildPiece piece6 = new(_fineWoodBundle, "BFP_ClayLightPost");
        piece6.Crafting.Set(CraftingTable.Workbench);
        piece6.Category.Set(BuildPieceCategory.Misc);
        piece6.Tool.Add(_customHammer);
        piece6.RequiredItems.Add(_clayMat, 20, true);
        piece6.RequiredItems.Add("Coal", 6, true);
        piece6.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece6.Prefab);

        BuildPiece piece7 = new(_fineWoodBundle, "BFP_FenceGate");
        piece7.Crafting.Set(CraftingTable.Workbench);
        piece7.Category.Set(BuildPieceCategory.Misc);
        piece7.Tool.Add(_customHammer);
        piece7.RequiredItems.Add(_fineWoodMat, 14, true);
        piece7.RequiredItems.Add(_bronzeNailsMat, 8, true);
        piece7.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece7.Prefab);

        BuildPiece piece8 = new(_fineWoodBundle, "BFP_FencePillar1");
        piece8.Crafting.Set(CraftingTable.Workbench);
        piece8.Category.Set(BuildPieceCategory.Misc);
        piece8.Tool.Add(_customHammer);
        piece8.RequiredItems.Add(_fineWoodMat, 2, true);
        piece8.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece8.Prefab);

        BuildPiece piece9 = new(_fineWoodBundle, "BFP_FencePillar2");
        piece9.Crafting.Set(CraftingTable.Workbench);
        piece9.Category.Set(BuildPieceCategory.Misc);
        piece9.Tool.Add(_customHammer);
        piece9.RequiredItems.Add(_fineWoodMat, 2, true);
        piece9.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece9.Prefab);

        BuildPiece piece10 = new(_fineWoodBundle, "BFP_FencePillar3");
        piece10.Crafting.Set(CraftingTable.Workbench);
        piece10.Category.Set(BuildPieceCategory.Misc);
        piece10.Tool.Add(_customHammer);
        piece10.RequiredItems.Add(_fineWoodMat, 2, true);
        piece10.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece10.Prefab);

        BuildPiece piece11 = new(_fineWoodBundle, "BFP_FencePillar4");
        piece11.Crafting.Set(CraftingTable.Workbench);
        piece11.Category.Set(BuildPieceCategory.Misc);
        piece11.Tool.Add(_customHammer);
        piece11.RequiredItems.Add(_fineWoodMat, 2, true);
        piece11.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece11.Prefab);

        BuildPiece piece12 = new(_fineWoodBundle, "BFP_FenceTile1");
        piece12.Crafting.Set(CraftingTable.Workbench);
        piece12.Category.Set(BuildPieceCategory.Misc);
        piece12.Tool.Add(_customHammer);
        piece12.RequiredItems.Add(_fineWoodMat, 4, true);
        piece12.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece12.Prefab);

        BuildPiece piece13 = new(_fineWoodBundle, "BFP_FenceTile2");
        piece13.Crafting.Set(CraftingTable.Workbench);
        piece13.Category.Set(BuildPieceCategory.Misc);
        piece13.Tool.Add(_customHammer);
        piece13.RequiredItems.Add(_fineWoodMat, 4, true);
        piece13.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece13.Prefab);

        BuildPiece piece14 = new(_fineWoodBundle, "BFP_FenceTile3");
        piece14.Crafting.Set(CraftingTable.Workbench);
        piece14.Category.Set(BuildPieceCategory.Misc);
        piece14.Tool.Add(_customHammer);
        piece14.RequiredItems.Add(_fineWoodMat, 4, true);
        piece14.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece14.Prefab);

        BuildPiece piece15 = new(_fineWoodBundle, "BFP_FenceTile4");
        piece15.Crafting.Set(CraftingTable.Workbench);
        piece15.Category.Set(BuildPieceCategory.Misc);
        piece15.Tool.Add(_customHammer);
        piece15.RequiredItems.Add(_fineWoodMat, 4, true);
        piece15.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece15.Prefab);

        BuildPiece piece16 = new(_fineWoodBundle, "BFP_FineWoodCrib");
        piece16.Crafting.Set(CraftingTable.Workbench);
        piece16.Category.Set(BuildPieceCategory.Misc);
        piece16.Tool.Add(_customHammer);
        piece16.RequiredItems.Add(_fineWoodMat, 42, true);
        piece16.RequiredItems.Add(_bronzeNailsMat, 18, true);
        piece16.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece16.Prefab);

        BuildPiece piece17 = new(_fineWoodBundle, "BFP_FineWoodDragon");
        piece17.Crafting.Set(CraftingTable.Workbench);
        piece17.Category.Set(BuildPieceCategory.Misc);
        piece17.Tool.Add(_customHammer);
        piece17.RequiredItems.Add(_fineWoodMat, 6, true);
        piece17.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece17.Prefab);

        BuildPiece piece18 = new(_fineWoodBundle, "BFP_FineWoodRaven");
        piece18.Crafting.Set(CraftingTable.Workbench);
        piece18.Category.Set(BuildPieceCategory.Misc);
        piece18.Tool.Add(_customHammer);
        piece18.RequiredItems.Add(_fineWoodMat, 6, true);
        piece18.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece18.Prefab);

        BuildPiece piece19 = new(_fineWoodBundle, "BFP_FineWoodWolf");
        piece19.Crafting.Set(CraftingTable.Workbench);
        piece19.Category.Set(BuildPieceCategory.Misc);
        piece19.Tool.Add(_customHammer);
        piece19.RequiredItems.Add(_fineWoodMat, 6, true);
        piece19.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece19.Prefab);

        BuildPiece piece20 = new(_fineWoodBundle, "BFP_FlowerStand1");
        piece20.Crafting.Set(CraftingTable.Workbench);
        piece20.Category.Set(BuildPieceCategory.Misc);
        piece20.Tool.Add(_customHammer);
        piece20.RequiredItems.Add("Tin", 4, true);
        piece20.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece20.Prefab);

        BuildPiece piece21 = new(_fineWoodBundle, "BFP_FlowerStand2");
        piece21.Crafting.Set(CraftingTable.Workbench);
        piece21.Category.Set(BuildPieceCategory.Misc);
        piece21.Tool.Add(_customHammer);
        piece21.RequiredItems.Add("Tin", 4, true);
        piece21.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece21.Prefab);

        BuildPiece piece22 = new(_fineWoodBundle, "BFP_Lantern1");
        piece22.Crafting.Set(CraftingTable.Workbench);
        piece22.Category.Set(BuildPieceCategory.Misc);
        piece22.Tool.Add(_customHammer);
        piece22.RequiredItems.Add("Tin", 4, true);
        piece22.RequiredItems.Add("Honey", 1, true);
        piece22.RequiredItems.Add("Resin", 1, true);
        piece22.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece22.Prefab);

        BuildPiece piece23 = new(_fineWoodBundle, "BFP_Lantern2");
        piece23.Crafting.Set(CraftingTable.Workbench);
        piece23.Category.Set(BuildPieceCategory.Misc);
        piece23.Tool.Add(_customHammer);
        piece23.RequiredItems.Add("Tin", 4, true);
        piece23.RequiredItems.Add("Honey", 1, true);
        piece23.RequiredItems.Add("Resin", 1, true);
        piece23.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece23.Prefab);

        BuildPiece piece24 = new(_fineWoodBundle, "BFP_Lantern3");
        piece24.Crafting.Set(CraftingTable.Workbench);
        piece24.Category.Set(BuildPieceCategory.Misc);
        piece24.Tool.Add(_customHammer);
        piece24.RequiredItems.Add("Tin", 4, true);
        piece24.RequiredItems.Add("Honey", 1, true);
        piece24.RequiredItems.Add("Resin", 1, true);
        piece24.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece24.Prefab);

        BuildPiece piece25 = new(_fineWoodBundle, "BFP_Lantern4");
        piece25.Crafting.Set(CraftingTable.Workbench);
        piece25.Category.Set(BuildPieceCategory.Misc);
        piece25.Tool.Add(_customHammer);
        piece25.RequiredItems.Add("Tin", 4, true);
        piece25.RequiredItems.Add("Honey", 1, true);
        piece25.RequiredItems.Add("Resin", 1, true);
        piece25.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece25.Prefab);

        BuildPiece piece26 = new(_fineWoodBundle, "BFP_Lantern5");
        piece26.Crafting.Set(CraftingTable.Workbench);
        piece26.Category.Set(BuildPieceCategory.Misc);
        piece26.Tool.Add(_customHammer);
        piece26.RequiredItems.Add("Tin", 4, true);
        piece26.RequiredItems.Add("Honey", 1, true);
        piece26.RequiredItems.Add("Resin", 1, true);
        piece26.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece26.Prefab);

        BuildPiece piece27 = new(_fineWoodBundle, "BFP_Lantern6");
        piece27.Crafting.Set(CraftingTable.Workbench);
        piece27.Category.Set(BuildPieceCategory.Misc);
        piece27.Tool.Add(_customHammer);
        piece27.RequiredItems.Add("Tin", 4, true);
        piece27.RequiredItems.Add("Honey", 1, true);
        piece27.RequiredItems.Add("Resin", 1, true);
        piece27.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece27.Prefab);

        BuildPiece piece28 = new(_fineWoodBundle, "BFP_Lantern7");
        piece28.Crafting.Set(CraftingTable.Workbench);
        piece28.Category.Set(BuildPieceCategory.Misc);
        piece28.Tool.Add(_customHammer);
        piece28.RequiredItems.Add("Tin", 4, true);
        piece28.RequiredItems.Add("Honey", 1, true);
        piece28.RequiredItems.Add("Resin", 1, true);
        piece28.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece28.Prefab);

        BuildPiece piece29 = new(_fineWoodBundle, "BFP_Plant1");
        piece29.Crafting.Set(CraftingTable.Workbench);
        piece29.Category.Set(BuildPieceCategory.Misc);
        piece29.Tool.Add(_customHammer);
        piece29.RequiredItems.Add(_clayMat, 2, true);
        piece29.RequiredItems.Add(_beechMat, 4, true);
        piece29.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece29.Prefab);

        BuildPiece piece30 = new(_fineWoodBundle, "BFP_Plant2");
        piece30.Crafting.Set(CraftingTable.Workbench);
        piece30.Category.Set(BuildPieceCategory.Misc);
        piece30.Tool.Add(_customHammer);
        piece30.RequiredItems.Add(_clayMat, 2, true);
        piece30.RequiredItems.Add(_beechMat, 4, true);
        piece30.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece30.Prefab);

        BuildPiece piece31 = new(_fineWoodBundle, "BFP_Plant3");
        piece31.Crafting.Set(CraftingTable.Workbench);
        piece31.Category.Set(BuildPieceCategory.Misc);
        piece31.Tool.Add(_customHammer);
        piece31.RequiredItems.Add(_clayMat, 2, true);
        piece31.RequiredItems.Add(_beechMat, 4, true);
        piece31.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece31.Prefab);

        BuildPiece piece32 = new(_fineWoodBundle, "BFP_Plant4");
        piece32.Crafting.Set(CraftingTable.Workbench);
        piece32.Category.Set(BuildPieceCategory.Misc);
        piece32.Tool.Add(_customHammer);
        piece32.RequiredItems.Add(_clayMat, 2, true);
        piece32.RequiredItems.Add(_beechMat, 4, true);
        piece32.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece32.Prefab);

        BuildPiece piece33 = new(_fineWoodBundle, "BFP_Plant5");
        piece33.Crafting.Set(CraftingTable.Workbench);
        piece33.Category.Set(BuildPieceCategory.Misc);
        piece33.Tool.Add(_customHammer);
        piece33.RequiredItems.Add(_clayMat, 2, true);
        piece33.RequiredItems.Add(_beechMat, 4, true);
        piece33.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece33.Prefab);

        BuildPiece piece34 = new(_fineWoodBundle, "BFP_Plant6");
        piece34.Crafting.Set(CraftingTable.Workbench);
        piece34.Category.Set(BuildPieceCategory.Misc);
        piece34.Tool.Add(_customHammer);
        piece34.RequiredItems.Add(_clayMat, 2, true);
        piece34.RequiredItems.Add(_beechMat, 4, true);
        piece34.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece34.Prefab);

        BuildPiece piece35 = new(_fineWoodBundle, "BFP_Plant7");
        piece35.Crafting.Set(CraftingTable.Workbench);
        piece35.Category.Set(BuildPieceCategory.Misc);
        piece35.Tool.Add(_customHammer);
        piece35.RequiredItems.Add(_clayMat, 2, true);
        piece35.RequiredItems.Add(_beechMat, 4, true);
        piece35.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece35.Prefab);

        BuildPiece piece36 = new(_fineWoodBundle, "BFP_Plant8");
        piece36.Crafting.Set(CraftingTable.Workbench);
        piece36.Category.Set(BuildPieceCategory.Misc);
        piece36.Tool.Add(_customHammer);
        piece36.RequiredItems.Add(_clayMat, 2, true);
        piece36.RequiredItems.Add(_beechMat, 4, true);
        piece36.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece36.Prefab);

        BuildPiece piece37 = new(_fineWoodBundle, "BFP_Plant9");
        piece37.Crafting.Set(CraftingTable.Workbench);
        piece37.Category.Set(BuildPieceCategory.Misc);
        piece37.Tool.Add(_customHammer);
        piece37.RequiredItems.Add(_clayMat, 2, true);
        piece37.RequiredItems.Add(_beechMat, 4, true);
        piece37.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece37.Prefab);

        BuildPiece piece38 = new(_fineWoodBundle, "BFP_Plant10");
        piece38.Crafting.Set(CraftingTable.Workbench);
        piece38.Category.Set(BuildPieceCategory.Misc);
        piece38.Tool.Add(_customHammer);
        piece38.RequiredItems.Add(_clayMat, 2, true);
        piece38.RequiredItems.Add(_beechMat, 4, true);
        piece38.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece38.Prefab);

        BuildPiece piece39 = new(_fineWoodBundle, "BFP_Plant11");
        piece39.Crafting.Set(CraftingTable.Workbench);
        piece39.Category.Set(BuildPieceCategory.Misc);
        piece39.Tool.Add(_customHammer);
        piece39.RequiredItems.Add(_clayMat, 2, true);
        piece39.RequiredItems.Add(_beechMat, 4, true);
        piece39.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece39.Prefab);

        BuildPiece piece40 = new(_fineWoodBundle, "BFP_Plant12");
        piece40.Crafting.Set(CraftingTable.Workbench);
        piece40.Category.Set(BuildPieceCategory.Misc);
        piece40.Tool.Add(_customHammer);
        piece40.RequiredItems.Add(_clayMat, 2, true);
        piece40.RequiredItems.Add(_beechMat, 4, true);
        piece40.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece40.Prefab);

        BuildPiece piece41 = new(_fineWoodBundle, "BFP_Plant13");
        piece41.Crafting.Set(CraftingTable.Workbench);
        piece41.Category.Set(BuildPieceCategory.Misc);
        piece41.Tool.Add(_customHammer);
        piece41.RequiredItems.Add(_clayMat, 2, true);
        piece41.RequiredItems.Add(_beechMat, 4, true);
        piece41.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece41.Prefab);

        BuildPiece piece42 = new(_fineWoodBundle, "BFP_Plant14");
        piece42.Crafting.Set(CraftingTable.Workbench);
        piece42.Category.Set(BuildPieceCategory.Misc);
        piece42.Tool.Add(_customHammer);
        piece42.RequiredItems.Add(_clayMat, 2, true);
        piece42.RequiredItems.Add(_beechMat, 4, true);
        piece42.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece42.Prefab);

        BuildPiece piece43 = new(_fineWoodBundle, "BFP_Plant15");
        piece43.Crafting.Set(CraftingTable.Workbench);
        piece43.Category.Set(BuildPieceCategory.Misc);
        piece43.Tool.Add(_customHammer);
        piece43.RequiredItems.Add(_clayMat, 2, true);
        piece43.RequiredItems.Add(_beechMat, 4, true);
        piece43.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece43.Prefab);

        BuildPiece piece44 = new(_fineWoodBundle, "BFP_Plant16");
        piece44.Crafting.Set(CraftingTable.Workbench);
        piece44.Category.Set(BuildPieceCategory.Misc);
        piece44.Tool.Add(_customHammer);
        piece44.RequiredItems.Add(_clayMat, 2, true);
        piece44.RequiredItems.Add(_beechMat, 4, true);
        piece44.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece44.Prefab);

        BuildPiece piece45 = new(_fineWoodBundle, "BFP_Plant17");
        piece45.Crafting.Set(CraftingTable.Workbench);
        piece45.Category.Set(BuildPieceCategory.Misc);
        piece45.Tool.Add(_customHammer);
        piece45.RequiredItems.Add(_clayMat, 2, true);
        piece45.RequiredItems.Add(_beechMat, 4, true);
        piece45.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece45.Prefab);

        BuildPiece piece46 = new(_fineWoodBundle, "BFP_Plant18");
        piece46.Crafting.Set(CraftingTable.Workbench);
        piece46.Category.Set(BuildPieceCategory.Misc);
        piece46.Tool.Add(_customHammer);
        piece46.RequiredItems.Add(_clayMat, 2, true);
        piece46.RequiredItems.Add(_beechMat, 4, true);
        piece46.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece46.Prefab);

        BuildPiece piece47 = new(_fineWoodBundle, "BFP_Shelf1");
        piece47.Crafting.Set(CraftingTable.Workbench);
        piece47.Category.Set(BuildPieceCategory.Misc);
        piece47.Tool.Add(_customHammer);
        piece47.RequiredItems.Add(_fineWoodMat, 28, true);
        piece47.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece47.Prefab);

        BuildPiece piece48 = new(_fineWoodBundle, "BFP_Shelf2");
        piece48.Crafting.Set(CraftingTable.Workbench);
        piece48.Category.Set(BuildPieceCategory.Misc);
        piece48.Tool.Add(_customHammer);
        piece48.RequiredItems.Add(_fineWoodMat, 30, true);
        piece48.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece48.Prefab);

        BuildPiece piece49 = new(_fineWoodBundle, "BFP_Shelf3");
        piece49.Crafting.Set(CraftingTable.Workbench);
        piece49.Category.Set(BuildPieceCategory.Misc);
        piece49.Tool.Add(_customHammer);
        piece49.RequiredItems.Add(_fineWoodMat, 36, true);
        piece49.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece49.Prefab);

        BuildPiece piece50 = new(_fineWoodBundle, "BFP_Shelf4");
        piece50.Crafting.Set(CraftingTable.Workbench);
        piece50.Category.Set(BuildPieceCategory.Misc);
        piece50.Tool.Add(_customHammer);
        piece50.RequiredItems.Add(_fineWoodMat, 20, true);
        piece50.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece50.Prefab);

        BuildPiece piece51 = new(_fineWoodBundle, "BFP_Shelf5");
        piece51.Crafting.Set(CraftingTable.Workbench);
        piece51.Category.Set(BuildPieceCategory.Misc);
        piece51.Tool.Add(_customHammer);
        piece51.RequiredItems.Add(_fineWoodMat, 14, true);
        piece51.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece51.Prefab);

        BuildPiece piece52 = new(_fineWoodBundle, "BFP_ShelfClutter");
        piece52.Crafting.Set(CraftingTable.Workbench);
        piece52.Category.Set(BuildPieceCategory.Misc);
        piece52.Tool.Add(_customHammer);
        piece52.RequiredItems.Add(_fineWoodMat, 12, true);
        piece52.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece52.Prefab);

        BuildPiece piece53 = new(_fineWoodBundle, "BFP_StoneLightPost");
        piece53.Crafting.Set(CraftingTable.Workbench);
        piece53.Category.Set(BuildPieceCategory.Misc);
        piece53.Tool.Add(_customHammer);
        piece53.RequiredItems.Add("Stone", 20, true);
        piece53.RequiredItems.Add("Coal", 6, true);
        piece53.RequiredItems.Add("Resin", 10, true);
        piece53.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece53.Prefab);
    }

    private static void WoodPieces()
    {
        BuildPiece piece = new(_fineWoodBundle, "BFP_FineWoodArch");
        piece.Crafting.Set(CraftingTable.Workbench);
        piece.Category.Set(BuildPieceCategory.BuildingWorkbench);
        piece.Tool.Add(_customHammer);
        piece.RequiredItems.Add(_fineWoodMat, 4, true);
        piece.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece.Prefab);

        BuildPiece piece2 = new(_fineWoodBundle, "BFP_FineWoodBeam1x1");
        piece2.Crafting.Set(CraftingTable.Workbench);
        piece2.Category.Set(BuildPieceCategory.BuildingWorkbench);
        piece2.Tool.Add(_customHammer);
        piece2.RequiredItems.Add(_fineWoodMat, 1, true);
        piece2.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece2.Prefab);

        BuildPiece piece3 = new(_fineWoodBundle, "BFP_FineWoodBeam2x2");
        piece3.Crafting.Set(CraftingTable.Workbench);
        piece3.Category.Set(BuildPieceCategory.BuildingWorkbench);
        piece3.Tool.Add(_customHammer);
        piece3.RequiredItems.Add(_fineWoodMat, 2, true);
        piece3.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece3.Prefab);

        BuildPiece piece4 = new(_fineWoodBundle, "BFP_FineWoodBeam26");
        piece4.Crafting.Set(CraftingTable.Workbench);
        piece4.Category.Set(BuildPieceCategory.BuildingWorkbench);
        piece4.Tool.Add(_customHammer);
        piece4.RequiredItems.Add(_fineWoodMat, 2, true);
        piece4.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece4.Prefab);

        BuildPiece piece5 = new(_fineWoodBundle, "BFP_FineWoodBeam45");
        piece5.Crafting.Set(CraftingTable.Workbench);
        piece5.Category.Set(BuildPieceCategory.BuildingWorkbench);
        piece5.Tool.Add(_customHammer);
        piece5.RequiredItems.Add(_fineWoodMat, 2, true);
        piece5.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece5.Prefab);

        BuildPiece piece6 = new(_fineWoodBundle, "BFP_FineWoodDecoWall");
        piece6.Crafting.Set(CraftingTable.Workbench);
        piece6.Category.Set(BuildPieceCategory.BuildingWorkbench);
        piece6.Tool.Add(_customHammer);
        piece6.RequiredItems.Add(_fineWoodMat, 2, true);
        piece6.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece6.Prefab);

        BuildPiece piece7 = new(_fineWoodBundle, "BFP_FineWoodDoor");
        piece7.Crafting.Set(CraftingTable.Workbench);
        piece7.Category.Set(BuildPieceCategory.BuildingWorkbench);
        piece7.Tool.Add(_customHammer);
        piece7.RequiredItems.Add(_fineWoodMat, 6, true);
        piece7.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece7.Prefab);

        BuildPiece piece8 = new(_fineWoodBundle, "BFP_FineWoodFloor1x1");
        piece8.Crafting.Set(CraftingTable.Workbench);
        piece8.Category.Set(BuildPieceCategory.BuildingWorkbench);
        piece8.Tool.Add(_customHammer);
        piece8.RequiredItems.Add(_fineWoodMat, 1, true);
        piece8.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece8.Prefab);

        BuildPiece piece9 = new(_fineWoodBundle, "BFP_FineWoodFloor2x2");
        piece9.Crafting.Set(CraftingTable.Workbench);
        piece9.Category.Set(BuildPieceCategory.BuildingWorkbench);
        piece9.Tool.Add(_customHammer);
        piece9.RequiredItems.Add(_fineWoodMat, 2, true);
        piece9.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece9.Prefab);

        BuildPiece piece10 = new(_fineWoodBundle, "BFP_FineWoodGate");
        piece10.Crafting.Set(CraftingTable.Workbench);
        piece10.Category.Set(BuildPieceCategory.BuildingWorkbench);
        piece10.Tool.Add(_customHammer);
        piece10.RequiredItems.Add(_fineWoodMat, 12, true);
        piece10.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece10.Prefab);

        BuildPiece piece11 = new(_fineWoodBundle, "BFP_FineWoodHalfWall");
        piece11.Crafting.Set(CraftingTable.Workbench);
        piece11.Category.Set(BuildPieceCategory.BuildingWorkbench);
        piece11.Tool.Add(_customHammer);
        piece11.RequiredItems.Add(_fineWoodMat, 2, true);
        piece11.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece11.Prefab);

        BuildPiece piece12 = new(_fineWoodBundle, "BFP_FineWoodLedge");
        piece12.Crafting.Set(CraftingTable.Workbench);
        piece12.Category.Set(BuildPieceCategory.BuildingWorkbench);
        piece12.Tool.Add(_customHammer);
        piece12.RequiredItems.Add(_fineWoodMat, 1, true);
        piece12.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece12.Prefab);

        BuildPiece piece13 = new(_fineWoodBundle, "BFP_FineWoodPole1x1");
        piece13.Crafting.Set(CraftingTable.Workbench);
        piece13.Category.Set(BuildPieceCategory.BuildingWorkbench);
        piece13.Tool.Add(_customHammer);
        piece13.RequiredItems.Add(_fineWoodMat, 1, true);
        piece13.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece13.Prefab);

        BuildPiece piece14 = new(_fineWoodBundle, "BFP_FineWoodPole2x2");
        piece14.Crafting.Set(CraftingTable.Workbench);
        piece14.Category.Set(BuildPieceCategory.BuildingWorkbench);
        piece14.Tool.Add(_customHammer);
        piece14.RequiredItems.Add(_fineWoodMat, 2, true);
        piece14.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece14.Prefab);

        BuildPiece piece15 = new(_fineWoodBundle, "BFP_FineWoodQuarterWall");
        piece15.Crafting.Set(CraftingTable.Workbench);
        piece15.Category.Set(BuildPieceCategory.BuildingWorkbench);
        piece15.Tool.Add(_customHammer);
        piece15.RequiredItems.Add(_fineWoodMat, 1, true);
        piece15.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece15.Prefab);

        BuildPiece piece16 = new(_fineWoodBundle, "BFP_FineWoodRoof26");
        piece16.Crafting.Set(CraftingTable.Workbench);
        piece16.Category.Set(BuildPieceCategory.BuildingWorkbench);
        piece16.Tool.Add(_customHammer);
        piece16.RequiredItems.Add(_fineWoodMat, 2, true);
        piece16.RequiredItems.Add(_strawMat, 6, true);
        piece16.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece16.Prefab);

        BuildPiece piece17 = new(_fineWoodBundle, "BFP_FineWoodRoof45");
        piece17.Crafting.Set(CraftingTable.Workbench);
        piece17.Category.Set(BuildPieceCategory.BuildingWorkbench);
        piece17.Tool.Add(_customHammer);
        piece17.RequiredItems.Add(_fineWoodMat, 2, true);
        piece17.RequiredItems.Add(_strawMat, 6, true);
        piece17.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece17.Prefab);

        BuildPiece piece18 = new(_fineWoodBundle, "BFP_FineWoodRoofCross26");
        piece18.Crafting.Set(CraftingTable.Workbench);
        piece18.Category.Set(BuildPieceCategory.BuildingWorkbench);
        piece18.Tool.Add(_customHammer);
        piece18.RequiredItems.Add(_fineWoodMat, 2, true);
        piece18.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece18.Prefab);

        BuildPiece piece19 = new(_fineWoodBundle, "BFP_FineWoodRoofCross45");
        piece19.Crafting.Set(CraftingTable.Workbench);
        piece19.Category.Set(BuildPieceCategory.BuildingWorkbench);
        piece19.Tool.Add(_customHammer);
        piece19.RequiredItems.Add(_fineWoodMat, 2, true);
        piece19.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece19.Prefab);

        BuildPiece piece20 = new(_fineWoodBundle, "BFP_FineWoodRoofICorner26");
        piece20.Crafting.Set(CraftingTable.Workbench);
        piece20.Category.Set(BuildPieceCategory.BuildingWorkbench);
        piece20.Tool.Add(_customHammer);
        piece20.RequiredItems.Add(_fineWoodMat, 2, true);
        piece20.RequiredItems.Add(_strawMat, 6, true);
        piece20.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece20.Prefab);

        BuildPiece piece21 = new(_fineWoodBundle, "BFP_FineWoodRoofICorner45");
        piece21.Crafting.Set(CraftingTable.Workbench);
        piece21.Category.Set(BuildPieceCategory.BuildingWorkbench);
        piece21.Tool.Add(_customHammer);
        piece21.RequiredItems.Add(_fineWoodMat, 2, true);
        piece21.RequiredItems.Add(_strawMat, 6, true);
        piece21.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece21.Prefab);

        BuildPiece piece22 = new(_fineWoodBundle, "BFP_FineWoodRoofOCorner26");
        piece22.Crafting.Set(CraftingTable.Workbench);
        piece22.Category.Set(BuildPieceCategory.BuildingWorkbench);
        piece22.Tool.Add(_customHammer);
        piece22.RequiredItems.Add(_fineWoodMat, 2, true);
        piece22.RequiredItems.Add(_strawMat, 6, true);
        piece22.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece22.Prefab);

        BuildPiece piece23 = new(_fineWoodBundle, "BFP_FineWoodRoofOCorner45");
        piece23.Crafting.Set(CraftingTable.Workbench);
        piece23.Category.Set(BuildPieceCategory.BuildingWorkbench);
        piece23.Tool.Add(_customHammer);
        piece23.RequiredItems.Add(_fineWoodMat, 2, true);
        piece23.RequiredItems.Add(_strawMat, 6, true);
        ShaderReplacer.Replace(piece23.Prefab);

        BuildPiece piece24 = new(_fineWoodBundle, "BFP_FineWoodRoofTop26");
        piece24.Crafting.Set(CraftingTable.Workbench);
        piece24.Category.Set(BuildPieceCategory.BuildingWorkbench);
        piece24.Tool.Add(_customHammer);
        piece24.RequiredItems.Add(_fineWoodMat, 1, true);
        piece24.RequiredItems.Add(_strawMat, 4, true);
        piece24.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece24.Prefab);

        BuildPiece piece25 = new(_fineWoodBundle, "BFP_FineWoodRoofTop45");
        piece25.Crafting.Set(CraftingTable.Workbench);
        piece25.Category.Set(BuildPieceCategory.BuildingWorkbench);
        piece25.Tool.Add(_customHammer);
        piece25.RequiredItems.Add(_fineWoodMat, 1, true);
        piece25.RequiredItems.Add(_strawMat, 4, true);
        piece25.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece25.Prefab);

        BuildPiece piece26 = new(_fineWoodBundle, "BFP_FineWoodStair");
        piece26.Crafting.Set(CraftingTable.Workbench);
        piece26.Category.Set(BuildPieceCategory.BuildingWorkbench);
        piece26.Tool.Add(_customHammer);
        piece26.RequiredItems.Add(_fineWoodMat, 4, true);
        piece26.RequiredItems.Add(_bronzeNailsMat, 2, true);
        piece26.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece26.Prefab);

        BuildPiece piece27 = new(_fineWoodBundle, "BFP_FineWoodStepLadder");
        piece27.Crafting.Set(CraftingTable.Workbench);
        piece27.Category.Set(BuildPieceCategory.BuildingWorkbench);
        piece27.Tool.Add(_customHammer);
        piece27.RequiredItems.Add(_fineWoodMat, 3, true);
        piece27.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece27.Prefab);

        BuildPiece piece28 = new(_fineWoodBundle, "BFP_FineWoodWall");
        piece28.Crafting.Set(CraftingTable.Workbench);
        piece28.Category.Set(BuildPieceCategory.BuildingWorkbench);
        piece28.Tool.Add(_customHammer);
        piece28.RequiredItems.Add(_fineWoodMat, 4, true);
        piece28.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece28.Prefab);

        BuildPiece piece29 = new(_fineWoodBundle, "BFP_FineWoodWallRoof26");
        piece29.Crafting.Set(CraftingTable.Workbench);
        piece29.Category.Set(BuildPieceCategory.BuildingWorkbench);
        piece29.Tool.Add(_customHammer);
        piece29.RequiredItems.Add(_fineWoodMat, 2, true);
        piece29.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece29.Prefab);

        BuildPiece piece30 = new(_fineWoodBundle, "BFP_FineWoodWallRoof26_UpsideDown");
        piece30.Crafting.Set(CraftingTable.Workbench);
        piece30.Category.Set(BuildPieceCategory.BuildingWorkbench);
        piece30.Tool.Add(_customHammer);
        piece30.RequiredItems.Add(_fineWoodMat, 2, true);
        piece30.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece30.Prefab);

        BuildPiece piece31 = new(_fineWoodBundle, "BFP_FineWoodWallRoof45");
        piece31.Crafting.Set(CraftingTable.Workbench);
        piece31.Category.Set(BuildPieceCategory.BuildingWorkbench);
        piece31.Tool.Add(_customHammer);
        piece31.RequiredItems.Add(_fineWoodMat, 2, true);
        piece31.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece31.Prefab);

        BuildPiece piece32 = new(_fineWoodBundle, "BFP_FineWoodWallRoof45_UpsideDown");
        piece32.Crafting.Set(CraftingTable.Workbench);
        piece32.Category.Set(BuildPieceCategory.BuildingWorkbench);
        piece32.Tool.Add(_customHammer);
        piece32.RequiredItems.Add(_fineWoodMat, 2, true);
        piece32.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece32.Prefab);

        BuildPiece piece33 = new(_fineWoodBundle, "BFP_FineWoodWindowShutter");
        piece33.Crafting.Set(CraftingTable.Workbench);
        piece33.Category.Set(BuildPieceCategory.BuildingWorkbench);
        piece33.Tool.Add(_customHammer);
        piece33.RequiredItems.Add(_fineWoodMat, 2, true);
        piece33.RequiredItems.Add(_bronzeNailsMat, 1, true);
        piece33.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece33.Prefab);

        BuildPiece piece34 = new(_fineWoodBundle, "BFP_GlassWindow1");
        piece34.Crafting.Set(CraftingTable.Workbench);
        piece34.Category.Set(BuildPieceCategory.BuildingWorkbench);
        piece34.Tool.Add(_customHammer);
        piece34.RequiredItems.Add(_fineWoodMat, 4, true);
        piece34.RequiredItems.Add("Crystal", 4, true);
        piece34.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece34.Prefab);

        BuildPiece piece35 = new(_fineWoodBundle, "BFP_GlassWindow3");
        piece35.Crafting.Set(CraftingTable.Workbench);
        piece35.Category.Set(BuildPieceCategory.BuildingWorkbench);
        piece35.Tool.Add(_customHammer);
        piece35.RequiredItems.Add(_fineWoodMat, 2, true);
        piece35.RequiredItems.Add("Crystal", 2, true);
        piece35.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece35.Prefab);

        BuildPiece piece36 = new(_fineWoodBundle, "BFP_HeavyGate");
        piece36.Crafting.Set(CraftingTable.Workbench);
        piece36.Category.Set(BuildPieceCategory.BuildingWorkbench);
        piece36.Tool.Add(_customHammer);
        piece36.RequiredItems.Add(_fineWoodMat, 12, true);
        piece36.RequiredItems.Add("RoundLog", 4, true);
        piece36.RequiredItems.Add("Bronze", 6, true);
        piece36.RequiredItems.Add(_bronzeNailsMat, 10, true);
        piece36.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece36.Prefab);

        BuildPiece piece37 = new(_fineWoodBundle, "BFP_HorizontalDecoWall");
        piece37.Crafting.Set(CraftingTable.Workbench);
        piece37.Category.Set(BuildPieceCategory.BuildingWorkbench);
        piece37.Tool.Add(_customHammer);
        piece37.RequiredItems.Add(_fineWoodMat, 2, true);
        piece37.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece37.Prefab);

        BuildPiece piece38 = new(_fineWoodBundle, "BFP_StepLadder1");
        piece38.Crafting.Set(CraftingTable.Workbench);
        piece38.Category.Set(BuildPieceCategory.BuildingWorkbench);
        piece38.Tool.Add(_customHammer);
        piece38.RequiredItems.Add(_fineWoodMat, 6, true);
        piece38.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece38.Prefab);

        BuildPiece piece39 = new(_fineWoodBundle, "BFP_StepLadder2");
        piece39.Crafting.Set(CraftingTable.Workbench);
        piece39.Category.Set(BuildPieceCategory.BuildingWorkbench);
        piece39.Tool.Add(_customHammer);
        piece39.RequiredItems.Add(_fineWoodMat, 16, true);
        piece39.RequiredItems.Add(_bronzeNailsMat, 4, true);
        piece39.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece39.Prefab);

        BuildPiece piece40 = new(_fineWoodBundle, "BFP_ThatchHalfWall");
        piece40.Crafting.Set(CraftingTable.Workbench);
        piece40.Category.Set(BuildPieceCategory.BuildingWorkbench);
        piece40.RequiredItems.Add(_fineWoodMat, 2, true);
        piece40.RequiredItems.Add(_strawMat, 4, true);
        piece40.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece40.Prefab);

        BuildPiece piece41 = new(_fineWoodBundle, "BFP_ThatchQuarterWall");
        piece41.Crafting.Set(CraftingTable.Workbench);
        piece41.Category.Set(BuildPieceCategory.BuildingWorkbench);
        piece41.RequiredItems.Add(_fineWoodMat, 1, true);
        piece41.RequiredItems.Add(_strawMat, 2, true);
        piece41.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece41.Prefab);

        BuildPiece piece42 = new(_fineWoodBundle, "BFP_ThatchWall");
        piece42.Crafting.Set(CraftingTable.Workbench);
        piece42.Category.Set(BuildPieceCategory.BuildingWorkbench);
        piece42.RequiredItems.Add(_fineWoodMat, 4, true);
        piece42.RequiredItems.Add(_strawMat, 8, true);
        piece42.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece42.Prefab);

        BuildPiece piece43 = new(_fineWoodBundle, "BFP_ThatchWindow");
        piece43.Crafting.Set(CraftingTable.Workbench);
        piece43.Category.Set(BuildPieceCategory.BuildingWorkbench);
        piece43.RequiredItems.Add(_fineWoodMat, 5, true);
        piece43.RequiredItems.Add(_strawMat, 6, true);
        piece43.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece43.Prefab);

        BuildPiece piece44 = new(_fineWoodBundle, "BFP_ThatchWindow_Half");
        piece44.Crafting.Set(CraftingTable.Workbench);
        piece44.Category.Set(BuildPieceCategory.BuildingWorkbench);
        piece44.RequiredItems.Add(_fineWoodMat, 3, true);
        piece44.RequiredItems.Add(_strawMat, 5, true);
        piece44.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece44.Prefab);

        BuildPiece piece45 = new(_fineWoodBundle, "BFP_ThatchWindow_Quarter");
        piece45.Crafting.Set(CraftingTable.Workbench);
        piece45.Category.Set(BuildPieceCategory.BuildingWorkbench);
        piece45.RequiredItems.Add(_fineWoodMat, 2, true);
        piece45.RequiredItems.Add(_strawMat, 3, true);
        piece45.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece45.Prefab);

        BuildPiece piece46 = new(_fineWoodBundle, "BFP_TrapDoor");
        piece46.Crafting.Set(CraftingTable.Workbench);
        piece46.Category.Set(BuildPieceCategory.BuildingWorkbench);
        piece46.Tool.Add(_customHammer);
        piece46.RequiredItems.Add(_fineWoodMat, 6, true);
        piece46.RequiredItems.Add(_bronzeNailsMat, 2, true);
        piece46.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece46.Prefab);
        if (!piece46.Prefab.GetComponent<TrapDoor>())
        {
            Object.Destroy(piece46.Prefab.GetComponent<Door>());
            piece46.Prefab.AddComponent<TrapDoor>();
        }

        BuildPiece piece47 = new(_fineWoodBundle, "BFP_Window");
        piece47.Crafting.Set(CraftingTable.Workbench);
        piece47.Category.Set(BuildPieceCategory.BuildingWorkbench);
        piece47.Tool.Add(_customHammer);
        piece47.RequiredItems.Add(_fineWoodMat, 6, true);
        piece47.RequiredItems.Add(_bronzeNailsMat, 2, true);
        piece47.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece47.Prefab);

        BuildPiece piece48 = new(_fineWoodBundle, "BFP_Window_Half");
        piece48.Crafting.Set(CraftingTable.Workbench);
        piece48.Category.Set(BuildPieceCategory.BuildingWorkbench);
        piece48.Tool.Add(_customHammer);
        piece48.RequiredItems.Add(_fineWoodMat, 3, true);
        piece48.RequiredItems.Add(_bronzeNailsMat, 2, true);
        piece48.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece48.Prefab);

        BuildPiece piece49 = new(_fineWoodBundle, "BFP_Window_Quarter");
        piece49.Crafting.Set(CraftingTable.Workbench);
        piece49.Category.Set(BuildPieceCategory.BuildingWorkbench);
        piece49.Tool.Add(_customHammer);
        piece49.RequiredItems.Add(_fineWoodMat, 2, true);
        piece49.RequiredItems.Add(_bronzeNailsMat, 2, true);
        piece49.SpecialProperties = new SpecialProperties() { AdminOnly = false, NoConfig = false };
        ShaderReplacer.Replace(piece49.Prefab);
    }

    private static void Effects()
    {
        PiecePrefabManager.RegisterPrefab(_fineWoodBundle, "BFP_FineHammerPieceTable");
        PiecePrefabManager.RegisterPrefab(_fineWoodBundle, "bcp_fx_refinery_destroyed");
        PiecePrefabManager.RegisterPrefab(_fineWoodBundle, "bcp_sfx_darkwood_door_close");
        PiecePrefabManager.RegisterPrefab(_fineWoodBundle, "bcp_sfx_darkwood_door_open");
        PiecePrefabManager.RegisterPrefab(_fineWoodBundle, "bfp_fx_ArmorStand_pick");
        PiecePrefabManager.RegisterPrefab(_fineWoodBundle, "bfp_sfx_barley_hit");
        PiecePrefabManager.RegisterPrefab(_fineWoodBundle, "bfp_sfx_build_hammer_default");
        PiecePrefabManager.RegisterPrefab(_fineWoodBundle, "bfp_sfx_build_hammer_stone");
        PiecePrefabManager.RegisterPrefab(_fineWoodBundle, "bfp_sfx_build_hammer_wood");
        PiecePrefabManager.RegisterPrefab(_fineWoodBundle, "bfp_sfx_chest_close");
        PiecePrefabManager.RegisterPrefab(_fineWoodBundle, "bfp_sfx_chest_open");
        PiecePrefabManager.RegisterPrefab(_fineWoodBundle, "bfp_sfx_door_close");
        PiecePrefabManager.RegisterPrefab(_fineWoodBundle, "bfp_sfx_door_open");
        PiecePrefabManager.RegisterPrefab(_fineWoodBundle, "bfp_sfx_FireAddFuel");
        PiecePrefabManager.RegisterPrefab(_fineWoodBundle, "bfp_sfx_pickable_pick");
        PiecePrefabManager.RegisterPrefab(_fineWoodBundle, "bfp_sfx_rock_destroyed");
        PiecePrefabManager.RegisterPrefab(_fineWoodBundle, "bfp_sfx_rock_hit");
        PiecePrefabManager.RegisterPrefab(_fineWoodBundle, "bfp_sfx_window_open");
        PiecePrefabManager.RegisterPrefab(_fineWoodBundle, "bfp_sfx_windows_close");
        PiecePrefabManager.RegisterPrefab(_fineWoodBundle, "bfp_sfx_wood_destroyed");
        PiecePrefabManager.RegisterPrefab(_fineWoodBundle, "bfp_vfx_barley_destroyed");
        PiecePrefabManager.RegisterPrefab(_fineWoodBundle, "bfp_vfx_dvergpost_destroyed");
        PiecePrefabManager.RegisterPrefab(_fineWoodBundle, "bfp_vfx_FireAddFuel");
        PiecePrefabManager.RegisterPrefab(_fineWoodBundle, "bfp_vfx_MarbleDestroyed");
        PiecePrefabManager.RegisterPrefab(_fineWoodBundle, "bfp_vfx_MarbleHit");
        PiecePrefabManager.RegisterPrefab(_fineWoodBundle, "bfp_vfx_pickable_pick");
        PiecePrefabManager.RegisterPrefab(_fineWoodBundle, "bfp_vfx_Place_bed");
        PiecePrefabManager.RegisterPrefab(_fineWoodBundle, "bfp_vfx_Place_chest");
        PiecePrefabManager.RegisterPrefab(_fineWoodBundle, "bfp_vfx_Place_stone_floor");
        PiecePrefabManager.RegisterPrefab(_fineWoodBundle, "bfp_vfx_Place_stone_wall_2x1");
        PiecePrefabManager.RegisterPrefab(_fineWoodBundle, "bfp_vfx_Place_wood_beam");
        PiecePrefabManager.RegisterPrefab(_fineWoodBundle, "bfp_vfx_Place_wood_floor");
        PiecePrefabManager.RegisterPrefab(_fineWoodBundle, "bfp_vfx_Place_wood_pole");
        PiecePrefabManager.RegisterPrefab(_fineWoodBundle, "bfp_vfx_Place_wood_roof");
        PiecePrefabManager.RegisterPrefab(_fineWoodBundle, "bfp_vfx_Place_wood_stair");
        PiecePrefabManager.RegisterPrefab(_fineWoodBundle, "bfp_vfx_Place_wood_wall");
        PiecePrefabManager.RegisterPrefab(_fineWoodBundle, "bfp_vfx_Place_wood_wall_half");
        PiecePrefabManager.RegisterPrefab(_fineWoodBundle, "bfp_vfx_Place_workbench");
        PiecePrefabManager.RegisterPrefab(_fineWoodBundle, "bfp_vfx_SawDust");
    }
}