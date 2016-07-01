using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Menu.Values;

namespace RoninAkali
{
    internal static class EventsManager
    {
        public static void Initialize()
        {
            Gapcloser.OnGapcloser += Gapcloser_OnGapcloser;
        }

        private static void Gapcloser_OnGapcloser(AIHeroClient sender, Gapcloser.GapcloserEventArgs e)
        {
            if (!sender.IsEnemy) return;

            if (sender.IsValidTarget(SpellsManager.R.Range) && SpellsManager.W.IsReady() && RoninAkali.Menus.MiscMenu["gapcloser.w"].Cast<CheckBox>().CurrentValue)
            {
                SpellsManager.W.Cast(Player.Instance);
            }
        }
    }
}
