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
using static RoninKarma.Menus;
using static RoninKarma.SpellsManager;

namespace RoninKarma.Modes
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
            var qtarget = TargetSelector.GetTarget(Q.Range, DamageType.Magical);
            var wtarget = TargetSelector.GetTarget(W.Range, DamageType.Magical);
            var etarget = TargetSelector.GetTarget(E.Range, DamageType.Magical);

        //    if (AutoHarassMenu.GetCheckBoxValue("qUse") && AutoHarassMenu.GetKeyBindValue("autoHarassKey"))
        //{ 
        //  Q.TryToCast(target, AutoHarassMenu);
        //}

            if (AutoHarassMenu.GetCheckBoxValue("rqUse") && AutoHarassMenu.GetKeyBindValue("autoHarassKey"))
            {
                    R.Cast();
                    Q.Cast(qtarget);
            }

            if (AutoHarassMenu.GetCheckBoxValue("qUse") && AutoHarassMenu.GetKeyBindValue("autoHarassKey"))
                {
                    Q.Cast(qtarget);
                }


        }
    }
}