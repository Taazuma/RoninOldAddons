using System;
using EloBuddy;
using EloBuddy.SDK.Events;
using RoninTune.Modes;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;
using EloBuddy.SDK.Menu;
using Mario_s_Lib;

namespace RoninTune
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
        public const float SmiteRange = 570;
        public static AIHeroClient _player
        {
            get { return ObjectManager.Player; }

        }
        /// <summary>
        /// This event is triggered when the game loads
        /// </summary>
        /// <param name="args"></param>
        private static void Loading_OnLoadingComplete(EventArgs args)
        {
            //Put the name of the champion here
            if (Player.Instance.ChampionName != "Nocturne") return;
            Chat.Print("Welcome to the Ronin´s BETA ;)");
            SpellsManager.InitializeSpells();
            Menus.CreateMenu();
            _W.Initialize();
            _W_Advance.Initialize();
            ModeManager.InitializeModes();
            DrawingsManager.InitializeDrawings();
            Interrupter.OnInterruptableSpell += Program.Interrupter2_OnInterruptableTarget;
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
                "SRU_Baron", "SRU_Gromp", "SRU_Murkwolf",
                "SRU_RiftHerald",
                "SRU_Krug", "Sru_Crab", "TT_Spiderboss",
                "TT_NGolem", "TT_NWolf", "TT_NWraith"
       };
        public static bool getCheckBoxItem(Menu m, string item)
        {
            return m[item].Cast<CheckBox>().CurrentValue;
        }

        public static int getSliderItem(Menu m, string item)
        {
            return m[item].Cast<Slider>().CurrentValue;
        }

        public static bool getKeyBindItem(Menu m, string item)
        {
            return m[item].Cast<KeyBind>().CurrentValue;
        }

        public static int getBoxItem(Menu m, string item)
        {
            return m[item].Cast<ComboBox>().CurrentValue;
        }

        private static void Interrupter2_OnInterruptableTarget(Obj_AI_Base sender, Interrupter.InterruptableSpellEventArgs args)
        {
            if (SpellsManager.W.IsReady() && sender.IsValidTarget(SpellsManager.W.Range) && RoninTune.Menus.MiscMenu.GetCheckBoxValue("UseWInt"))
            {
                SpellsManager.W.Cast(sender.Position);
            }
        }


    }
}