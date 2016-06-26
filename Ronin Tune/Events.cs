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
using System.Drawing;
using Color = SharpDX.Color;
using Font = System.Drawing.Font;
using FontColor = System.Drawing.Color;

namespace RoninTune
{
    public static class Events
    {
        private static Text Text;

        static Events()
        {
            Text = new Text("", new Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold)) { Color = System.Drawing.Color.White };
            Drawing.OnDraw += OnDraw;
            Orbwalker.OnAttack += OrbwalkerOnOnAttack;
        }

        private static void OrbwalkerOnOnAttack(AttackableUnit target, EventArgs args)
        {
            if (MiscMenu.GetCheckBoxValue("fjgl") && target is AIHeroClient && SpellsManager.HasChallengingSmite() && 
                SpellsManager.Smite.IsReady())
            {
                var enemyHero = (AIHeroClient) target;
                SpellsManager.Smite.Cast(enemyHero);
            }
        }


        public static void Initialize()
        {
        }

        private static void OnDraw(EventArgs args)
        {
            if (Player.Instance.IsDead)
            {
                return;
            }
            
            if (MiscMenu.GetCheckBoxValue("vSmiteDrawRange"))
            {
                Circle.Draw(Color.Gold, SpellsManager.Smite.Range, Player.Instance.Position);
            }
            if (MiscMenu.GetCheckBoxValue("vSmiteDrawSmiteStatus"))
            {
                var enabled = MiscMenu.GetKeyBindValue("smitekey") && MiscMenu.GetCheckBoxValue("sjgl");
                Text.Position = Drawing.WorldToScreen(Player.Instance.Position) - new Vector2(40, -60);
                Text.Color = enabled ? FontColor.LightSeaGreen : FontColor.DarkRed;
                Text.TextValue = enabled ? "Smite: ENABLED" : "Smite: disabled";
                Text.Draw();
            }
            if (MiscMenu.GetCheckBoxValue("vSmiteDrawSmiteable"))
            {
                var monsters =
                    EntityManager.MinionsAndMonsters.GetJungleMonsters(Player.Instance.Position, SpellsManager.Smite.Range + 500.0f)
                        .Where(e => !e.IsDead && e.Health > 0 && !e.IsInvulnerable && e.IsVisible && e.Health < Program.SmiteDmgMonster(e) && Program.MonstersNames.Contains(e.BaseSkinName));
                foreach (var monster in monsters)
                {
                    Circle.Draw(Color.Red, monster.BoundingRadius, monster.Position);
                }
            }
        }

    }
}
