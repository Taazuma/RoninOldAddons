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
    /// This mode will run when the key of the orbwalker is pressed
    /// </summary>
    internal class LaneClear
    {
        /// <summary>
        /// Put in here what you want to do when the mode is running
        /// </summary>
        public static void Execute()
        {

            var count = EntityManager.MinionsAndMonsters.GetLaneMinions(EntityManager.UnitTeam.Enemy, Player.Instance.ServerPosition, E.Range, false).Count();
            if (count == 0) return;
            var source = EntityManager.MinionsAndMonsters.GetLaneMinions().OrderBy(a => a.MaxHealth).FirstOrDefault(a => a.IsValidTarget(Q.Range));

            if (LaneClearMenu.GetCheckBoxValue("qUse") && Q.IsReady() && source.IsValidTarget(SpellsManager.Q.Range) && E.GetPrediction(source).HitChance >= HitChance.Medium)
            {
                Q.Cast(source.Position);
            }

            if (LaneClearMenu.GetCheckBoxValue("WUse") && W.IsReady() && source.IsValidTarget(W.Range) && E.GetPrediction(source).HitChance >= HitChance.Medium)
            {
                W.Cast(source.Position);
            }

            if (LaneClearMenu.GetCheckBoxValue("eUse") && E.IsReady() && source.IsValidTarget(SpellsManager.E.Range) && E.GetPrediction(source).HitChance >= HitChance.Medium)
            {
                E.Cast(source.Position);
            }
        }
    }
}