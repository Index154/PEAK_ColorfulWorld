using HarmonyLib;
using UnityEngine;

namespace ColorfulWorld;

public class Patches()
{
    [HarmonyPatch(typeof(SetMaterialProperty))]
    [HarmonyPatch("SetVal")]
    [HarmonyPrefix]
    public static bool Test(SetMaterialProperty __instance, ref float val)
    {
        Renderer component = __instance.GetComponent<Renderer>();
		MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();
		component.GetPropertyBlock(materialPropertyBlock);
		materialPropertyBlock.SetFloat(__instance.propertyName, val);
		component.SetPropertyBlock(materialPropertyBlock);

        ColorfulWorld.Logger.LogInfo("! => " + component.material.color);
        return false;
    }
}