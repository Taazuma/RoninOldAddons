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
    internal class Active
    {
        public void onSpellCast(Obj_AI_Base sender, GameObjectProcessSpellCastEventArgs args)
        {
            if (autoShieldSpell)
                return;
            if (sender.Team != Utils.getPlayer().Team && args.Target != null && sender is AIHeroClient && args.Target is AIHeroClient)
            {
                E.Cast((Obj_AI_Base)args.Target);
            }
        }

        public void OnBasicAttack(Obj_AI_Base sender, GameObjectProcessSpellCastEventArgs args)
        {
            if (autoShieldTurret)
                return;

            if (sender is Obj_AI_Turret)
            {
                if (sender.IsEnemy && args.Target != null &&
                    args.Target is AIHeroClient)
                {
                    SpellsManager.E.Cast((Obj_AI_Base)args.Target);
                }
            }
        }
        //AntiGapCloser
        public void OnGapcloser(AIHeroClient sender, Gapcloser.GapcloserEventArgs e)
        {
            if (antiGapCloser)
            {
                if (sender.Team == Utils.getPlayer().Team && sender.IsValidTarget(E.Range))
                {
                    E.Cast(sender);
                }
            }
        }
    }

    }
