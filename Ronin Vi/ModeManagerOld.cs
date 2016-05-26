using System;
using System.Collections.Generic;
using RoninVi.Modes;
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


namespace RoninVi
{
    public static class ModeManagerOld
    {
        private static List<ModeBase> Modes { get; set; }

        static ModeManagerOld()
        {
            // Initialize properties
            Modes = new List<ModeBase>();

            // Load all modes manually since we are in a sandbox which does not allow reflection
            // Order matter here! You would want something like PermaActive being called first
            Modes.AddRange(new ModeBase[]
            {
                new PermaActive(),
            });

            // Listen to events we need
            Game.OnTick += OnTick;
        }



        public static void Initialize()
        {
            // Let the static initializer do the job, this way we avoid multiple init calls aswell
        }
private static void OnTick(EventArgs args)
        {
            // Execute all modes
            Modes.ForEach(mode =>
            {
                try
                {
                    // Precheck if the mode should be executed
                    if (mode.ShouldBeExecuted())
                    {
                        // Execute the mode
                        mode.Execute();
                    }
                }
                catch (Exception e)
                {
                    // Please enable the debug window to see and solve the exceptions that might occur!
                    //Logger.Log(LogLevel.Error, "Error executing mode '{0}'\n{1}", mode.GetType().Name, e);
                }
            });
        }
    }
}
