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
using static RoninTune.Menus;
using static RoninTune.SpellsManager;

namespace RoninTune.Modes
{
    /// <summary>
    /// This mode will always run
    /// </summary>
    internal class AutoHarass
    {
        /// <summary>
        /// Put in here what you want to do when the mode is running
        public static readonly AIHeroClient Player = ObjectManager.Player;
        public static void Execute()
        {
            var enemiese = EntityManager.Heroes.Enemies.OrderByDescending
              (a => a.HealthPercent).Where(a => !a.IsMe && a.IsValidTarget() && a.Distance(Player) <= R.Range);
            var enemiesq = EntityManager.Heroes.Enemies.OrderByDescending
                (a => a.HealthPercent).Where(a => !a.IsMe && a.IsValidTarget() && a.Distance(Player) <= Q.Range);
            var target = TargetSelector.GetTarget(1900, DamageType.Magical);
            if (!target.IsValidTarget())
            {
                return;
            }

            if (E.IsReady() && target.IsValidTarget(E.Range) && AutoHarassMenu.GetCheckBoxValue("eUse") && AutoHarassMenu.GetKeyBindValue("autoHarassKey"))
            {
                foreach (var eenemies in enemiese)
                {

                    E.Cast(eenemies);
                }
            }

            if (Q.IsReady() && AutoHarassMenu.GetCheckBoxValue("qUse") && AutoHarassMenu.GetKeyBindValue("autoHarassKey"))
            {
                foreach (var qenemies in enemiesq)
                {

                    var predq = Q.GetPrediction(qenemies);
                    if (predq.HitChance >= HitChance.High)
                    {
                        Q.Cast(predq.CastPosition);
                    }
                }
            }
        }
    }
}