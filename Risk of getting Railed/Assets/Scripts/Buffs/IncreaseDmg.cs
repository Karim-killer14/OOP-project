using UnityEngine;
using UnityEngine.UI;

public class IncreaseDmg : Buff {
    private readonly float val;
    
    private string BuffName =  "Strength up";
    private string BuffType = "Strength";
    public IncreaseDmg(float val) {
        desc = $"Increase damage by {val}%";
        name = BuffName;
        type = BuffType;
        art = Resources.Load<Sprite>("Assets/Sprites/BuffAssets/Strength");
        this.val = val;

    }
    public override void Perform(Unit player) {
        base.Perform(player);

        player.dmgMultiplier += val / 100;
    }
}