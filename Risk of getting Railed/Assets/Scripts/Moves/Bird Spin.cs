using UnityEngine;

public class BirdSpin : Move
{
    private readonly int damage = 40;
    public BirdSpin() : base("Bird Spin", 0) { }

    public override bool Perform(Unit performer)
    {
        if (!base.Perform(performer)) return false;

        performer.enemy.TakeDamage(damage * performer.dmgMultiplier);
        return true;
    }
}