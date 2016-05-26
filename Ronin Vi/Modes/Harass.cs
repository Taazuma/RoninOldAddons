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
    internal class Harass
    {
        /// <summary>
        /// Put in here what you want to do when the mode is running
        /// </summary>
        public static void Execute()
        {
            var target = TargetSelector.GetTarget(1000, DamageType.Mixed);

            Q.TryToCast(target, HarassMenu);
            W.TryToCast(target, HarassMenu);
            E.TryToCast(target, HarassMenu);
            R.TryToCast(target, HarassMenu);
        }
    }
}