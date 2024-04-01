using UnityEngine;

public class FireSplash : Move {
    public FireSplash() : base("Fire Splash", 5) { }

    public override bool Perform(Unit performer) {
        if (!base.Perform(performer)) return false;
        performer.enemy.TakeDamage(20);
        performer.enemy.Burn = 2;

        return true;
    }
}