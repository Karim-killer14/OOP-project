
using UnityEngine;

public class UnlockHeavySwing : Buff {
    public UnlockHeavySwing() {
        desc = $"Unlock Heavy Swing";
        title = "New Attack";
        type = "New";
    }

    public override void Perform(Unit player) {
        base.Perform(player);

         DifficultyProps diffProps = GameObject.Find("DIFFICULTY_PROPERTIES") ? GameObject.Find("DIFFICULTY_PROPERTIES").GetComponent<DifficultyProps>() : null;
        float dmgMult = diffProps ? diffProps.PlrAtkMult : 1;

        player.Moves.Add(new HeavySwing(dmgMult));
    }
}