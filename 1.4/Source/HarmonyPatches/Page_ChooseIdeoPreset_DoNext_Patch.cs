﻿using HarmonyLib;
using RimWorld;
using Verse;

namespace VFETribals
{
    [HarmonyPatch(typeof(Page_ChooseIdeoPreset), "DoNext")]
    public static class Page_ChooseIdeoPreset_DoNext_Patch
    {
        public static bool Prefix(Page_ChooseIdeoPreset __instance)
        {
            if (Current.Game.Scenario == VFET_DefOf.VFET_WildMenScenario.scenario)
            {
                Find.IdeoManager.classicMode = true;
                Find.Scenario.PostIdeoChosen();
                Find.WindowStack.Add(__instance.next);
                if (__instance.nextAct != null)
                {
                    __instance.nextAct();
                }
                TutorSystem.Notify_Event("PageClosed");
                TutorSystem.Notify_Event("GoToNextPage");
                __instance.Close();
                return false;
            }
            return true;
        }
    }
}