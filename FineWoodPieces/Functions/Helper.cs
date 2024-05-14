namespace ClayBuildPieces.Functions;

public static class Helper
{
    public static bool ZNetSceneAwake()
    {
        return ZNetScene.instance != null && ZNetScene.instance.m_prefabs.Count != 0 &&
               ZNetScene.instance.GetPrefab("piece_workbench") != null;
    }
}