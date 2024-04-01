using UnityEngine;


public class DragonMonster : Unit {
    private void Awake() {
        YPos = -3.43f;
        UnitName = "Dragon Warrior";
        MaxHP = 1000;

        Moves = new Move[2];
        Moves[0] = new FireSplash();
        Moves[1] = new FireStomp(Camera.main.GetComponent<CameraShake>());
    }
}