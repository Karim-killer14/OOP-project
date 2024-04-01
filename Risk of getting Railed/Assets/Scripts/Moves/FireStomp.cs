using UnityEngine;

public class FireStomp : Move {
    public FireStomp() : base("Fire Stomp", 0) { }

    public override bool Perform(Unit performer) {
        if (!base.Perform(performer)) return false;
        performer.enemy.TakeDamage(30);
        // todo shake camear
        return true;
    }
}