using UnityEngine;

public class Rick : Unit {
    public AudioSource sayGoodbyeSnd;
    public AudioSource rickScreamSnd;

    private void Awake() {
        YPos = -2.0f;
        UnitName = "Rick";
        MaxHP = 250;

        DifficultyProps diffProps = GameObject.Find("DIFFICULTY_PROPERTIES") ? GameObject.Find("DIFFICULTY_PROPERTIES").GetComponent<DifficultyProps>() : null;
        float dmgMult = diffProps ? diffProps.EnemyAtkMult : 1;

        Moves.Add(new SayGoodbye(sayGoodbyeSnd, dmgMult));
        Moves.Add(new RickScream(rickScreamSnd, dmgMult));
    }
}