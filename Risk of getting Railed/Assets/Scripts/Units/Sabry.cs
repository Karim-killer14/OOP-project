using UnityEngine;


public class Sabry : Unit {
    private void Awake() {
        UnitName = "Sabry";
        MaxHP = 100;

        moves = new Move[3];

        moves[0] = new LightSwing();
        moves[1] = new Heal();
        moves[2] = new HeavySwing();
    }
}