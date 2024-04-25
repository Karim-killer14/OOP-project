using UnityEngine;

public class ShroomHeal : Move
{
    private readonly int heal = 40;
    public ShroomHeal() : base("ShroomHeal", 5) { }

    public override bool Perform(Unit performer)
    {
        if (!base.Perform(performer)) return false;

        performer.CurrentHP += heal;
        return true;
    }
}