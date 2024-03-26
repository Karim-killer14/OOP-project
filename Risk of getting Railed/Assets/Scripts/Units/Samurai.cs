using UnityEngine;


public class Samurai : Unit {
    private void Awake() {
        UnitName = "Samurai";
        MaxHP = 100;
        CurrentSH = 0;
        moves = new Move[4];

        moves[0] = new LightSwing();
        moves[1] = new Heal();
        moves[2] = new HeavySwing();
        moves[3] = new Shield();
    }
}