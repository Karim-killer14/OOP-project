using UnityEngine;

public class Heal : Move {
    private readonly int heal = 40;
    public Heal() : base("Heal", 3) { }

    public override bool Perform(Unit performer) {
        if (!base.Perform(performer)) return false;

        performer.CurrentHP += heal;
        return true;
    }
}