using UnityEngine;

public class DeathBringer : Unit
{
    private void Awake()
    {
        UnitName = "DeathBringer";
        MaxHP = 300;
        CurrentSH = 0;
        Moves = new Move[3];

        
        Moves[0] = new LifeSteal();
        Moves[1] = new DeathSwing();
        Moves[2] = new Heal(); 
    }
}
