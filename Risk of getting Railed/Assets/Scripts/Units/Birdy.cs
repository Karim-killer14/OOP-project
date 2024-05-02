using UnityEngine;

public class Birdy : Unit {
    private void Awake() {
        YPos = -1.87f;
        UnitName = "Birdy Sabry";
        MaxHP = 1000;
        
        DifficultyProps diffProps = GameObject.Find("DIFFICULTY_PROPERTIES") ? GameObject.Find("DIFFICULTY_PROPERTIES").GetComponent<DifficultyProps>() : null;
        float dmgMult = diffProps ? diffProps.EnemyAtkMult : 1;

        Moves.Add(new BirdSpin(dmgMult));
        Moves.Add(new EggBomb(dmgMult));
        Moves.Add(new EggGun(dmgMult));
    }
}