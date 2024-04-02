using UnityEngine;

public class Shield : Move {
    public float shield;
    public Shield() : base("Shield", 4) { }

    public override bool Perform(Unit performer) {
        if (!base.Perform(performer)) return false;

        performer.CurrentSH += shield;

        return true;
    }
}