using Unity.Burst.Intrinsics;
using UnityEngine;
using UnityEngine.UI;

public class IncreaseMaxHP : Buff {
    private readonly float val;

    private string BuffName = "Bulk up";
    private string BuffType = "Health";
    public IncreaseMaxHP(float val) {
        desc = $"Increase maximum hp by {val}%";
        name = BuffName;
        type = BuffType;
        art = Resources.Load<Sprite>("Assets/Sprites/BuffAssets/Health.png");
        this.val = val;
    }
    public override void Perform(Unit player) {
        base.Perform(player);

        player.MaxHP += player.MaxHP * (val / 100);
    }
}