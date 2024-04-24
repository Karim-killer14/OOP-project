using UnityEngine;

public class Skeleton : Unit
{
    private void Awake()
    {
        YPos = -1.9f;
        UnitName = "Cave Dwellers";
        MaxHP = 250;

        Moves = new Move[3];

        Moves[0] = new Shield();
        Moves[1] = new FlyingBite();
        Moves[2] = new LightSwing();
    }

}