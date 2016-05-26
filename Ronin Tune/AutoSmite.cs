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
    public static class AutoSmite
    {

        private static string StealText = "";
        public static void Init()
        {
            if (Smite != null)
            {
                Game.OnTick += Game_OnTick;
            }
        }

        private static void Game_OnTick(EventArgs args)
        { 
            if (SmiteIsReady)
            {
                if (MiscMenu.GetCheckBoxValue("jgmDragonSteal"))
                {
                    var minion = EntityManager.MinionsAndMonsters.Monsters.FirstOrDefault(m => m.IsInSmiteRange() && m.IsDragon());
                    if (minion != null)
                    {
                        if (minion.Health <= minion.SmiteDamage())
                        {
                            Util.MyHero.Spellbook.CastSpell(Smite.Slot, minion);
                        }
                    }
                }
                /*
                if (Menu.GetCheckBoxValue("Smite") && SpellManager.CanUseSmiteOnHeroes && enemy.IsInSmiteRange() && Util.MyHero.GetSummonerSpellDamage(enemy, DamageLibrary.SummonerSpells.Smite) >= enemy.Health)
                {
                    Util.MyHero.Spellbook.CastSpell(SpellManager.Smite.Slot, enemy);
                }
                }*/
            }
        }
    }
}
