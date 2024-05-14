using System.Collections.Generic;
using System.Linq;
using HarmonyLib;
using UnityEngine;

namespace FineWoodPieces.Functions;

public static class ShaderReplacer
{
    static ShaderReplacer()
    {
        Harmony harmony = new("blacks7ar.utilities.ShaderReplacer");
        harmony.Patch(AccessTools.DeclaredMethod(typeof(FejdStartup), nameof(FejdStartup.Awake)),
            postfix: new HarmonyMethod(AccessTools.DeclaredMethod(typeof(ShaderReplacer), nameof(ReplaceShaderPatch))));
    }

    private static readonly List<GameObject> GOToSwap = [];

    public static void Replace(GameObject gameObject)
    {
        GOToSwap.Add(gameObject);
    }

    [HarmonyPriority(Priority.VeryHigh)]
    private static void ReplaceShaderPatch()
    {
        foreach (var material in from gameObject in GOToSwap
                 select gameObject.GetComponentsInChildren<Renderer>(true)
                 into renderers
                 from renderer in renderers
                 where renderer != null
                 from material in renderer.sharedMaterials
                 where material != null
                 select material)
        {
            var shaders = Resources.FindObjectsOfTypeAll<Shader>();
            foreach (var shader in shaders)
            {
                if (material.shader.name == shader.name)
                {
                    material.shader = shader;
                }
            }
        }
    }
}