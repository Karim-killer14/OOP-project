using UnityEngine;

public class Heal : Move {
    public Heal() : base("Heal", "heal", 0, 10) { }

    public override bool Perform(Unit performer) {
        if (!base.Perform(performer)) return false;

        performer.CurrentHP += heal;
        return true;
    }
}