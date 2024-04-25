using UnityEngine;

public class DeathBringer : Unit {
    private void Awake() {
        YPos = -1.39f;
        UnitName = "DeathBringer Sabry";
        MaxHP = 300;
        CurrentSH = 0;

        Moves.Add(new LifeSteal());
        Moves.Add(new DeathSwing());
        Moves.Add(new Heal());
    }
}
