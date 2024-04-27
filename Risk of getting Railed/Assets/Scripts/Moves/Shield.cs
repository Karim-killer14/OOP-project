using UnityEngine;

public class Shield : Move {
    public float shield;
    public Shield(float dmgMult = 1) : base("Shield", 4) {
        shield *= dmgMult;
    }

    public override bool Perform(Unit performer) {
        if (!base.Perform(performer)) return false;

        performer.CurrentSH += shield;

        return true;
    }
}