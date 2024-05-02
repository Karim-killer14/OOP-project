using Unity.VisualScripting;
using UnityEngine;

public class IncreaseHeal : Buff {
    private int amount = 0;
    public IncreaseHeal(int amount) {
        desc = $"Increase Heal by {amount}";
        title = "Powerup";
        type = "Heal";
        this.amount = amount;
    }

    public override void Perform(Unit player) {
        base.Perform(player);

        foreach (Move move in player.Moves)
            if (move is Heal) {
                Heal healMove = move as Heal;
                healMove.heal += amount;
            }
    }
}