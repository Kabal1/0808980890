using EloBuddy;
using EloBuddy.SDK;

namespace Ash
{
    public static class SpellDamage
    {
        internal static float GetRawDamage(Obj_AI_Base target)
        {
            float damage = 0;
            if (target != null)
            {
                if (Ash.Q.IsReady())
                {
                    damage += Player.Instance.GetSpellDamage(target, SpellSlot.Q);
                    damage += Player.Instance.GetAutoAttackDamage(target);
                }
                if (Ash.W.IsReady())
                {
                    damage += Player.Instance.GetSpellDamage(target, SpellSlot.W);
                    damage += Player.Instance.GetAutoAttackDamage(target);
                }
                if (Ash.R.IsReady())
                {
                    damage += Player.Instance.GetSpellDamage(target, SpellSlot.R);
                    damage += Player.Instance.GetAutoAttackDamage(target);
                }
                if (ObjectManager.Player.CanAttack)
                damage += ObjectManager.Player.GetAutoAttackDamage(target);
            }
            return damage;
        }
    }
}
