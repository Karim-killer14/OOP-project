using UnityEngine;

public class Birdy : Unit
{
    private void Awake()
    {
        YPos = -1.87f;
        UnitName = "Birdy Sabry";
        MaxHP = 300;

        Moves.Add(new BirdSpin());
        Moves.Add(new EggBomb());
        Moves.Add(new EggGun());
    }
}