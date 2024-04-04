class RngAttackDmg : Buff {
    float mult;
    float chance;
    public RngAttackDmg(float mult, float chance) {
        this.mult = mult;
        this.chance = chance;
        desc = $"${chance}% chance to increase Attack Dmg by ${mult}%";
        title = "RNG Attack";
        type = "Health";
    }

    public override void Perform(Unit player) {
        base.Perform(player);

        player.RngDmgMultChance = chance / 100.0f;
        player.dmgMultiplier = 1 + mult / 100.0f;
    }
}