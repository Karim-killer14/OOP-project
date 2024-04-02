using UnityEngine;


public class DragonMonster : Unit {
    [SerializeField] AudioSource fireBreathSnd;
    [SerializeField] AudioSource stompSnd;

    private void Awake() {
        YPos = -3.43f;
        UnitName = "Dragon Warrior";
        MaxHP = 1000;

        Moves = new Move[2];
        Moves[0] = new FireSplash(fireBreathSnd);
        Moves[1] = new FireStomp(stompSnd, Camera.main.GetComponent<CameraShake>());
    }
}