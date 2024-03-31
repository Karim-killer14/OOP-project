using UnityEngine;

public class Birdy : Unit
{
    private void Awake()
    {
        UnitName = "Birdy";
        MaxHP = 200;

        Moves = new Move[0];

        
    }
}