using UnityEngine;

public class Rick : Unit {
    public AudioSource sayGoodbyeSnd;
    public AudioSource rickScreamSnd;

    private void Awake() {
        YPos = -2.0f;
        UnitName = "Rick";
        MaxHP = 250;

        Moves.Add(new SayGoodbye(sayGoodbyeSnd));
        Moves.Add(new RickScream(rickScreamSnd));
    }
}