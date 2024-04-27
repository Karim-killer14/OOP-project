using UnityEngine;


public class Samurai : Unit {
    private void Awake() {
        YPos = -2.18f;
        UnitName = "Samurai";
        MaxHP = 200;
        CurrentSH = 0;

        DifficultyProps diffProps = GameObject.Find("DIFFICULTY_PROPERTIES") ? GameObject.Find("DIFFICULTY_PROPERTIES").GetComponent<DifficultyProps>() : null;
        float dmgMult = diffProps ? diffProps.PlrAtkMult : 1;

        Moves.Add(new LightSwing(dmgMult));
        Moves.Add(new Heal(dmgMult));
        Moves.Add(new Shield(dmgMult));
    }
}