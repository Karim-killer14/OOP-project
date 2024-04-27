using UnityEngine;


public class FireLord : Unit {
    [SerializeField] AudioSource fireBreathSnd;
    [SerializeField] AudioSource stompSnd;

    private void Awake() {
        YPos = -3.43f;
        UnitName = "Fire Lord";
        MaxHP = 450;

        DifficultyProps diffProps = GameObject.Find("DIFFICULTY_PROPERTIES") ? GameObject.Find("DIFFICULTY_PROPERTIES").GetComponent<DifficultyProps>() : null;
        float dmgMult = diffProps ? diffProps.EnemyAtkMult : 1;

        Moves.Add(new FireSplash(fireBreathSnd, dmgMult));
        Moves.Add(new FireStomp(stompSnd, dmgMult));
    }
}