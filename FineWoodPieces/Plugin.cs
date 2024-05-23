using System;
using System.IO;
using System.Reflection;
using BepInEx;
using BepInEx.Configuration;
using ClayBuildPieces.Functions;
using FineWoodPieces.Functions;
using HarmonyLib;
using LocalizationManager;
using ServerSync;

namespace FineWoodPieces
{
    [BepInPlugin(modGUID, modName, modVersion)]
    [BepInIncompatibility("blacks7ar.ClayBuildPieces")]
    [BepInIncompatibility("blacks7ar.FineWoodBuildPieces")]
    [BepInIncompatibility("blacks7ar.FineWoodFurnitures")]
    
    public class Plugin : BaseUnityPlugin
    {
        private const string modGUID = "blacks7ar.FineWoodPieces";
        public const string modName = "FineWoodPieces";
        public const string modAuthor = "blacks7ar";
        public const string modVersion = "1.5.5";
        public const string modLink = "https://valheim.thunderstore.io/package/blacks7ar/FineWoodPieces/";
        private static string configFileName = modGUID + ".cfg";
        private static string configFileFullPath = Paths.ConfigPath + Path.DirectorySeparatorChar + configFileName;
        private static readonly Harmony _harmony = new(modGUID);

        private static readonly ConfigSync _configSync = new(modGUID)
        {
            DisplayName = modName,
            CurrentVersion = modVersion,
            MinimumRequiredVersion = modVersion
        };
        
        private static ConfigEntry<Toggle> _serverConfigLocked;
        public static ConfigEntry<Toggle> _enableReed;
        public static ConfigEntry<float> _reedGroupRadius;
        public static ConfigEntry<int> _reedGroupSizeMin;
        public static ConfigEntry<int> _reedGroupSizeMax;
        public static ConfigEntry<float> _reedMax;
        public static ConfigEntry<Toggle> _enableClay;
        public static ConfigEntry<float> _clayGroupRadius;
        public static ConfigEntry<int> _clayGroupSizeMin;
        public static ConfigEntry<int> _clayGroupSizeMax;
        public static ConfigEntry<float> _clayMax;
        public static ConfigEntry<Toggle> _enableClayBig;
        public static ConfigEntry<float> _clayBigGroupRadius;
        public static ConfigEntry<int> _clayBigGroupSizeMin;
        public static ConfigEntry<int> _clayBigGroupSizeMax;
        public static ConfigEntry<float> _clayBigMax;
        public static ConfigEntry<float> _secPerUnit;
        public static ConfigEntry<int> _maxClay;
        public static ConfigEntry<Heightmap.Biome> _clayPit1Biome;
        public static ConfigEntry<Heightmap.BiomeArea> _clayPit1BiomeArea;
        public static ConfigEntry<float> _clayPit1MinDistance;
        public static ConfigEntry<int> _clayPit1Count;
        public static ConfigEntry<Heightmap.Biome> _clayPit2Biome;
        public static ConfigEntry<Heightmap.BiomeArea> _clayPit2BiomeArea;
        public static ConfigEntry<float> _clayPit2MinDistance;
        public static ConfigEntry<int> _clayPit2Count;
        public static ConfigEntry<Toggle> _hideTrapDoorHoverText;
        
        private ConfigEntry<T> config<T>(string group, string name, T value, ConfigDescription description,
            bool synchronizedConfig = true)
        {
            var configDescription =
                new ConfigDescription(
                    description.Description +
                    (synchronizedConfig ? " [Synced with Server]" : " [Not Synced with Server]"),
                    description.AcceptableValues, description.Tags);
            var configEntry = Config.Bind(group, name, value, configDescription);
            var syncedConfigEntry = _configSync.AddConfigEntry(configEntry);
            syncedConfigEntry.SynchronizedConfig = synchronizedConfig;
            return configEntry;
        }

        /*private void ConfigWatcher()
        {
            var watcher = new FileSystemWatcher(Paths.ConfigPath, configFileName);
            watcher.Changed += OnConfigChanged;
            watcher.Created += OnConfigChanged;
            watcher.Renamed += OnConfigChanged;
            watcher.IncludeSubdirectories = true;
            watcher.SynchronizingObject = ThreadingHelper.SynchronizingObject;
            watcher.EnableRaisingEvents = true;
        }

        private void OnConfigChanged(object sender, FileSystemEventArgs e)
        {
            if (!File.Exists(configFileFullPath)) return;
            try
            {
                Logging.LogDebug("OnConfigChanged called..");
                Config.Reload();
            }
            catch
            {
                Logging.LogError($"There was an issue loading your {configFileName}");
                Logging.LogError("Please check your config entries for spelling and format!");
            }
        }*/

        public void Awake()
        {
            Localizer.Load();
            _serverConfigLocked = config("1- ServerSync", "Lock Configuration", Toggle.On,
                new ConfigDescription("If On, the configuration is locked and can be changed by server admins only."));
            _configSync.AddLockingConfigEntry(_serverConfigLocked);
            _hideTrapDoorHoverText = config("8- TrapDoor", "Hide HoverText", Toggle.On,
                new ConfigDescription("If On, trap doors hover text and interact prompt will be hidden."));
            _enableReed = config("2- Reed", "Enable", Toggle.On,
                new ConfigDescription("If On, harvestable reeds will spawn across meadows and black forest biomes."));
            _reedGroupRadius = config("2- Reed", "Group Radius", 4f,
                new ConfigDescription("Group radius.", new AcceptableValueRange<float>(1f, 50f)));
            _reedGroupSizeMin = config("2- Reed", "Group Size Min", 4,
                new ConfigDescription("Minimum group size.", new AcceptableValueRange<int>(1, 20)));
            _reedGroupSizeMax = config("2- Reed", "Group Size Max", 8,
                new ConfigDescription("Maximum group size.", new AcceptableValueRange<int>(1, 20)));
            _reedMax = config("2- Reed", "Max", 10f,
                new ConfigDescription("Maximum amount per zone.", new AcceptableValueRange<float>(1f, 20f)));
            _enableClay = config("3- Clay-Pickable", "Enable", Toggle.On,
                new ConfigDescription("If On, pickable clays will spawn to all biomes except ashlands and deepnorth."));
            _clayGroupRadius = config("3- Clay-Pickable", "Group Radius", 2f,
                new ConfigDescription("Group radius.", new AcceptableValueRange<float>(1f, 50f)));
            _clayGroupSizeMin = config("3- Clay-Pickable", "Group Size Min", 2,
                new ConfigDescription("Minimum group size.", new AcceptableValueRange<int>(1, 20)));
            _clayGroupSizeMax = config("3- Clay-Pickable", "Group Size Max", 6,
                new ConfigDescription("Maximum group size.", new AcceptableValueRange<int>(1, 20)));
            _clayMax = config("3- Clay-Pickable", "Max", 20f,
                new ConfigDescription("Maximum amount per zone.", new AcceptableValueRange<float>(1f, 20f)));
            _enableClayBig = config("4- Clay-Cluster", "Enable", Toggle.On,
                new ConfigDescription(
                    "If On, a giant cluster of clays will spawn to all biomes except ashlands and deepnorth."));
            _clayBigGroupRadius = config("4- Clay-Cluster", "Group Radius", 20f,
                new ConfigDescription("Group radius.", new AcceptableValueRange<float>(1f, 50f)));
            _clayBigGroupSizeMin = config("4- Clay-Cluster", "Group Size Min", 1,
                new ConfigDescription("Minimum group size.", new AcceptableValueRange<int>(1, 20)));
            _clayBigGroupSizeMax = config("4- Clay-Cluster", "Group Size Max", 1,
                new ConfigDescription("Maximum group size.", new AcceptableValueRange<int>(1, 20)));
            _clayBigMax = config("4- Clay-Cluster", "Max", 5f,
                new ConfigDescription("Maximum amount per zone.", new AcceptableValueRange<float>(1f, 20f)));
            _secPerUnit = config("5- Collector", "Duration", 120f,
                new ConfigDescription("How long does the collector would take to collect clays from pits in seconds.",
                    new AcceptableValueRange<float>(30f, 300f)));
            _maxClay = config("5- Collector", "Max Capacity", 10,
                new ConfigDescription("Maximum Capacity.", new AcceptableValueRange<int>(1, 50)));
            _clayPit1Biome = config("7- ClayPit-NeckSpawn", "Biome", Heightmap.Biome.Meadows,
                new ConfigDescription("Biome to spawn the clay pit location."));
            _clayPit1BiomeArea = config("7- ClayPit-NeckSpawn", "Biome Area", Heightmap.BiomeArea.Everything,
                new ConfigDescription("Biome area."));
            _clayPit1MinDistance = config("7- ClayPit-NeckSpawn", "Minimum Distance", 128f,
                new ConfigDescription("Minimum distance to group.", new AcceptableValueRange<float>(1f, 500f)));
            _clayPit1Count = config("7- ClayPit-NeckSpawn", "Max Count", 100,
                new ConfigDescription("Maximum count to try to spawn.", new AcceptableValueRange<int>(1, 200)));
            _clayPit2Biome = config("6- ClayPit-BoarSpawn", "Biome", Heightmap.Biome.Meadows,
                new ConfigDescription("Biome to spawn the clay pit location."));
            _clayPit2BiomeArea = config("6- ClayPit-BoarSpawn", "Biome Area", Heightmap.BiomeArea.Everything,
                new ConfigDescription("Biome area."));
            _clayPit2MinDistance = config("6- ClayPit-BoarSpawn", "Minimum Distance", 128f,
                new ConfigDescription("Minimum distance to group.", new AcceptableValueRange<float>(1f, 500f)));
            _clayPit2Count = config("6- ClayPit-BoarSpawn", "Max Count", 100,
                new ConfigDescription("Maximum count to try to spawn.", new AcceptableValueRange<int>(1, 200)));
            var assembly = Assembly.GetExecutingAssembly();
            PrefabsSetup.Init();
            ClayPitSetup.Init();
            _harmony.PatchAll(assembly);
            //ConfigWatcher();
        }
        
        private void OnDestroy()
        {
            Config.Save();
        }
    }
}