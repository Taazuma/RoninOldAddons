using System;
using EloBuddy;
using EloBuddy.SDK.Events;
using RoninTune.Modes;

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
            AutoSmite.Init();
            




        }
    }
}