using UnityEngine;

public class HeavySwing : Move {
    private readonly int damage = 100;
    public HeavySwing() : base("Heavy Swing", 5) { }

    public override bool Perform(Unit performer) {
        if (!base.Perform(performer)) return false;

        performer.enemy.TakeDamage(damage * performer.dmgMultiplier);
        return true;    
    }
}