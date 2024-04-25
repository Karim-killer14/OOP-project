using UnityEngine;


public class Samurai : Unit {
    private void Awake() {
        YPos = -2.18f;
        UnitName = "Samurai";
        MaxHP = 200;
        CurrentSH = 0;

        Moves.Add(new LightSwing());
        Moves.Add(new Heal());
        Moves.Add(new Shield());
    }
}