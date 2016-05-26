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
using static RoninTune.Menus;
using static RoninTune.SpellsManager;

namespace RoninTune.Modes
{
    /// <summary>
    /// This mode will run when the key of the orbwalker is pressed
    /// </summary>
    internal class JungleClear
    {
        /// <summary>
        /// Put in here what you want to do when the mode is running
        public static readonly AIHeroClient Player = ObjectManager.Player;
        public static void Execute()
        {
            var source =
    EntityManager.MinionsAndMonsters.GetJungleMonsters()
        .OrderBy(a => a.MaxHealth)
        .FirstOrDefault(a => a.IsValidTarget(Q.Range));

            if (source == null) return;
            if (Q.IsReady() && JungleClearMenu.GetCheckBoxValue("qUse") && source.Distance(Player) <= Q.Range)
            {
                Q.Cast(source.Position);
            }

            if (E.IsReady() && JungleClearMenu.GetCheckBoxValue("eUse") && source.Distance(Player) <= E.Range)
            {
                E.Cast(source);
            }

            if (W.IsReady() && ComboMenu.GetCheckBoxValue("wUse"))
            {
                W.Cast();
            }
            if (SpellsManager.SmiteIsReady)
            {
                if (JungleClearMenu.GetCheckBoxValue("jgSmite"))
                {
                    var dragon = EntityManager.MinionsAndMonsters.GetJungleMonsters(Util.MyHero.Position, SpellsManager.Q.Range).FirstOrDefault(m => m.IsInSmiteRange() && m.IsDragon());
                    if (dragon != null)
                    {
                        if (dragon.Health <= dragon.SmiteDamage())
                        {
                            Util.MyHero.Spellbook.CastSpell(SpellsManager.Smite.Slot, dragon);
                        }
                    }
                }
            }
            //Q.TryToCast(Q.GetJungleMinion(), JungleClearMenu);
            //W.TryToCast(Q.GetJungleMinion(), JungleClearMenu);
            //E.TryToCast(Q.GetJungleMinion(), JungleClearMenu);
            //R.TryToCast(Q.GetJungleMinion(), JungleClearMenu);
        }
    }

}