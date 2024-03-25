using UnityEngine;


public class Rick : Unit {
    private void Awake() {
        UnitName = "Rick";
        MaxHP = 300;
        moves = new Move[1];

        moves[0] = new LightSwing();
    }
}