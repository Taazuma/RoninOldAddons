using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Net;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Constants;
using EloBuddy.SDK.Enumerations;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Menu.Values;
using EloBuddy.SDK.Rendering;
using SharpDX;
using Mario_s_Lib;
using static RoninVelkoz.Menus;
using static RoninVelkoz.SpellsManager;

namespace RoninVelkoz.Modes
{
    /// <summary>
    /// This mode will always run
    /// </summary>
    internal class AutoHarass
    {
        /// <summary>
        /// Put in here what you want to do when the mode is running
        /// </summary>
        public static void Execute()
        {
            var qtarget = TargetSelector.GetTarget(Q.Range, DamageType.Magical);
            var wtarget = TargetSelector.GetTarget(W.Range, DamageType.Magical);
            var etarget = TargetSelector.GetTarget(E.Range, DamageType.Magical);
            var rtarget = TargetSelector.GetTarget(R.Range, DamageType.Magical);

            if (AutoHarassMenu.GetCheckBoxValue("qUse") && qtarget.IsValidTarget(SpellsManager.Q.Range) && Q.IsReady() && AutoHarassMenu.GetKeyBindValue("autoHarassKey") && Q.GetPrediction(qtarget).HitChance >= HitChance.Medium)
            {
                Q.Cast(qtarget);
            }

            if (AutoHarassMenu.GetCheckBoxValue("eUse") && E.IsReady() && etarget.IsValidTarget(SpellsManager.E.Range) && AutoHarassMenu.GetKeyBindValue("autoHarassKey") && E.GetPrediction(etarget).HitChance >= HitChance.Medium)
            {
                E.Cast(etarget);
            }

            if (AutoHarassMenu.GetCheckBoxValue("wUse") && W.IsReady() && wtarget.IsValidTarget(SpellsManager.W.Range) && AutoHarassMenu.GetKeyBindValue("autoHarassKey") && W.GetPrediction(wtarget).HitChance >= HitChance.Medium)
            {
                W.Cast(wtarget);
            }
        }
    }
}