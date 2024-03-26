using UnityEngine;

public class HeavySwing : Move {
    public HeavySwing() : base("Heavy Swing", "heavySwing", 5, 90, 0, 0) { }

    public override bool Perform(Unit performer) {
        if (!base.Perform(performer)) return false;

        performer.enemy.TakeDamage(damage);
        return true;
    }
}