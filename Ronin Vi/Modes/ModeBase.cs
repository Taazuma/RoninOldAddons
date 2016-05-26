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
    public abstract class ModeBase
    {
        // Change the spell type to whatever type you used in the SpellManager
        // here to have full features of that spells, if you don't need that,
        // just change it to Spell.SpellBase, this way it's dynamic with still
        // the most needed functions
        protected Spell.Skillshot Q
        {
            get { return SpellsManager.Q; }
        }
        protected Spell.Chargeable Q2
        {
            get { return SpellsManager.Q2; }
        }
        protected Spell.Active W
        {
            get { return SpellsManager.W; }
        }
        protected Spell.Active E
        {
            get { return SpellsManager.E; }
        }

        protected Spell.Skillshot E2
        {
            get { return SpellsManager.E2; }
        }

        protected Spell.Targeted R
        {
            get { return SpellsManager.R; }
        }

        protected Spell.Skillshot Flash
        {
            get { return SpellsManager.Flash; }
        }

        protected bool HasFlash
        {
            get { return SpellsManager.HasFlash(); }
        }

        protected bool ChargingQ()
        {
            return Player.Instance.Spellbook.IsCharging || Player.Instance.HasBuff("Vault Breaker");
        }

        protected bool PotionRunning()
        {
            return Player.Instance.HasBuff("RegenerationPotion") || Player.Instance.HasBuff("ItemCrystalFlaskJungle") || Player.Instance.HasBuff("ItemMiniRegenPotion") || Player.Instance.HasBuff("ItemCrystalFlask") || Player.Instance.HasBuff("ItemDarkCrystalFlask");
        }



        public abstract bool ShouldBeExecuted();

        public abstract void Execute();
    }
}
