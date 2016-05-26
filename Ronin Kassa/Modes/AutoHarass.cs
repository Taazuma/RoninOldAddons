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
using static RoninKassadin.Menus;
using static RoninKassadin.SpellsManager;

namespace RoninKassadin.Modes
{
    /// <summary>
    /// This mode will always run
    /// </summary>
    internal class AutoHarass
    {
        /// <summary>
        /// Put in here what you want to do when the mode is running
        /// </summary>
        public static void Execute()
        {
            var qtarget = TargetSelector.GetTarget(650, DamageType.Magical);
            var wtarget = TargetSelector.GetTarget(1, DamageType.Magical);
            var etarget = TargetSelector.GetTarget(400, DamageType.Magical);
            var rtarget = TargetSelector.GetTarget(500, DamageType.Magical);

            Q.TryToCast(qtarget, AutoHarassMenu);

        }
    }
}