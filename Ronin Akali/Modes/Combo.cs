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
using static RoninAkali.Menus;
using static RoninAkali.SpellsManager;

namespace RoninAkali.Modes
{
    /// <summary>
    /// This mode will run when the key of the orbwalker is pressed
    /// </summary>
    internal class Combo
    {
        /// <summary>
        /// Put in here what you want to do when the mode is running
        /// </summary>
        public static void Execute()
        {
            var qtarget = TargetSelector.GetTarget(Q.Range, DamageType.Magical);
            var wtarget = TargetSelector.GetTarget(W.Range, DamageType.Magical);
            var etarget = TargetSelector.GetTarget(E.Range, DamageType.Magical);
            var rtarget = TargetSelector.GetTarget(R.Range, DamageType.Mixed);
            var target = TargetSelector.GetTarget(Q.Range + 200, DamageType.Magical);
            //var enemies = EntityManager.Heroes.Enemies.OrderByDescending(a => a.HealthPercent).Where(a => !a.IsMe && a.IsValidTarget() && a.Distance(_Player) <= R.Range);

            // COMBO 1 Beginn --------------------------------------------------------------------------------
            if (ComboMenu.GetCheckBoxValue("combo1"))
                { 
            Core.DelayAction(delegate
            {
                if (ComboMenu.GetCheckBoxValue("qUse") && Q.IsReady() && qtarget.IsValidTarget(Q.Range))
                {
                    Q.Cast(qtarget);
                }
            }, Qdelay);
                Core.DelayAction(delegate
            {
                if (ComboMenu.GetCheckBoxValue("rUse") && R.IsReady() && rtarget.IsValidTarget(R.Range))
                {
                    R.Cast(rtarget);
                }
            }, Rdelay);

            Core.DelayAction(delegate
            {
                if (ComboMenu.GetCheckBoxValue("eUse") && E.IsReady() && etarget.IsValidTarget(E.Range))
                {
                    E.Cast();
                }
            }, Edelay);

            if (W.IsReady() && wtarget.IsValidTarget(W.Range) && ComboMenu.GetCheckBoxValue("wUse"))
            {
                if (Player.Instance.CountEnemiesInRange(Q.Range) >= 1 || Player.Instance.HealthPercent <= 15)
                {
                    W.Cast(Player.Instance);
                }
            }
            }
            // COMBO 1 END --------------------------------------------------------------------------------

            // COMBO 2 Beginn --------------------------------------------------------------------------------
            if (ComboMenu.GetCheckBoxValue("combo2"))
                {
                Core.DelayAction(delegate
                {
                    if (ComboMenu.GetCheckBoxValue("qUse") && Q.IsReady() && qtarget.IsValidTarget(Q.Range))
                    {
                        Q.Cast(qtarget);
                    }
                }, Qdelay);

                Core.DelayAction(delegate
                {
                    if (ComboMenu.GetCheckBoxValue("eUse") && E.IsReady() && etarget.IsValidTarget(E.Range))
                    {
                        E.Cast();
                    }
                }, Edelay);

                Core.DelayAction(delegate
                {
                    if (ComboMenu.GetCheckBoxValue("rUse") && R.IsReady() && rtarget.IsValidTarget(R.Range))
                    {
                        R.Cast(rtarget);
                    }
                }, Rdelay);

                if (W.IsReady() && wtarget.IsValidTarget(W.Range) && ComboMenu.GetCheckBoxValue("wUse"))
                {
                    if (Player.Instance.CountEnemiesInRange(Q.Range) >= 1 || Player.Instance.HealthPercent <= 15)
                    {
                        W.Cast(Player.Instance);
                    }
                }
            }
            // COMBO 2 END --------------------------------------------------------------------------------

        }
    }
}