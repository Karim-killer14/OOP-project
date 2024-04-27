using UnityEngine;

public class BirdSpin : Move {
    private float damage = 25;
    public BirdSpin(float dmgMult=1) : base("Bird Spin", 0) {
        damage *= dmgMult;
    }

    public override bool Perform(Unit performer) {
        if (!base.Perform(performer)) return false;

        performer.enemy.TakeDamage(damage * performer.dmgMultiplier);
        return true;
    }
}