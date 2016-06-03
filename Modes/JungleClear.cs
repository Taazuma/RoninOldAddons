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
using static RoninLux.Menus;
using static RoninLux.SpellsManager;

namespace RoninLux.Modes
{
    /// <summary>
    /// This mode will run when the key of the orbwalker is pressed
    /// </summary>
    internal class JungleClear
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

            if (JungleClearMenu.GetCheckBoxValue("jclear1"))
                { 
            var source = EntityManager.MinionsAndMonsters.GetJungleMonsters(_Player.ServerPosition, Q.Range).OrderByDescending(a => a.MaxHealth).FirstOrDefault();

            if (source == null) return;

            if (Q.IsReady() && JungleClearMenu["qUse"].Cast<CheckBox>().CurrentValue && source.Distance(_Player) <= Q.Range)
            {
                Q.Cast(source);
                return;
            }

            if (W.IsReady() && JungleClearMenu["wUse"].Cast<CheckBox>().CurrentValue && source.Distance(_Player) < _Player.GetAutoAttackRange(source))
            {
                W.Cast(source);
                return;

            }
            if (E.IsReady() && JungleClearMenu["eUse"].Cast<CheckBox>().CurrentValue && source.Distance(_Player) < _Player.GetAutoAttackRange(source))
            {
                E.Cast(source);
                return;
            }
            return;
            }

            if (JungleClearMenu.GetCheckBoxValue("jclear2"))
            {
                var target = EntityManager.MinionsAndMonsters.GetJungleMonsters().OrderByDescending(a => a.MaxHealth).FirstOrDefault(a => a.IsValidTarget(900));

            if (JungleClearMenu.GetCheckBoxValue("eUse") && E.IsReady() && target.IsValidTarget(SpellsManager.E.Range) && E.GetPrediction(target).HitChance >= HitChance.Medium)
            {
                E.Cast(target);
            }
            if (JungleClearMenu.GetCheckBoxValue("qUse") && Q.IsReady() && target.IsValidTarget(SpellsManager.Q.Range))
            {
                Q.Cast(target);
            }
            if (JungleClearMenu.GetCheckBoxValue("WUse") && W.IsReady() && target.IsValidTarget(W.Range))
            {
                W.Cast(target);
                }
            }


        }
    }
}