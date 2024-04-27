using UnityEngine;

public class Heal : Move {
    private float heal = 40;

    public Heal(float dmgMult = 1) : base("Heal", 3) {
        heal *= dmgMult;
    }

    public override bool Perform(Unit performer) {
        if (!base.Perform(performer)) return false;

        performer.CurrentHP += heal;
        return true;
    }
}