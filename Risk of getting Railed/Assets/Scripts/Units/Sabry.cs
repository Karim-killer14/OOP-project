using UnityEngine;


public class Sabry : Unit {
    private void Awake() {
        UnitName = "Sabry";
        MaxHP = 100;

        Moves = new Move[3];

        Moves[0] = new LightSwing();
        Moves[1] = new Heal();
        Moves[2] = new HeavySwing();
    }
}