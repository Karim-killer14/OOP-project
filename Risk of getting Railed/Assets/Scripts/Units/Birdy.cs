using UnityEngine;

public class Birdy : Unit
{
    private void Awake()
    {
        YPos = -21.87f;
        UnitName = "Birdy Sabry";
        MaxHP = 300;

        Moves = new Move[2];

        Moves[0] = new EggBomb();
        Moves[1] = new BirdSpin();
    }
}