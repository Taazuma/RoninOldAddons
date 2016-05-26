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
using static RoninVi.Menus;
using static RoninVi.SpellsManager;

namespace RoninVi.Modes
{
    /// <summary>
    /// This mode will run when the key of the orbwalker is pressed
    /// </summary>
    internal class Combo
    {
        private static AIHeroClient myHero
        {
            get { return Player.Instance; }
        }
        public static AIHeroClient _Player
        {
            get { return ObjectManager.Player; }
        }
        public static void Execute()
        {
            // REGION COMBO
            var target = TargetSelector.GetTarget(Q.Range + 300, DamageType.Physical);
            var qtarget = TargetSelector.GetTarget(Q.Range, DamageType.Physical);
            var wtarget = TargetSelector.GetTarget(W.Range, DamageType.Physical);
            var etarget = TargetSelector.GetTarget(E.Range, DamageType.Physical);
            var rtarget = TargetSelector.GetTarget(R.Range, DamageType.Physical);
            var enemies = EntityManager.Heroes.Enemies.OrderByDescending(a => a.HealthPercent).Where(a => !a.IsMe && a.IsValidTarget() && a.Distance(_Player) <= R.Range);


            //if (ComboMenu.GetCheckBoxValue("qUse") && Q.IsReady() && target.IsValidTarget(Q.Range))
            //{
            //    if (Q.IsCharging)
            //    {
            //        Q.Cast(target);
            //        return;
            //    }
            //    else
            //    {
            //        Q.StartCharging();
            //        Q2.Cast(qtarget);
            //    }
            //}

            if (ComboMenu.GetCheckBoxValue("qUse") && Q.IsReady() && target.IsValidTarget(Q.Range))
            {
                Q.Cast(qtarget);
                return;
            }
            else
            if (Q2.IsCharging)
            {
                Q2.Cast(target);
                return;
            }

            if (ComboMenu.GetCheckBoxValue("eUse") && E.IsReady())
            {
                //if (target != null)
                {
                    E.Cast();
                    return;
                }
            }

            if (ComboMenu.GetCheckBoxValue("rUse") && R.IsReady())
            {

                foreach (var ultenemies in enemies)
                {
                    var useR = ComboMenu["r.ult" + ultenemies.ChampionName].Cast<CheckBox>().CurrentValue;
                    if (target != null)
                    {
                        if ((useR))
                        {
                            R.Cast(ultenemies);
                        }
                    }
                }
            }
            // End REGION COMBO

           

        }
    }
    }

