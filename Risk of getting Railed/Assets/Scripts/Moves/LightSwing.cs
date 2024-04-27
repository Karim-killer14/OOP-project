using UnityEngine;

public class LightSwing : Move {
    private float damage = 25;
    public LightSwing(float dmgMult=1) : base("Light Swing", 0) {
        damage *= dmgMult;
    }

    public override bool Perform(Unit performer) {
        if (!base.Perform(performer)) return false;

        performer.enemy.TakeDamage(damage);

        return true;
    }
}