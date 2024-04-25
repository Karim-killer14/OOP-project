
public class UnlockHeavySwing : Buff {
    public UnlockHeavySwing() {
        desc = $"Unlock Heavy Swing";
        title = "New Attack";
        type = "New";
    }

    public override void Perform(Unit player) {
        base.Perform(player);

        player.Moves.Add(new HeavySwing());
    }
}