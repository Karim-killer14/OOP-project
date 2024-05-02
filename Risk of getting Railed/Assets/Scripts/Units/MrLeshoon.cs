using UnityEngine;

public class MrLeshoon : Unit {
    private void Awake() {
        YPos = -1.39f;
        UnitName = "DeathBringer Sabry";
        MaxHP = 600;

        DifficultyProps diffProps = GameObject.Find("DIFFICULTY_PROPERTIES") ? GameObject.Find("DIFFICULTY_PROPERTIES").GetComponent<DifficultyProps>() : null;
        float dmgMult = diffProps ? diffProps.EnemyAtkMult : 1;

        Moves.Add(new LifeSteal(dmgMult));
        Moves.Add(new DeathSwing(dmgMult));
        Moves.Add(new Heal(dmgMult));
    }
}
