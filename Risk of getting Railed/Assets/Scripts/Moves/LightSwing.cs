using UnityEngine;

public class LightSwing : Move {
    public LightSwing() : base("Light Swing", "lightSwing", 10, 0) { }

    public override bool Perform(Unit performer) {
        if (!base.Perform(performer)) return false;

        performer.enemy.TakeDamage(damage);
        return true;
    }
}