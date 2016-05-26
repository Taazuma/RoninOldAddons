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
using static RoninKassadin.Menus;
using static RoninKassadin.SpellsManager;

namespace RoninKassadin.Modes
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
            var qtarget = TargetSelector.GetTarget(650, DamageType.Magical);
            var wtarget = TargetSelector.GetTarget(5, DamageType.Magical);
            var etarget = TargetSelector.GetTarget(400, DamageType.Magical);
            var rtarget = TargetSelector.GetTarget(500, DamageType.Magical);
            var rmax = EntityManager.Heroes.Enemies.Where(t => t.IsInRange(Player.Instance.Position, R.Range) && !t.IsDead && t.IsValid && !t.IsInvulnerable).Count();

            if (Q.IsReady() && ComboMenu.GetCheckBoxValue("qUse") && qtarget.IsValidTarget(Q.Range))
            {
                Q.Cast(qtarget);
            }

            if (ComboMenu.GetCheckBoxValue("wUse") && W.IsReady())
            {
                W.Cast();
            }

            if (ComboMenu.GetCheckBoxValue("wrUse") && W.IsReady() && wtarget.IsValidTarget(W.Range))
            {
                W.Cast();
            }

            if (E.IsReady() && ComboMenu.GetCheckBoxValue("eUse"))
            {
                E.Cast(etarget);
            }

            if (E.IsReady() && ComboMenu.GetCheckBoxValue("erUse") && etarget.IsValidTarget(E.Range))
            {
                E.Cast(etarget.Position);
            }

            if (R.IsReady() && ComboMenu.GetCheckBoxValue("rUse") && !(rmax >= ComboMenu["MaxR"].Cast<Slider>().CurrentValue))
            {
                R.Cast(rtarget);
            }

            if (R.IsReady() && ComboMenu.GetCheckBoxValue("rrUse") && rtarget.IsValidTarget(R.Range) && !(rmax >= ComboMenu["MaxR"].Cast<Slider>().CurrentValue))
            {
                R.Cast(rtarget.Position);
            }

        }
    }
}