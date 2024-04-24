using UnityEngine;

public class HeavySwing : Move {
    private readonly int damage = 90 * 9999;
    public HeavySwing() : base("Heavy Swing", 5) { }

    public override bool Perform(Unit performer) {
        if (!base.Perform(performer)) return false;

        performer.enemy.TakeDamage(damage);
        return true;    
    }
}