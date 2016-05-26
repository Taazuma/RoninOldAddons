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
    /// This mode will always run
    /// </summary>
    internal class Active
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
            var target = TargetSelector.GetTarget(Q.Range + 300, DamageType.Physical);
            var qtarget = TargetSelector.GetTarget(Q.Range, DamageType.Physical);
            var wtarget = TargetSelector.GetTarget(W.Range, DamageType.Physical);
            var etarget = TargetSelector.GetTarget(E.Range, DamageType.Physical);
            var rtarget = TargetSelector.GetTarget(R.Range, DamageType.Physical);
            var enemies = EntityManager.Heroes.Enemies.OrderByDescending(a => a.HealthPercent).Where(a => !a.IsMe && a.IsValidTarget() && a.Distance(_Player) <= R.Range);

            // REGION Gank Modus
            if (ComboMenu.GetCheckBoxValue("gankm") && ComboMenu.GetKeyBindValue("gankKey"))
            {
                EloBuddy.Player.IssueOrder(GameObjectOrder.MoveTo, Game.CursorPos);
                if (SpellsManager.Q.IsReady() && target != null)
                {
                    if (SpellsManager.Q2.IsCharging)
                    {
                        SpellsManager.Q2.Cast(target);
                        return;
                    }
                    else
                    {
                        SpellsManager.Q2.StartCharging();
                        return;
                    }
                }
            }
            // End REGION Gank Modus

            // REGION FLASH + Q
            if (ComboMenu.GetCheckBoxValue("flashq") && ComboMenu.GetKeyBindValue("gankKey"))
            {
                EloBuddy.Player.IssueOrder(GameObjectOrder.MoveTo, Game.CursorPos);
                if (SpellsManager.Q.IsReady() && SpellsManager.Flash.IsReady())
                {
                    var target2 = TargetSelector.SelectedTarget;
                    var range = SpellsManager.Q2.MaximumRange + SpellsManager.Flash.Range;


                    if (target2 != null && target2.IsValidTarget(SpellsManager.Q2.MaximumRange + SpellsManager.Flash.Range))
                    {
                        SpellsManager.Q2.StartCharging();

                        Core.DelayAction(delegate ()
                        {
                            if (SpellsManager.Q2.IsCharging && SpellsManager.Q2.IsFullyCharged && target2.IsValidTarget(SpellsManager.Q2.MaximumRange)) SpellsManager.Q.Cast(target2.Position);
                        }, 1250);


                        Core.DelayAction(delegate ()
                        {
                            if (target2.IsValidTarget(SpellsManager.Q2.MaximumRange)) SpellsManager.Flash.Cast(target2.Position);
                        }, 1251);
                    }
                }
                return;
            }
            //  END REGION FLASH + Q

            //  Beginn REGION FLASH + Q + R
            if (ComboMenu.GetCheckBoxValue("flashqr") && ComboMenu.GetKeyBindValue("gankKey")) // REGION FLASH + Q
            {
                EloBuddy.Player.IssueOrder(GameObjectOrder.MoveTo, Game.CursorPos);
                if (SpellsManager.Q.IsReady() && SpellsManager.R.IsReady() && SpellsManager.Flash.IsReady())
                {
                    var target2 = TargetSelector.SelectedTarget;
                    var range = SpellsManager.Q2.MaximumRange + SpellsManager.Flash.Range;
                    if (target2 != null && target2.IsValidTarget(SpellsManager.Q2.MaximumRange + SpellsManager.Flash.Range))
                    {
                        SpellsManager.Q2.StartCharging();

                        Core.DelayAction(delegate ()
                        {
                            if (SpellsManager.Q2.IsCharging && SpellsManager.Q2.IsFullyCharged && target2.IsValidTarget(SpellsManager.Q2.MaximumRange)) SpellsManager.Q.Cast(target2.Position);
                        }, 1250);


                        Core.DelayAction(delegate ()
                        {
                            if (target2.IsValidTarget(SpellsManager.Q2.MaximumRange)) SpellsManager.Flash.Cast(target2.Position);
                        }, 1251);
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
                        return;
                    }
                }
            }
            //  End REGION FLASH + Q + R
        }
    }
}