using UnityEngine;

public class FireSplash : Move {
    public FireSplash() : base("Fire Splash", 5) { }

    public override bool Perform(Unit performer) {
        if (!base.Perform(performer)) return false;

        return true;
    }
}