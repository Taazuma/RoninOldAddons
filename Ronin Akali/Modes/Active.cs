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
using static RoninAkali.Menus;
using static RoninAkali.SpellsManager;
namespace RoninAkali.Modes
{
    /// <summary>
    /// This mode will always run
    /// </summary>
    internal class Active
    {
        private static AIHeroClient myHero
        {
            get { return Player.Instance; }
        }
        //public static void Initialize()
        //{
        //    Gapcloser.OnGapcloser += Gapcloser_OnGapcloser;
        //}
        public static void Execute()
        {

            if (Player.HasBuff("zedulttargetmark"))
            {
                if (W.IsReady())
                {
                    W.Cast(Player.Instance);
                }
            }
            if (Player.Instance.CountEnemiesInRange(Q.Range) >= 2 || Player.Instance.HealthPercent <= 20 && W.IsReady())
            {
                W.Cast(Player.Instance);
            }

            if (KillStealMenu.GetCheckBoxValue("qUse")) // Start KS Q
            {
                var qtarget = TargetSelector.GetTarget(Q.Range, DamageType.Magical);

                if (qtarget == null) return;

                if (Q.IsReady())
                {
                    //var passiveDamage = rtarget.HasPassive() ? rtarget.GetPassiveDamage() : 0f;
                    var rDamage = qtarget.GetDamage(SpellSlot.Q);

                    var predictedHealth = Prediction.Health.GetPrediction(qtarget, Q.CastDelay + Game.Ping);

                    if (predictedHealth <= rDamage)
                    {
                        if (qtarget.IsValidTarget(Q.Range))
                        {
                            Q.Cast(qtarget);
                        }
                    }
                }
            }// END KS

            if (KillStealMenu.GetCheckBoxValue("eUse")) // Start KS E
            {
                var etarget = TargetSelector.GetTarget(E.Range, DamageType.Magical);

                if (etarget == null) return;

                if (E.IsReady())
                {
                    //var passiveDamage = rtarget.HasPassive() ? rtarget.GetPassiveDamage() : 0f;
                    var rDamage = etarget.GetDamage(SpellSlot.E);

                    var predictedHealth = Prediction.Health.GetPrediction(etarget, E.CastDelay + Game.Ping);

                    if (predictedHealth <= rDamage)
                    {
                        if (etarget.IsValidTarget(E.Range))
                        {
                            E.Cast(etarget);
                        }
                    }
                }
            }// END KS

            if (KillStealMenu.GetCheckBoxValue("rUse")) // Start KS R
            {
                var rtarget = TargetSelector.GetTarget(R.Range, DamageType.Magical);

                if (rtarget == null) return;

                if (R.IsReady())
                {
                    //var passiveDamage = rtarget.HasPassive() ? rtarget.GetPassiveDamage() : 0f;
                    var rDamage = rtarget.GetDamage(SpellSlot.R);

                    var predictedHealth = Prediction.Health.GetPrediction(rtarget, R.CastDelay + Game.Ping);

                    if (predictedHealth <= rDamage)
                    {
                        if (rtarget.IsValidTarget(R.Range))
                        {
                            R.Cast(rtarget);
                        }
                    }
                }
            }// END KS

        }
    }
}