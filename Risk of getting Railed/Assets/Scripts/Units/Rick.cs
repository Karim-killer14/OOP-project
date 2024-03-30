using UnityEngine;

public class Rick : Unit {
    public AudioSource sayGoodbyeSnd;
    public AudioSource rickScreamSnd;

    private void Awake() {
        YPos = -1.94f;
        UnitName = "Rick";
        MaxHP = 300;
        Moves = new Move[2];

        Moves[0] = new SayGoodbye(sayGoodbyeSnd);
        Moves[1] = new RickScream(rickScreamSnd);
    }
}