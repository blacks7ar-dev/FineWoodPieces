using FineWoodPieces;
using FineWoodPieces.Functions;
using LocationManager;

namespace ClayBuildPieces.Functions;

public static class ClayPitSetup
{
    public static void Init()
    {
        LocationManager.Location.ConfigurationEnabled = false;
        LocationManager.Location location = new(PrefabsSetup._clayPit1)
        {
            Biome = Plugin._clayPit1Biome.Value,
            SpawnAltitude = new Range(1f, 60f),
            SpawnDistance = new Range(100f, 7000f),
            HeightDelta = new Range(0f, 2f),
            SpawnArea = Plugin._clayPit1BiomeArea.Value,
            Rotation = Rotation.Random,
            CanSpawn = true,
            GroupName = "claypit",
            MinimumDistanceFromGroup = Plugin._clayPit1MinDistance.Value,
            Count = Plugin._clayPit1Count.Value,
            ForestThreshold = new Range(0, 1.1f)
        };
        location.CreatureSpawner.Add("neck_spawner_1", "Neck");
        location.CreatureSpawner.Add("neck_spawner_2", "Neck");
        location.CreatureSpawner.Add("neck_spawner_3", "Neck");
        location.CreatureSpawner.Add("neck_spawner_4", "Neck");
        location.CreatureSpawner.Add("neck_spawner_5", "Neck");
        location.CreatureSpawner.Add("neck_spawner_6", "Neck");
        location.CreatureSpawner.Add("neck_spawner_7", "Neck");
        location.CreatureSpawner.Add("neck_respawner_1", "Neck");
        location.CreatureSpawner.Add("neck_respawner_2", "Neck");
        LocationManager.Location location2 = new(PrefabsSetup._clayPit2)
        {
            Biome = Plugin._clayPit2Biome.Value,
            SpawnAltitude = new Range(1f, 60f),
            SpawnDistance = new Range(100f, 7000f),
            HeightDelta = new Range(0f, 2f),
            SpawnArea = Plugin._clayPit2BiomeArea.Value,
            Rotation = Rotation.Random,
            CanSpawn = true,
            GroupName = "claypit",
            MinimumDistanceFromGroup = Plugin._clayPit2MinDistance.Value,
            Count = Plugin._clayPit2Count.Value,
            ForestThreshold = new Range(0, 1.1f)
        };
        location2.CreatureSpawner.Add("boar_spawner_1", "Boar");
        location2.CreatureSpawner.Add("boar_spawner_2", "Boar");
        location2.CreatureSpawner.Add("boar_spawner_3", "Boar");
        location2.CreatureSpawner.Add("boar_spawner_4", "Boar");
        location2.CreatureSpawner.Add("boar_spawner_5", "Boar");
        location2.CreatureSpawner.Add("boar_spawner_6", "Boar");
        location2.CreatureSpawner.Add("boar_spawner_7", "Boar");
        location2.CreatureSpawner.Add("boar_respawner_1", "Boar");
        location2.CreatureSpawner.Add("boar_respawner_2", "Boar");
    }
}