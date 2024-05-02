using UnityEngine;

public class Heal : Move {
    public float heal = 40;

    public Heal(float dmgMult = 1) : base("Heal", 2) {
        heal *= dmgMult;
    }

    public override bool Perform(Unit performer) {
        if (!base.Perform(performer)) return false;

        performer.CurrentHP += heal;
        return true;
    }
}