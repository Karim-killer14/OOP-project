using UnityEngine;

public class Sewer_Dwellers : Unit {
    private void Awake() {
        YPos = -1.88f;
        UnitName = "Sewer Dwellers";
        MaxHP = 550;
        hasTeam = true;
        Teammates.Add("Flying Eye");
        Teammates.Add("Mushroom Dude");

        DifficultyProps diffProps = GameObject.Find("DIFFICULTY_PROPERTIES") ? GameObject.Find("DIFFICULTY_PROPERTIES").GetComponent<DifficultyProps>() : null;
        float dmgMult = diffProps ? diffProps.EnemyAtkMult : 1;

        Moves.Add(new SkeleShield(dmgMult));
        Moves.Add(new ShroomHeal(dmgMult));
        Moves.Add(new FlyingBite(dmgMult));
        Moves.Add(new LightSwing(dmgMult));
        Moves.Add(new HeavySwing(dmgMult));
        Moves.Add(new FlyingSpin(dmgMult));
    }
}
