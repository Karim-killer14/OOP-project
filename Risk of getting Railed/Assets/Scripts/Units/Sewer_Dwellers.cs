using UnityEngine;

public class Sewer_Dwellers : Unit
{
    private void Awake()
    {
        YPos = -1.88f;
        UnitName = "Sewer Dwellers";
        MaxHP = 500;
        hasTeam = true;
        Teammates.Add("Flying Eye");
        Teammates.Add("Mushroom Dude");

        Moves.Add(new SkeleShield());
        Moves.Add(new ShroomHeal());
        Moves.Add(new FlyingBite());
        Moves.Add(new LightSwing());
        Moves.Add(new HeavySwing());
        Moves.Add(new FlyingSpin());
    }
}
