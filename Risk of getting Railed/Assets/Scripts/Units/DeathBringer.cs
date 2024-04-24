using UnityEngine;

public class DeathBringer : Unit
{
    private void Awake()
    {
        YPos = -1.39f;
        UnitName = "DeathBringer Sabry";
        MaxHP = 300;
        Moves = new Move[3];

        
        Moves[0] = new LifeSteal();
        Moves[1] = new DeathSwing();
        Moves[2] = new Heal(); 
    }
}
