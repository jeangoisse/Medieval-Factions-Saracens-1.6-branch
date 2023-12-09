// RimWorld.CompProperties_Reloadable
using HarmonyLib;
using System.Collections.Generic;
using RimWorld;
using UnityEngine;
using Verse;
using Verse.Sound;
using System;
using System.Diagnostics;

namespace Saracens
{
    [HarmonyPatch(typeof(Pawn_AgeTracker), nameof(Pawn_AgeTracker.PostResolveLifeStageChange))]
    public static class PostResolveLifeStageChangePatch {

        static void Prefix(Pawn_AgeTracker __instance, Pawn ___pawn) {
            Log.Message(___pawn.Label);
            var growth = Mathf.Clamp01(__instance.AgeBiologicalYearsFloat / ___pawn.RaceProps.lifeStageAges[___pawn.RaceProps.lifeStageAges.Count - 1].minAge);
            Log.Message(growth.ToString());
            Log.Message(Mathf.Lerp(0f, ___pawn.RaceProps.lifeStageAges[___pawn.RaceProps.lifeStageAges.Count - 1].minAge, growth).ToString());
            Log.Message(new StackTrace(0, fNeedFileInfo: false).ToString());
        }
    }

    [HarmonyPatch(typeof(Pawn_AgeTracker), nameof(Pawn_AgeTracker.ExposeData))]
    public static class ExposeDataPatch
    {

        static void Prefix()
        {
            Log.Message("Expose data");
        }
    }

    [StaticConstructorOnStartup]
    public static class ModInitializer
    {
        static ModInitializer()
        {
            var harmony = new Harmony("Saracens");
            harmony.PatchAll();
        }
    }

}
