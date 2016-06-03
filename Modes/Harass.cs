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
using static RoninLux.Menus;
using static RoninLux.SpellsManager;

namespace RoninLux.Modes
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
            var qtarget = TargetSelector.GetTarget(Q.Range, DamageType.Mixed);
            var wtarget = TargetSelector.GetTarget(W.Range, DamageType.Mixed);
            var etarget = TargetSelector.GetTarget(E.Range, DamageType.Mixed);
            var rtarget = TargetSelector.GetTarget(3400, DamageType.Mixed);
            var target = TargetSelector.GetTarget(E.Range + 200, DamageType.Magical);

            if (Q.IsReady() && HarassMenu.GetCheckBoxValue("qUse") )
            {
                var predq = Q.GetPrediction(qtarget);
                if (predq.HitChance >= HitChance.High)
                {
                    Q.Cast(predq.CastPosition);
                }
            }

            if (E.IsReady() && HarassMenu.GetCheckBoxValue("eUse"))
            {
                var prede = E.GetPrediction(etarget);
                if (prede.HitChance >= HitChance.High)
                {
                    E.Cast(prede.CastPosition);
                }
            }

        }
    }
}