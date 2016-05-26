using EloBuddy;
using EloBuddy.SDK;
using System.Linq;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;
using EloBuddy.SDK.Enumerations;


namespace RoninVi.Modes
{

    public sealed class PermaActive : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            // Since this is permaactive mode, always execute the loop
            return true;
        }

        public override void Execute()
        {
            if (ChargingQ() && Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Combo) || ChargingQ() && Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.JungleClear) || (ChargingQ() && Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.LaneClear)))
            {
                EloBuddy.Player.IssueOrder(GameObjectOrder.MoveTo, Game.CursorPos);
                return;
            }

            //if (AddonTemplate.Config.Combo.ComboMenu.Enabled)
            //{
            //    switch (Config.Combo.ComboMenu.CurrentMode)
            //    {
            //        #region Flash + Q & Flash + Q + R & Flash + Full Combo

            //        //  "Flash + Q",
            //        //"Flash + Q + R",
            //        //"Gank",


            //        // Flash + Q
            //        case 0:
            //        // Flash + Q + R
            //        case 1:
            //        //"Flash + Full Combo",
            //        case 2:
            //            // Flash + Q
            //            if (Config.Combo.ComboMenu.CurrentMode == 0 && !SpellManager.TapKeyPressed)
            //                //break;

            //                EloBuddy.Player.IssueOrder(GameObjectOrder.MoveTo, Game.CursorPos);
            //            if (SpellManager.Q.IsReady() && SpellManager.Flash.IsReady())
            //            {
            //                var target2 = TargetSelector.SelectedTarget;
            //                var range = SpellManager.Q.MaximumRange + SpellManager.Flash.Range;


            //                if (target2 != null && target2.IsValidTarget(SpellManager.Q.MaximumRange + SpellManager.Flash.Range))
            //                {
            //                    SpellManager.Q.StartCharging();

            //                    Core.DelayAction(delegate ()
            //                    {
            //                        if (SpellManager.Q.IsCharging && SpellManager.Q.IsFullyCharged && target2.IsValidTarget(SpellManager.Q.MaximumRange)) SpellManager.Q.Cast(target2.Position);
            //                    }, 1250);


            //                    Core.DelayAction(delegate ()
            //                    {
            //                        if (target2.IsValidTarget(SpellManager.Q.MaximumRange)) SpellManager.Flash.Cast(target2.Position);
            //                    }, 1251);


            //                }
            //            }
            //            return;
            //    }
            //    // Flash + Q + R
            //    if (Config.Combo.ComboMenu.CurrentMode == 1 && !SpellManager.TapKeyPressed)
               
            //        EloBuddy.Player.IssueOrder(GameObjectOrder.MoveTo, Game.CursorPos);
            //    if (SpellManager.Q.IsReady() && SpellManager.R.IsReady() && SpellManager.Flash.IsReady())
            //    {
            //        var target2 = TargetSelector.SelectedTarget;
            //        var range = SpellManager.Q.MaximumRange + SpellManager.Flash.Range;
            //        if (target2 != null && target2.IsValidTarget(SpellManager.Q.MaximumRange + SpellManager.Flash.Range))
            //        {
            //            SpellManager.Q.StartCharging();

            //            Core.DelayAction(delegate ()
            //            {
            //                if (SpellManager.Q.IsCharging && SpellManager.Q.IsFullyCharged && target2.IsValidTarget(SpellManager.Q.MaximumRange)) SpellManager.Q.Cast(target2.Position);
            //            }, 1250);


            //            Core.DelayAction(delegate ()
            //            {
            //                if (target2.IsValidTarget(SpellManager.Q.MaximumRange)) SpellManager.Flash.Cast(target2.Position);
            //            }, 1251);
            //            R.Cast(target2);
            //            return;



                          
                                    
            //                }


            //        // Gank
            //        if (Config.Combo.ComboMenu.CurrentMode == 2 && !SpellManager.TapKeyPressed)
            //        {
            //            EloBuddy.Player.IssueOrder(GameObjectOrder.MoveTo, Game.CursorPos);

            //            var target = TargetSelector.GetTarget(SpellManager.Q.MaximumRange + 300, DamageType.Physical);
            //            if (SpellManager.Q.IsReady() && target != null)
            //            {
            //                if (SpellManager.Q.IsCharging)
            //                {
            //                    SpellManager.Q.Cast(target);
            //                    return;
            //                }
            //                else
            //                {
            //                    SpellManager.Q.StartCharging();
            //                    return;
            //                }
            //            }
            //        }

            //        #endregion
            //    }
            //}
        }
    }
}
