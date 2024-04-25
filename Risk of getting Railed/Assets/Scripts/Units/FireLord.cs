using UnityEngine;


public class FireLord : Unit {
    [SerializeField] AudioSource fireBreathSnd;
    [SerializeField] AudioSource stompSnd;

    private void Awake() {
        YPos = -3.43f;
        UnitName = "Fire Lord";
        MaxHP = 1000;

        Moves.Add(new FireSplash(fireBreathSnd));
        Moves.Add(new FireStomp(stompSnd));
    }
}