using UnityEngine;


public class Sabry : Unit {
    private void Awake() {
        YPos = -3.12f;
        UnitName = "Sabry";
        MaxHP = 100;

        Moves.Add(new LightSwing());
        Moves.Add(new Heal());
        Moves.Add(new HeavySwing());
    }
}