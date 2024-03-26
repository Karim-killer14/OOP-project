using UnityEngine;

public class Rick : Unit {
    public AudioSource sayGoodbyeSnd;
    public AudioSource rickScreamSnd;

    private void Awake() {
        UnitName = "Rick";
        MaxHP = 300;
        moves = new Move[2];

        moves[0] = new SayGoodbye(sayGoodbyeSnd);
        moves[1] = new RickScream(rickScreamSnd);
    }
}