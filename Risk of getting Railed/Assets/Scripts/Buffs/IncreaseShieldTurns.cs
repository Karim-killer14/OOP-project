using Unity.VisualScripting;
using UnityEngine;

public class IncreaseShieldTurns : Buff {
    private int amount = 0;
    public IncreaseShieldTurns(int amount) {
        desc = $"Increase shield turns by {amount}";
        title = "Powerup";
        type = "Shield";
        this.amount = amount;
    }

    public override void Perform(Unit player) {
        base.Perform(player);

        foreach (Move move in player.Moves)
            if (move is Shield) {
                Shield shieldMove = move as Shield;
                shieldMove.shield += amount;
            }
    }
}