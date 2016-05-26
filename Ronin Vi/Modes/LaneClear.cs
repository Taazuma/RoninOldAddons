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
    internal class LaneClear
    {
        /// <summary>
        /// Put in here what you want to do when the mode is running
        /// </summary>
        public static void Execute()
        {

            if (LaneClearMenu.GetCheckBoxValue("qUse") && Q.IsReady() || Q2.IsCharging)
            {
                var MinionsQ = EntityManager.MinionsAndMonsters.GetLaneMinions(EntityManager.UnitTeam.Enemy).Where(a => a.IsInRange(Player.Instance.ServerPosition, Q2.MaximumRange));


                var Qfarm = EntityManager.MinionsAndMonsters.GetLineFarmLocation(MinionsQ, 100, (int)Q2.MaximumRange);
                if (Q2.IsCharging && Q2.IsFullyCharged && Qfarm.CastPosition.IsValid())
                {
                    Q2.Cast(Qfarm.CastPosition);
                    return;
                }

                else if (Qfarm.HitNumber > 3)
                {
                    Q2.StartCharging();
                    return;
                }

            }

            if (LaneClearMenu.GetCheckBoxValue("eUse") && E.IsReady())
            {
                E.Cast();
                return;
            }

            if (LaneClearMenu.GetCheckBoxValue("eUse") && SpellsManager.E.IsReady())
            {
                var MinionsE = EntityManager.MinionsAndMonsters.GetLaneMinions(EntityManager.UnitTeam.Enemy).Where(a => a.IsInRange(Player.Instance.ServerPosition, SpellsManager.E2.Range));
                var Efarm = EntityManager.MinionsAndMonsters.GetLineFarmLocation(MinionsE, 100, (int)SpellsManager.E2.Range);
                if (Efarm.HitNumber > 2 && Efarm.CastPosition.IsValid())
                {
                    SpellsManager.E.Cast();
                    return;
                }
            }
        }
    }
}