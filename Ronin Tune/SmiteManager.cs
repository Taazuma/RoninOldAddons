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


namespace RoninTune
{
    class SmiteManager
    {
        private static bool CanSmiteonMonster;
        public static bool CanUseOnChamp
        {
            get
            {
                if (Smite.IsReady())
                {
                    var name = Smite.ToString().ToLower();
                    if (name.Contains("smiteduel") || name.Contains("smiteplayerganker"))
                    {
                        return true;
                    }
                }
                return false;
            }
        }
        public static void OnUpdate(EventArgs agrs)
        {
            var Blue = MiscMenu["Blue"].Cast<CheckBox>().CurrentValue;
            var Red = MiscMenu["Red"].Cast<CheckBox>().CurrentValue;
            var Dragon = MiscMenu["Dragon"].Cast<CheckBox>().CurrentValue;
            var Baron = MiscMenu["Baron"].Cast<CheckBox>().CurrentValue;
            var Herald = MiscMenu["Herald"].Cast<CheckBox>().CurrentValue;
            var Razorbeak = MiscMenu["Razorbeak"].Cast<CheckBox>().CurrentValue;
            var Murkwolf = MiscMenu["Murkwolf"].Cast<CheckBox>().CurrentValue;
            var Krug = MiscMenu["Krug"].Cast<CheckBox>().CurrentValue;
            var Gromp = MiscMenu["Gromp"].Cast<CheckBox>().CurrentValue;
            var Crab = MiscMenu["Crab"].Cast<CheckBox>().CurrentValue;
            foreach (
                var unit in
                EntityManager.MinionsAndMonsters.GetJungleMonsters(Player.Instance.Position, Smite.Range)
                        .Where(x => x.IsValidTarget()))
            {
                if (((unit.Name.Contains("Blue") && Blue)
                    || (unit.Name.Contains("Red") && Red)
                    || (unit.Name.Contains("Dragon") && Dragon)
                    || (unit.Name.Contains("Baron") && Baron)
                    || (unit.Name.Contains("Herald") && Herald)
                    || (unit.Name.Contains("Razorbeak") && Razorbeak)
                    || (unit.Name.Contains("Murkwolf") && Murkwolf)
                    || (unit.Name.Contains("Krug") && Krug)
                    || (unit.Name.Contains("Gromp") && Gromp)
                    || (unit.Name.Contains("Crab") && Crab)) 
                    && !unit.Name.Contains("Mini")
                    && unit.Health <= Damage.SmiteDamage(unit))
                {
                    CanSmiteonMonster = true;
                }
                else
                {
                    continue;
                }
                JungleSteal(unit);
            }
        }
        public static void JungleSteal(Obj_AI_Base unit)
        {
            if (CanSmiteonMonster && Smite.IsReady())
            {
                var Pos = unit.Position;
                Smite.Cast(Pos);
            }
        }
    }
}
