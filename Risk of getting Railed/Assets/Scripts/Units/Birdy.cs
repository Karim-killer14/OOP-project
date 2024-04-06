using UnityEngine;

public class Birdy : Unit
{
    private void Awake()
    {
        YPos = -1.87f;
        UnitName = "Birdy Sabry";
        MaxHP = 300;

        Moves = new Move[3];

        Moves[0] = new EggGun();
        Moves[1] = new EggBomb();
        Moves[2] = new BirdSpin();
    }
}