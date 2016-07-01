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
using RoninAkali.Modes;
using static RoninAkali.SpellsManager;
using static RoninAkali.Menus;

namespace RoninAkali
{
    internal class Program
    {
        // ReSharper disable once UnusedParameter.Local
        /// <summary>
        /// The firs thing that runs on the template
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            Loading.OnLoadingComplete += Loading_OnLoadingComplete;
        }
        public static AIHeroClient _player
        {
            get { return ObjectManager.Player; }
        }

        public static int qOff = 0, wOff = 0, eOff = 0, rOff = 0;
        private static int[] AbilitySequence;
        public const float SmiteRange = 570;
        /// <summary>
        /// This event is triggered when the game loads
        /// </summary>
        /// <param name="args"></param>
        private static void Loading_OnLoadingComplete(EventArgs args)
        {
            //Put the name of the champion here
            if (Player.Instance.ChampionName != "Akali") return;
            AbilitySequence = new int[] { 1, 3, 2, 1, 1, 4, 1, 3, 1, 3, 4, 3, 3, 2, 2, 4, 2, 2 };
            Chat.Print("Welcome to the Ronin´s BETA ;)");
            SpellsManager.InitializeSpells();
            Menus.CreateMenu();
            ModeManager.InitializeModes();
            DrawingsManager.InitializeDrawings();
            Interrupter.OnInterruptableSpell += Interrupter_OnInterruptableSpell;
            Game.OnUpdate += OnGameUpdate;
            Game.OnTick += GameOnTick;
            Events.Initialize();
            EventsManager.Initialize();
        }

        private static void GameOnTick(EventArgs args)
        {
            if (MiscMenu["lvlup"].Cast<CheckBox>().CurrentValue) LevelUpSpells();
        }

        private static void OnGameUpdate(EventArgs args)
        {
            _player.SetSkinId(skinId());
        }

        public static float SmiteDmgMonster(Obj_AI_Base target)
        {
            return Player.Instance.GetSummonerSpellDamage(target, DamageLibrary.SummonerSpells.Smite);
        }

        public static float SmiteDmgHero(AIHeroClient target)
        {
            return Player.Instance.CalculateDamageOnUnit(target, DamageType.True,
                20.0f + Player.Instance.Level * 8.0f);
        }

        public static readonly string[] BuffsThatActuallyMakeSenseToSmite =
       {
                "SRU_Red", "SRU_Blue", "SRU_Dragon_Water",  "SRU_Dragon_Fire", "SRU_Dragon_Earth", "SRU_Dragon_Air", "SRU_Dragon_Elder",
                "SRU_Baron", "SRU_RiftHerald", "TT_Spiderboss",
       };

        public readonly static string[] MonstersNames =
        {
            "SRU_Dragon_Water", "SRU_Dragon_Fire", "SRU_Dragon_Earth", "SRU_Dragon_Air", "SRU_Dragon_Elder", "Sru_Crab", "SRU_Baron", "SRU_RiftHerald",
            "SRU_Red", "SRU_Blue",  "SRU_Krug", "SRU_Gromp", "SRU_Murkwolf", "SRU_Razorbeak",
            "TT_Spiderboss", "TTNGolem", "TTNWolf", "TTNWraith",
        };

        private static void Interrupter_OnInterruptableSpell(Obj_AI_Base sender, Interrupter.InterruptableSpellEventArgs e)
        {
            if (!sender.IsValidTarget(W.Range) || e.DangerLevel != DangerLevel.High || e.Sender.Type != _player.Type || !e.Sender.IsEnemy)
            {
                return;
            }

            if (W.IsReady() && MiscMenu["interrupt.w"].Cast<CheckBox>().CurrentValue)
            {
                W.Cast(Player.Instance);
            }
        }

        private static void LevelUpSpells()
        {
            var qL = _player.Spellbook.GetSpell(SpellSlot.Q).Level + qOff;
            var wL = _player.Spellbook.GetSpell(SpellSlot.W).Level + wOff;
            var eL = _player.Spellbook.GetSpell(SpellSlot.E).Level + eOff;
            var rL = _player.Spellbook.GetSpell(SpellSlot.R).Level + rOff;
            if (qL + wL + eL + rL >= ObjectManager.Player.Level) return;
            var level = new[] { 0, 0, 0, 0 };
            for (var i = 0; i < ObjectManager.Player.Level; i++)
            {
                level[AbilitySequence[i] - 1] = level[AbilitySequence[i] - 1] + 1;
            }
            if (qL < level[0]) ObjectManager.Player.Spellbook.LevelSpell(SpellSlot.Q);
            if (wL < level[1]) ObjectManager.Player.Spellbook.LevelSpell(SpellSlot.W);
            if (eL < level[2]) ObjectManager.Player.Spellbook.LevelSpell(SpellSlot.E);
            if (rL < level[3]) ObjectManager.Player.Spellbook.LevelSpell(SpellSlot.R);
        }

    }
}