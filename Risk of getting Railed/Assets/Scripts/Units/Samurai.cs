using UnityEngine;


public class Samurai : Unit {
    private void Awake() {
        YPos = -2.18f;
        UnitName = "Samurai";
        MaxHP = 200;
        CurrentSH = 0;
        Moves = new Move[3];

        Moves[0] = new LightSwing();
        Moves[1] = new Heal();
        Moves[2] = new Shield();
    }
}