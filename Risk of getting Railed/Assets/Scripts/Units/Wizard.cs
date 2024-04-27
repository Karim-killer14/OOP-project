using UnityEngine;

public class Wizard : Unit {
    private void Awake() {
        YPos = -1.88f;
        UnitName = "Wizard";
        MaxHP = 200;

        DifficultyProps diffProps = GameObject.Find("DIFFICULTY_PROPERTIES") ? GameObject.Find("DIFFICULTY_PROPERTIES").GetComponent<DifficultyProps>() : null;
        float dmgMult = diffProps ? diffProps.PlrAtkMult : 1;

        Moves.Add(new LightSwing(dmgMult));
        Moves.Add(new Heal(dmgMult));
        Moves.Add(new Shield(dmgMult));
    }
}