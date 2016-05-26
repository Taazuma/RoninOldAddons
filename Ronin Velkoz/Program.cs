using System;
using EloBuddy;
using EloBuddy.SDK.Events;
using RoninVelkoz.Modes;

namespace RoninVelkoz
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

        /// <summary>
        /// This event is triggered when the game loads
        /// </summary>
        /// <param name="args"></param>
        private static void Loading_OnLoadingComplete(EventArgs args)
        {
            //Put the name of the champion here
            if (Player.Instance.ChampionName != "Velkoz") return;
            Chat.Print("Welcome to the Ronin´s BETA ;)");
            SpellsManager.InitializeSpells();
            Menus.CreateMenu();
            ModeManager.InitializeModes();
            DrawingsManager.InitializeDrawings();
            Interrupter.OnInterruptableSpell += ModeManager.InterruptMode;
            Gapcloser.OnGapcloser += ModeManager.GapCloserMode;
            Game.OnUpdate += SpellsManager.QSplit;
            GameObject.OnCreate += SpellsManager.OnCreate;
        }
    }
}