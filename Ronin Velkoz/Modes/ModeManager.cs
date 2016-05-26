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
using static RoninVelkoz.SpellsManager;
using static RoninVelkoz.Menus;

namespace RoninVelkoz.Modes
{
    internal class ModeManager
    {
        /// <summary>
        /// Create the event on tick
        public static AIHeroClient Champion { get { return Player.Instance; } }
        public static void InitializeModes()
        {
            Game.OnTick += Game_OnTick;
        }

        public static void UltFollowMode()
        {
            var target = TargetSelector.GetTarget(R.Range, DamageType.Magical);
            if (target != null)
                Champion.Spellbook.UpdateChargeableSpell(SpellSlot.R, target.ServerPosition, false, false);
            else
            {
                var mtarget = TargetManager.GetMinionTarget(R.Range, DamageType.Magical);
                if (mtarget != null)
                    Champion.Spellbook.UpdateChargeableSpell(SpellSlot.R, mtarget.ServerPosition, false, false);
            }
        }
        public static void StackMode()
        {
            foreach (var item in Champion.InventoryItems)
            {
                if ((item.Id == ItemId.Tear_of_the_Goddess || item.Id == ItemId.Tear_of_the_Goddess_Crystal_Scar ||
                     item.Id == ItemId.Archangels_Staff || item.Id == ItemId.Archangels_Staff_Crystal_Scar ||
                     item.Id == ItemId.Manamune || item.Id == ItemId.Manamune_Crystal_Scar)
                    && Champion.IsInShopRange())
                {
                    if ((int)(Game.Time - SpellsManager.StackerStamp) >= 2)
                    {
                        SpellsManager.Q.Cast(Champion);
                        SpellsManager.StackerStamp = Game.Time;
                    }
                }
            }
        }

        public static void InterruptMode(Obj_AI_Base sender, Interrupter.InterruptableSpellEventArgs args)
        {
            if (InterrupterMode) return;
            if (sender != null && InterrupterUseE)
            {
                var target = TargetManager.GetChampionTarget(SpellsManager.E.Range, DamageType.Magical);
                if (target != null)
                    SpellsManager.E.Cast(target);
            }
        }

        public static void GapCloserMode(Obj_AI_Base sender, Gapcloser.GapcloserEventArgs args)
        {
            if (GapCloserModee) return;
            if (sender != null && GapCloserUseE)
            {
                var target = TargetManager.GetChampionTarget(SpellsManager.E.Range, DamageType.Magical);
                if (target != null)
                    SpellsManager.E.Cast(target);
            }
        }

        private static void Game_OnTick(EventArgs args)
        {
            var orbMode = Orbwalker.ActiveModesFlags;
            var playerMana = Player.Instance.ManaPercent;
            if (UltimateFollower && Champion.HasBuff("VelkozR"))
                ModeManager.UltFollowMode();
            if (RoninVelkoz.Menus.StackMode)
                ModeManager.StackMode();
            Active.Execute();

            if (orbMode.HasFlag(Orbwalker.ActiveModes.Combo))
            {
                Combo.Execute();
            }

            if (orbMode.HasFlag(Orbwalker.ActiveModes.Harass) && playerMana > HarassMenu.GetSliderValue("manaSlider"))
            {
                Harass.Execute();
            }

            if (orbMode.HasFlag(Orbwalker.ActiveModes.LastHit) && playerMana > LasthitMenu.GetSliderValue("manaSlider"))
            {
                LastHit.Execute();
            }

            if (orbMode.HasFlag(Orbwalker.ActiveModes.LaneClear) && playerMana > LaneClearMenu.GetSliderValue("manaSlider"))
            {
                LaneClear.Execute();
            }

            if (orbMode.HasFlag(Orbwalker.ActiveModes.JungleClear) && playerMana > JungleClearMenu.GetSliderValue("manaSlider"))
            {
                JungleClear.Execute();
            }

            if (playerMana > AutoHarassMenu.GetSliderValue("manaSlider") && AutoHarassMenu.GetKeyBindValue("autoHarassKey"))
            {
                AutoHarass.Execute();
            }
        }
    }
}