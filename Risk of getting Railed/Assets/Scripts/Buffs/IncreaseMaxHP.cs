using UnityEngine;

public class IncreaseMaxHP : Buff {
    private readonly float val;

    public IncreaseMaxHP(float val) {
        desc = $"Increase maximum hp by {val}%";
        this.val = val;
    }

    public override void Perform(Unit player) {
        base.Perform(player);

        player.MaxHP += player.MaxHP * (val / 100);
    }
}