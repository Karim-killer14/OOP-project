using UnityEngine;


public class Samurai : Unit {
    private void Awake() {
        UnitName = "Samurai";
        MaxHP = 200;
        moves = new Move[3];

        moves[0] = new LightSwing();
        moves[1] = new Heal();
        moves[2] = new HeavySwing();
    }
}