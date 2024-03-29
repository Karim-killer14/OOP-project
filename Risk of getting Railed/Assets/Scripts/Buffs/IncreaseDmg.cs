using UnityEngine;

public class IncreaseDmg : Buff {
    private readonly float val;

    public IncreaseDmg(float val) {
        desc = $"Increase damage by {val}%";
        this.val = val;
    }

    public override void Perform(Unit player) {
        base.Perform(player);

        player.dmgMultiplier += val / 100;
    }
}