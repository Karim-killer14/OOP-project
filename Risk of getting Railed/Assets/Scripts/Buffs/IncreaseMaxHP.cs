using Unity.Burst.Intrinsics;
using UnityEngine;
using UnityEngine.UI;

public class IncreaseMaxHP : Buff {
    private float val;

    public IncreaseMaxHP(float val) {
        this.val = val;
        desc = $"Increase maximum hp by {val}%";
        title = "Bulk up";
        type = "Health";
        this.val = val;
    }

    public override void Perform(Unit player) {
        base.Perform(player);

        player.MaxHP += player.MaxHP * (val / 100);
    }
}