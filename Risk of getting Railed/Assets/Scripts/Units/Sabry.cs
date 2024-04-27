using UnityEngine;


public class Sabry : Unit {
    private void Awake() {
        YPos = -3.12f;
        UnitName = "Sabry";
        MaxHP = 100;

        DifficultyProps diffProps = GameObject.Find("DIFFICULTY_PROPERTIES") ? GameObject.Find("DIFFICULTY_PROPERTIES").GetComponent<DifficultyProps>() : null;
        float dmgMult = diffProps ? diffProps.EnemyAtkMult : 1;

        Moves.Add(new LightSwing(dmgMult));
        Moves.Add(new Heal(dmgMult));
        Moves.Add(new HeavySwing(dmgMult));
    }
}