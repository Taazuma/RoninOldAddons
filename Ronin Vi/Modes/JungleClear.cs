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
    internal class JungleClear
    {
        /// <summary>
        /// Put in here what you want to do when the mode is running
        /// </summary>
        public static void Execute()
        {
            if (JungleClearMenu.GetCheckBoxValue("qUse") && Q.IsReady())
            {
                var dragon = EntityManager.MinionsAndMonsters.GetJungleMonsters(Player.Instance.ServerPosition, Q2.MaximumRange + 200);
                var dragonline = EntityManager.MinionsAndMonsters.GetLineFarmLocation(dragon, Q2.Width, (int)Q2.MaximumRange);
                if (Q2.IsCharging && Q2.IsFullyCharged && dragonline.CastPosition.IsValid())
                {
                    Q2.Cast(dragonline.CastPosition);
                    return;
                }
                else if (dragon.Count() > 0)
                {
                    Q2.StartCharging();
                    return;
                }

                if (Q.IsReady())
                {
                    Q.Cast(dragonline.CastPosition);
                    return;
                }



                if (JungleClearMenu.GetCheckBoxValue("eUse") && E.IsReady())

                {
                    E.Cast(dragonline.CastPosition);
                    return;
                }

                if (JungleClearMenu.GetCheckBoxValue("eUse") && E.IsReady())
                {
                    var MinionsE = EntityManager.MinionsAndMonsters.GetJungleMonsters().Where(a => a.IsInRange(Player.Instance.ServerPosition, SpellsManager.E2.Range));
                    var Efarm = EntityManager.MinionsAndMonsters.GetLineFarmLocation(MinionsE, 100, (int)SpellsManager.E2.Range);
                    if (Efarm.HitNumber > 1 && Efarm.CastPosition.IsValid())
                    {
                        SpellsManager.E.Cast();
                        return;
                    }
                }
            }
        }
    }
}